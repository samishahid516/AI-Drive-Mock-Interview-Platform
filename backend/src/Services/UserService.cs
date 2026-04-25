using Dapper;
using backend.src.Models;
using System.Data;
using BCrypt.Net;

namespace backend.src.Services;

public class UserService : IUserService
{
    private readonly IDbConnection _connection;

    public UserService(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        const string sql = @"
            SELECT Id, FullName, Email, PasswordHash, CreatedAt, UpdatedAt
            FROM Users
            WHERE Email = @Email";

        var row = await _connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Email = email });
        return MapRowToUser(row);
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        const string sql = @"
            SELECT Id, FullName, Email, PasswordHash, CreatedAt, UpdatedAt
            FROM Users
            WHERE Id = @Id";

        var row = await _connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = userId.ToString() });
        return MapRowToUser(row);
    }

    public async Task<User?> CreateUserAsync(string fullName, string email, string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var id = Guid.NewGuid().ToString();
        var now = DateTime.UtcNow.ToString("O"); // ISO 8601

        const string sql = @"
            INSERT INTO Users (Id, FullName, Email, PasswordHash, CreatedAt, UpdatedAt)
            VALUES (@Id, @FullName, @Email, @PasswordHash, @CreatedAt, @UpdatedAt);
            SELECT * FROM Users WHERE Id = @Id;";

        try
        {
            var row = await _connection.QueryFirstOrDefaultAsync<dynamic>(sql, new
            {
                Id = id,
                FullName = fullName,
                Email = email,
                PasswordHash = passwordHash,
                CreatedAt = now,
                UpdatedAt = now
            });

            return MapRowToUser(row);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<User?> AuthenticateUserAsync(string email, string password)
    {
        var user = await GetUserByEmailAsync(email);
        
        if (user == null)
        {
            return null;
        }

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        
        if (!isPasswordValid)
        {
            return null;
        }

        return user;
    }

    public async Task<User?> UpdateUserProfileAsync(Guid userId, string fullName, string email)
    {
        var now = DateTime.UtcNow.ToString("O");
        const string sql = @"
            UPDATE Users
            SET FullName = @FullName, Email = @Email, UpdatedAt = @UpdatedAt
            WHERE Id = @Id;
            SELECT * FROM Users WHERE Id = @Id;";

        try
        {
            var row = await _connection.QueryFirstOrDefaultAsync<dynamic>(sql, new
            {
                Id = userId.ToString(),
                FullName = fullName,
                Email = email,
                UpdatedAt = now
            });

            return MapRowToUser(row);
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> ResetPasswordAsync(Guid userId, string currentPassword, string newPassword)
    {
        var user = await GetUserByIdAsync(userId);
        
        if (user == null)
        {
            return false;
        }

        var isCurrentPasswordValid = BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash);
        
        if (!isCurrentPasswordValid)
        {
            return false;
        }

        var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        var now = DateTime.UtcNow.ToString("O");

        const string sql = @"
            UPDATE Users
            SET PasswordHash = @NewPasswordHash, UpdatedAt = @UpdatedAt
            WHERE Id = @Id";

        var rowsAffected = await _connection.ExecuteAsync(sql, new
        {
            Id = userId.ToString(),
            NewPasswordHash = newPasswordHash,
            UpdatedAt = now
        });

        return rowsAffected > 0;
    }

    private User? MapRowToUser(dynamic? row)
    {
        if (row == null) return null;

        return new User
        {
            Id = Guid.Parse((string)row.Id),
            FullName = (string)row.FullName,
            Email = (string)row.Email,
            PasswordHash = (string)row.PasswordHash,
            CreatedAt = DateTime.Parse((string)row.CreatedAt),
            UpdatedAt = DateTime.Parse((string)row.UpdatedAt)
        };
    }
}
