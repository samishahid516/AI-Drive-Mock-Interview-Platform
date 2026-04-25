# PrepWise | AI-Driven Architectural Mock Interview Platform

PrepWise is a production-grade interview simulation ecosystem that leverages **Large Language Models (LLMs)** and **Asynchronous Voice Pipelines** to solve the high-friction problem of technical interview anxiety and inconsistent feedback loops.

The platform is architected to demonstrate enterprise-level full-stack integration, focusing on the intersection of **Real-time Conversational AI**, **Sentiment Analysis**, and **Automated Performance Benchmarking**.

---

## 🏛️ Solving Real-World Engineering Challenges

During development, this project addressed several critical bottlenecks in AI-integrated systems:

### 1. **The Latency Problem in Voice AI**
*   **Challenge:** Standard API calls create a "robotic" delay that breaks the conversational flow.
*   **Solution:** Implemented **Asynchronous Streaming Pipelines** using Vapi to enable near-instantaneous Speech-to-Text (STT) and Text-to-Speech (TTS) banking. This ensures a human-like interactive experience.

### 2. **Contextual Drift in LLM Questioning**
*   **Challenge:** Generic AI often loses track of the interview role or asks repetitive questions.
*   **Solution:** Developed a **State-Aware Prompting Logic** that dynamically adjusts the difficulty and topic based on the candidate's last three responses, maintaining a high-fidelity "Senior Engineer" interviewer persona.

### 3. **Sentiment & Behavioral Analysis Gap**
*   **Challenge:** Most mock tools only check for "correct" words, ignoring the candidate's confidence and tone.
*   **Solution:** Integrated a **Sentiment Analysis Engine** that processes audio transcripts to detect hesitation, confidence levels, and professional tone. It generates a "Behavioral Score" alongside technical accuracy.

---

## 🤖 Post-Interview Intelligent Feedback Loop

PrepWise doesn't just end the call—it provides a data-driven **Post-Action Report**:

*   **Sentiment Breakdown:** Visual feedback on "Confidence vs. Hesitation" during tough technical drills.
*   **Automated Suggestions:** The LLM provides specific code snippets or behavioral tips for questions where the candidate struggled.
*   **Skill Gap Mapping:** Identifies specific areas (e.g., "Weak on SQL optimization, strong on React Hooks") to guide the next practice session.

---

## 🛠️ Tech Stack Analysis

| Component | Technology | Rationale |
| :--- | :--- | :--- |
| **Frontend** | Next.js 15, React 19 | Concurrent Rendering for zero-lag UI during heavy AI processing. |
| **Backend** | ASP.NET Core 8 | High-performance Minimal APIs for scalable orchestration. |
| **Database** | SQLite + Dapper | Portable, relational persistence with micro-ORM speed. |
| **AI/Audio** | Vapi / LLM | Industrial voice-banking agents for real-time NLP. |

---

## 📁 Repository Structure

```text
sami.AI/
├── frontend/               # Next.js Application
│   └── src/
│       ├── app/            # System Routing & Next.js API Routes (Sentiment Logic)
│       ├── components/     # Reusable UI (Auth, Feedback Dashboards, Agent UI)
│       └── services/       # Decoupled API Communication Layer
├── backend/                # ASP.NET Core Web API
│   ├── src/
│   │   ├── Controllers/    # API Resource Endpoints (User, Profile, Auth)
│   │   ├── Models/         # Schema Definitions / DTOs
│   │   └── Services/       # Business Logic & AI Feedback Infrastructure
│   └── Program.cs          # DI Container & Middleware Configuration
└── shared/                 # Universal Constants & Utilities
```

---

## 🎓 Learning Outcomes & Internship Applicability

This repository directly proves my capability in fields requested by **Askari AI** and similar engineering programs:
- **LLM Benchmarking:** Hands-on experience tuning AI models for technical accuracy and bias reduction.
- **Voice Banking Simulation:** Direct exposure to real-time speech processing and compliance pipelines.
- **Sentiment Analysis:** Practical implementation of NLP to provide behavioral coaching.

---
**Developed by [Sami Shahid](https://github.com/samishahid516)**
