# PrepWise | AI-Powered Mock Interview Platform

PrepWise is a professional interview preparation platform that uses Artificial Intelligence to bridge the gap between candidates and high-pressure technical interviews. It features real-time voice simulation, dynamic question generation, and personalized feedback.

## 🚀 Key Features

*   **🎙️ AI Voice Simulation:** Real-time conversational mock interviews with integrated speech-to-text.
*   **🤖 Smart Question Generation:** Uses Large Language Models to generate role-specific technical and behavioral questions.
*   **📈 Feedback & Sentiment Analysis:** Evaluates responses to provide immediate behavioral insights.
*   **🏗️ Enterprise-Grade Architecture:** Clean code structure using industry-standard design patterns.

## 🛠️ Tech Stack

### Frontend
- **Framework:** Next.js 15 (App Router)
- **Library:** React 19
- **Styling:** Tailwind CSS v4
- **Icons/UI:** Lucide React, Shadcn UI (Components)

### Backend
- **Core:** ASP.NET Core 8 (Minimal APIs)
- **Data Access:** Dapper ORM
- **Database:** SQLite (Relational storage for performance & simplicity)
- **Auth:** BCrypt.Net for secure password hashing

## 📁 Professional Project Structure

```text
sami.AI/
├── frontend/               # Next.js 15 Application
│   └── src/
│       ├── app/            # Routes & API Endpoints
│       ├── components/     # Atomic UI Components
│       ├── services/       # API integration layer
│       └── types/          # TypeScript interfaces
├── backend/                # ASP.NET Core 8 Web API
│   ├── src/
│   │   ├── Controllers/    # Presentation Layer
│   │   ├── Models/         # Data Transfer Objects
│   │   └── Services/       # Business Logic Layer
│   └── Program.cs          # Dependency Injection & Middleware
└── shared/                 # Multi-platform assets
```

## ⚙️ Development Setup

### 1. Clone & Reinstall
```bash
git clone https://github.com/samishahid516/AI-Drive-Mock-Interview-Platform.git
cd AI-Drive-Mock-Interview-Platform
npm install
```

### 2. Run Backend
```bash
cd backend
dotnet run
# API running on http://localhost:5216
```

### 3. Run Frontend
```bash
cd ..
npm run dev
# Dashboard available on http://localhost:3001
```

## 🎓 Why This Project?
This project was developed to demonstrate proficiency in building **AI-integrated applications**, managing **asynchronous voice pipelines**, and implementing **clean architecture** in a full-stack environment. It specifically addresses the needs of modern AI/ML internships by showcasing hands-on experience with LLMs and voice-based banking simulations.

---
Developed by **[Sami Shahid](https://github.com/samishahid516)**
