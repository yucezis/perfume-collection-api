<div align="center">

# 🌸 Perfume Collection & Inventory Management API

**A "Living" Backend Laboratory Built on the .NET Ecosystem**

*From Theory to Practice — Hands-on Backend Engineering*

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Latest-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Status](https://img.shields.io/badge/Status-Actively%20Developed-brightgreen?style=for-the-badge)

</div>

---

## About This Project

Hi, I'm **Zişan** — a 4th-year Computer Engineering student at Selçuk University.

My career goal is to become an **Full Stack Developer**. Alongside larger projects like Books (full-stack e-commerce) and ZenBudget (FinTech), I wanted a dedicated space to sharpen my backend skills in isolation. Built around a topic I genuinely enjoy, this API serves as my personal **"backend laboratory"** — a place where every new concept, architecture pattern, and best practice I learn gets applied in a real codebase.

> *"Software development is not a destination — it's a continuous process of building."*

---

## Project Structure

```
Perfume/
├── Controllers/
│   ├── BrandController.cs
│   ├── CollectionItemController.cs
│   ├── NoteController.cs
│   ├── PerfumeController.cs
│   ├── AuthController.cs
│   └── PerfumeNotesController.cs
├── Data/
│   ├── PerfumeDbContext.cs
│   └── DatabaseSeeder.cs
├── DTOs/
│   ├── AddCollectionDTO.cs
│   ├── AuthResponseDTO.cs
│   ├── LoginDTO.cs
│   └── RegisterDTO.cs
├── Models/
│   ├── Enum/
│   │   ├── NoteType.cs
│   │   └── ScentFamily.cs
│   ├── Brand.cs
│   ├── CollectionItem.cs
│   ├── Note.cs
│   ├── Perfume.cs
│   └── PerfumeNotes.cs
├── Services/
│   ├── ITokenService.cs
│   └── TokenService.cs
├── Migrations/
├── appsettings.json
├── Perfume.http
└── Program.cs
```

---

## Current Features

The focus at this stage has been building a **solid, industry-standard foundation** — not just code that works, but code that follows professional practices.

### Entity Framework Core & Code-First Approach

- All database tables are modeled entirely through C# entity classes
- Configured to run on **SQL Server**
- Schema managed via EF Core migrations

### Relational Data Model

```
Brand ──────────────── Perfume
                          │
                  PerfumeNotes (join table)
                          │
                        Note
                      (NoteType Enum: Top / Middle / Base)
                      (ScentFamily Enum: Floral / Woody / etc.)

Perfume ─────────── CollectionItem
                    (Personal collection tracking)
```

- **One-to-Many:** A brand can have many perfumes
- **Many-to-Many:** Perfumes and notes are linked through a `PerfumeNotes` join table
- **Enums:** `NoteType` (Top, Middle, Base) and `ScentFamily` for structured categorization
- Foreign key constraints and referential integrity are enforced throughout

### RESTful API Endpoints

Full CRUD operations are available across all resources:

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/brands` | List all brands |
| `GET` | `/api/brands/{id}` | Get brand by ID |
| `POST` | `/api/brands` | Create a new brand |
| `PUT` | `/api/brands/{id}` | Update a brand |
| `DELETE` | `/api/brands/{id}` | Delete a brand |
| `GET` | `/api/perfumes` | List all perfumes |
| `GET` | `/api/perfumes/{id}` | Get perfume by ID |
| `POST` | `/api/perfumes` | Create a new perfume |
| `PUT` | `/api/perfumes/{id}` | Update a perfume |
| `DELETE` | `/api/perfumes/{id}` | Delete a perfume |
| `GET` | `/api/notes` | List all notes |
| `POST` | `/api/notes` | Create a new note |
| `PUT` | `/api/notes/{id}` | Update a note |
| `DELETE` | `/api/notes/{id}` | Delete a note |
| `GET` | `/api/perfumenotes` | List perfume–note relationships |
| `POST` | `/api/perfumenotes` | Assign a note to a perfume |
| `DELETE` | `/api/perfumenotes/{id}` | Remove a note from a perfume |
| `GET` | `/api/collection` | View personal collection |
| `POST` | `/api/collection` | Add perfume to collection |
| `DELETE` | `/api/collection/{id}` | Remove from collection |

> ✔️ All endpoints include `BadRequest` validation guards, `NotFound` null-safety checks, and correct HTTP status codes.

---

## Roadmap — The "Living Project" Philosophy

This project will never be "done." Every new design pattern, architecture concept, or technology I study gets integrated here. Below is what's coming next.

### Near-Term

- [x] **DTO Layer** — Complete the `DTOs/` folder with dedicated `Request` and `Response` DTOs to isolate database models from the API surface
- [x] **Async / Await** — Migrate all controller actions and DbContext calls to asynchronous patterns for high-concurrency readiness
- [x] **Eager Loading** — Use EF Core `.Include()` to return enriched JSON responses (full related objects instead of raw IDs)

### Mid-Term

- [x] **JWT Authentication & Authorization** — Add token-based auth with role-based access control
- [ ] **Global Exception Handling** — Centralize all error handling into a single middleware pipeline

### Long-Term

- [ ] **Unit & Integration Tests** — Build a test suite using xUnit
- [ ] **AI Integration** — Perfume recommendation engine based on personal collection and scent preferences 

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB or Express is sufficient)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Setup

```bash
# 1. Clone the repository
git clone https://github.com/your-username/perfume-api.git
cd perfume-api

# 2. Configure your connection string
# Edit appsettings.json → ConnectionStrings → DefaultConnection

# 3. Apply migrations
dotnet ef database update

# 4. Run the application
dotnet run
```

The API will be available at `https://localhost:7000`.
Swagger UI is accessible at `/swagger`.

---

## Tech Stack

| Technology | Role |
|-----------|------|
| **C# / .NET 9** | Core language and runtime |
| **ASP.NET Core Web API** | RESTful API framework |
| **Entity Framework Core** | ORM and database management |
| **SQL Server** | Relational database |
| **Swagger / OpenAPI** | API documentation and testing |

---

## Contact

**Zişan Yüce**
Selçuk University — Computer Engineering

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-0A66C2?style=flat-square&logo=linkedin)](https://linkedin.com/in/zisanyuce)
[![GitHub](https://img.shields.io/badge/GitHub-Follow-181717?style=flat-square&logo=github)](https://github.com)

---

<div align="center">

*This project is built with a commitment to clean code, solid architecture, and continuous learning.*

⭐ If you find this useful, consider leaving a star!

</div>
