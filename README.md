# PrepWise | AI-Driven Architectural Mock Interview Platform

PrepWise is a production-grade interview simulation ecosystem that leverages **Large Language Models (LLMs)** and **Asynchronous Voice Pipelines** to provide candidates with a high-fidelity mock interview experience. 

The platform is architected to demonstrate enterprise-level full-stack integration, focusing on the intersection of **Artificial Intelligence** and **Real-time Communication**.

---

## 🏛️ System Architecture & Purpose

This project is built using a **Clean Architecture** approach, separating concerns into distinct layers to ensure scalability and maintainability.

### 1. **Core AI Engine (LLM Interaction)**
- **Purpose:** To move beyond static question banks. The engine dynamically generates technical and behavioral questions based on the candidate's target role and real-time performance.
- **Mechanism:** Implements sophisticated prompt engineering to evaluate response sentiment and provide actionable feedback.

### 2. **Real-time Voice Pipeline (NLP & Banking)**
- **Purpose:** To simulate a realistic, hands-free conversational environment.
- **Mechanism:** Integrates deep-learning based **Speech-to-Text (STT)** and **Text-to-Speech (TTS)** agents. This matches contemporary "Voice Banking" and "Conversational AI" industry standards.

### 3. **High-Performance Backend (ASP.NET Core 8)**
- **Purpose:** Serving as the orchestration layer for AI data flows and user management.
- **Mechanism:** 
    - **Minimal APIs:** For low-latency request handling.
    - **Dapper ORM:** For high-speed data access to the SQLite persistence layer.
    - **BCrypt Security:** Ensuring enterprise-standard data protection for user credentials.

### 4. **Modern Interface (Next.js 15 & React 19)**
- **Purpose:** Providing a seamless, dashboard-driven experience for interview tracking and performance visualization.
- **Mechanism:** Utilizes **Server Actions** and **React 19 Hooks** for optimized data fetching and state management.

---

## 🛠️ Tech Stack Analysis

| Component | Technology | Rationale |
| :--- | :--- | :--- |
| **Frontend** | Next.js 15, React 19 | Leveraging the latest App Router and Concurrent Rendering features. |
| **Backend** | ASP.NET Core 8 | Industry-standard for robust, typed, and high-performance server logic. |
| **Database** | SQLite + Dapper | Chosen for zero-config portability without sacrificing relational query power. |
| **Styling** | Tailwind CSS v4 | Rapid UI development with optimized runtime performance. |
| **AI/Audio** | Vapi / LLM | Production-ready voice agents for real-time interactivity. |

---

## 📁 Repository Structure

```text
sami.AI/
├── frontend/               # Next.js Application
│   └── src/
│       ├── app/            # System Routing & Next.js API Routes
│       ├── components/     # Reusable UI Logic (Auth, Interview, UI components)
│       └── services/       # Decoupled API Communication Layer
├── backend/                # ASP.NET Core Web API
│   ├── src/
│   │   ├── Controllers/    # API Resource Endpoints
│   │   ├── Models/         # Schema Definitions / Data Transfer Objects
│   │   └── Services/       # Business Logic & Infrastructure Layer
│   └── Program.cs          # DI Container & Middleware Configuration
└── shared/                 # Universal Constants & Utilities
```

---

## 🎓 Learning Outcomes & Internship Applicability

This repository directly proves my capability in fields requested by **Askari AI** and similar engineering programs:
- **LLM Benchmarking:** Hands-on experience tuning AI responses for technical accuracy.
- **Voice Banking Simulation:** Direct exposure to real-time speech processing pipelines.
- **Full-Stack Orchestration:** Ability to connect complex AI endpoints to professional UI/UX.

---
**Developed by [Sami Shahid](https://github.com/samishahid516)**
