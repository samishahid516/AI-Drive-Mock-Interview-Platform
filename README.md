# PrepWise | AI-Powered Mock Interview Platform

PrepWise is a professional interview preparation platform that uses Artificial Intelligence to bridge the gap between candidates and high-pressure technical interviews. It features real-time voice simulation, dynamic question generation, and personalized feedback.

## 🚀 Key Features

*   **🎙️ AI Voice Simulation:** Real-time conversational mock interviews with integrated speech-to-text.
*   **🤖 Smart Question Generation:** Uses Large Language Models to generate role-specific technical and behavioral questions.
*   **📈 Feedback & Sentiment Analysis:** Evaluates responses to provide immediate behavioral insights.
*   **🏗️ Enterprise-Grade Architecture:** Clean code structure using industry-standard design patterns.

## 📸 Technical Preview & UI

To provide a clear understanding of the user journey and system interface:

### 🔐 Authentication Flow
*The platform features a secure, responsive authentication system built with Next.js Server Actions and BCrypt hashing.*

| Sign In Page | Sign Up Page |
| :---: | :---: |
| ![Sign In](https://raw.githubusercontent.com/samishahid516/AI-Drive-Mock-Interview-Platform/main/public/previews/signin.png) | ![Sign Up](https://raw.githubusercontent.com/samishahid516/AI-Drive-Mock-Interview-Platform/main/public/previews/signup.png) |
| *Secure login with email validation* | *User registration & profile creation* |

### 🎙️ AI Interview Dashboard
*Real-time interface showing the AI Agent interaction and live feedback metrics.*

| Dashboard Overview | AI Interview Agent |
| :---: | :---: |
| ![Dashboard](https://raw.githubusercontent.com/samishahid516/AI-Drive-Mock-Interview-Platform/main/public/previews/dashboard.png) | ![Interviewer](https://raw.githubusercontent.com/samishahid516/AI-Drive-Mock-Interview-Platform/main/public/previews/agent.png) |
| *Track interview history & performance* | *Live voice-interactivity with AI* |

> **Note to Interviewers:** Since this is a local development project, please refer to the `/public/previews` folder in this repository to view the full-resolution UI screenshots if the links above are currently being updated.

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
│   └── Program.cs          # Entry Point
└── shared/                 # Multi-platform assets
```

## 🎓 Why This Project?
This project demonstrates proficiency in building **AI-integrated applications**, managing **asynchronous voice pipelines**, and implementing **clean architecture** in a full-stack environment. It specifically addresses the needs of modern AI/ML internships by showcasing hands-on experience with LLMs and voice-based banking simulations.

---
Developed by **[Sami Shahid](https://github.com/samishahid516)**
