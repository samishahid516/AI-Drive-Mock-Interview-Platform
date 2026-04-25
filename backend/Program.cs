using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using backend.src.Models;
using backend.src.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3001", "http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Register database service (SQLite)
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var connection = new SqliteConnection(connectionString);
    connection.Open();
    
    // Initialize database schema
    using (var cmd = connection.CreateCommand())
    {
        cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id TEXT PRIMARY KEY,
                FullName TEXT NOT NULL,
                Email TEXT NOT NULL UNIQUE,
                PasswordHash TEXT NOT NULL,
                CreatedAt TEXT NOT NULL,
                UpdatedAt TEXT NOT NULL
            );";
        cmd.ExecuteNonQuery();
    }
    
    return connection;
});

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

// Auth Endpoints
app.MapPost("/auth/register", async (RegisterDto dto, IUserService userService) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(dto.FullName) || 
            string.IsNullOrWhiteSpace(dto.Email) || 
            string.IsNullOrWhiteSpace(dto.Password))
        {
            return Results.BadRequest("FullName, Email, and Password are required.");
        }

        var existingUser = await userService.GetUserByEmailAsync(dto.Email);
        if (existingUser != null)
        {
            return Results.BadRequest("Email already exists.");
        }

        var user = await userService.CreateUserAsync(dto.FullName, dto.Email, dto.Password);
        
        if (user == null)
        {
            return Results.StatusCode(500);
        }

        return Results.Ok(new
        {
            Id = user.Id.ToString(),
            FullName = user.FullName,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        });
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
})
.WithName("Register")
.WithTags("Auth");

app.MapPost("/auth/login", async (LoginDto dto, IUserService userService) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
        {
            return Results.BadRequest("Email and Password are required.");
        }

        var user = await userService.AuthenticateUserAsync(dto.Email, dto.Password);
        
        if (user == null)
        {
            return Results.Unauthorized();
        }

        return Results.Ok(new
        {
            Id = user.Id.ToString(),
            FullName = user.FullName,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        });
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
})
.WithName("Login")
.WithTags("Auth");

app.MapGet("/auth/profile/{userId}", async (string userId, IUserService userService) =>
{
    try
    {
        if (!Guid.TryParse(userId, out var userGuid))
        {
            return Results.BadRequest("Invalid user ID format.");
        }

        var user = await userService.GetUserByIdAsync(userGuid);
        
        if (user == null)
        {
            return Results.NotFound("User not found.");
        }

        return Results.Ok(new
        {
            Id = user.Id.ToString(),
            FullName = user.FullName,
            Email = user.Email,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        });
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
})
.WithName("GetProfile")
.WithTags("Auth");

app.MapPut("/auth/profile/{userId}", async (string userId, UpdateProfileDto dto, IUserService userService) =>
{
    try
    {
        if (!Guid.TryParse(userId, out var userGuid))
        {
            return Results.BadRequest("Invalid user ID format.");
        }

        if (string.IsNullOrWhiteSpace(dto.FullName) || string.IsNullOrWhiteSpace(dto.Email))
        {
            return Results.BadRequest("FullName and Email are required.");
        }

        var existingUser = await userService.GetUserByEmailAsync(dto.Email);
        if (existingUser != null && existingUser.Id != userGuid)
        {
            return Results.BadRequest("Email already exists.");
        }

        var user = await userService.UpdateUserProfileAsync(userGuid, dto.FullName, dto.Email);
        
        if (user == null)
        {
            return Results.NotFound("User not found.");
        }

        return Results.Ok(new
        {
            Id = user.Id.ToString(),
            FullName = user.FullName,
            Email = user.Email,
            UpdatedAt = user.UpdatedAt
        });
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
})
.WithName("UpdateProfile")
.WithTags("Auth");

app.MapPost("/auth/reset-password", async (ResetPasswordDto dto, IUserService userService) =>
{
    try
    {
        if (!Guid.TryParse(dto.UserId, out var userGuid))
        {
            return Results.BadRequest("Invalid user ID format.");
        }

        if (string.IsNullOrWhiteSpace(dto.CurrentPassword) || 
            string.IsNullOrWhiteSpace(dto.NewPassword))
        {
            return Results.BadRequest("CurrentPassword and NewPassword are required.");
        }

        var success = await userService.ResetPasswordAsync(
            userGuid, 
            dto.CurrentPassword, 
            dto.NewPassword);

        if (!success)
        {
            return Results.BadRequest("Invalid current password or user not found.");
        }

        return Results.Ok(new { message = "Password updated successfully." });
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
})
.WithName("ResetPassword")
.WithTags("Auth");

app.MapGet("/", () => Results.Redirect("/swagger"))
    .ExcludeFromDescription();

app.Run();
