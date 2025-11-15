# SIMS - Security Incident Management System
[![Build Status](https://badgen.net/badge/build/passing/green)]()
[![Docker](https://badgen.net/badge/docker/ready/blue)]()
[![.NET](https://badgen.net/badge/.NET/8.0/purple)]()
[![Semgrep](https://badgen.net/badge/SAST/Semgrep/yellow)]()

SIMS is a system for logging and managing IT security incidents. It provides incident tracking, escalation, user management, and secure logging, all running in Docker containers.

---

## 🧩 Features
- Manual recording of security incidents (assignee, reporter, severity, status, CVE, system, description, timestamp, etc.)
- Incident escalation (e.g., to next user or predefined level)
- User management with roles (e.g., Administrator, User)
- Logging using SQL or Redis: ID, timestamp, log level, message
- Core functionality:
    - User login
    - Add/Edit/Close incidents
    - Escalation
    - Add/Disable users
    - List incidents and users

---

## 🛠 Tech Stack
- **Backend:** C#, ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Databases:** SQL Server (relational), Redis (session/log caching)
- **Containerization:** Docker (4 containers: App, API, SQL Server, Redis)
- **Static Analysis:** Semgrep for SAST
- **Frontend:** <span style="color:red">TBD</span>

---

## 🏗 Architecture
- **App Container:** Hosts the web frontend
- **API Container:** RESTful requests, business logic, and database communication
- **SQL Server Container:** Relational database with EF Core schema
- **Redis Container:** Caching for sessions and/or logs

Diagram:
![Diagramm](https://www.plantuml.com/plantuml/png/ZLXDSzis4BtpL-pe4gLrvAQzTV8HsT8acd5iZMItPvXSqnY3e0g0IXNN_xq42N8f0ZIb6LCatiD-WBiFaBzemvGfCX7f9ovtJB4CTYn-OYbkpK4WA8mDawd0A7e37uS_9RfcJsXmXEQCmsIHPupB2Jn7K7vYmRI6bOnvWjAuGVlvbPUFguIUjL5Sfd3BZK1lT84wLdndU2u9Mp23jpn3k5HOtYPpusEVuMwN38EN8jV7s1RtgBWvG7D3K9F5rZ1JQAY_-g6MDlVeydg9Ecjmfr6Dvr_H9ClG0zPCwn-vIhun_UY1ounnGQFtUIvWfUUnuNlqGzda0ay8vPfb2F06vellg-ipkDikDsU09fxv5hS7RJ2RQutcDCCZhxXlVwbZ9fZ5hd2FukJWmSR_StOnWwltPt3rU_dtn_7K6vMW0d3K3V97b0-vI0FBTfMdIsdKmVSUg4bxqOPbEyBA-NNqrTMB-3jgpLBq2sgR5oh6mAAZrZoNyEoPSaWT60LgQul6JciWMFwxumgrnIW0b4NMTaWdWAlyHtl_7HDUPEtZDvvItLwMytZCX6UprsDa-MQ7rFehkLPvgb1J-xaAGKglxctFG_iMoFO2xukqO_mXRn_-PafoIU1IgLmDfV4ohgKRtEMQcrnnr70EQrIQQuCoFbbVErCQaUNIe7fWCSAgMR_6pt6rDYXyHNDnM2LJMnKyUTjXBCirGiNk1Nves9yiVIx4jCFRvpo1UP9CMvFStVH8Jd-7U2zHFmDRfE7eBHAAdD3FDTnewDIrG-6U1_Aqz5Tpj8JAI3YtFkxdP0NNoycBmx92STZnEh7hJbAKaE-lhF6WEqgfrJAqru65QKYVQkzLsqpR_X7sEXH1PqCOJvp8mLeZE5ouldUdVzlIANhfRzaUfuu1klxkU7D8LKhDMkj6J_i5i4211WCqNwp_4Nvl7kDK-Jv65UHZzBOzo7iDFSe64wwxgrLhs2hR2SnG6ewga2dAA2Gi7_wRpGRoeYucQY15QWoY1RAbUYQMbtUmv8WSNedZIh5SVqd6HNsBQizZr32zA3INQCyAx63bu4HDRmo4JyqE3GcvsxcRn-biDWjg5356zTfkcqJd7QPV_cxJ7QQFxolDWwROlMDpO07ii4lUteOINt1jtLMmZQkeJZzZUu2zqTD08FF2F58WlboKrSXbVySv0pUmSwVtjxr3-bzCSFj-d9anmR5UyiA4QKD7Peew_FPEtvjBxsdfbmnwmVMsXpR_h3xSDi-VGLU7MlW8iX0Y4FwnAoj8Lfhw4TYE3L6fAU7Tf_wXg-fg7VNRwrt93CXSc6VBP8JJYpN4yLzI55711rtvE8cbZmV2YAYGWmvyl2k67kgPfvJ65ZRCz0pwhxVbaR5naPwlLxKgmtIptDwUhCrsNZqZhCwNkJGg5-Bur_twPdiBvznnT0UuwuwVF_Fa9JIBqFFO2l881rqh4-thqlFlwUfheLi5wuTjnvp3f1RNdZ-Qv4ddQxvOYPyBgvy3YDKy-eqLM7bR4Bt-gXgXHw7Ug0kv1tTgUxoUBl0dnyVgT0GyW_hVNdM5ZSorKS3a_QJq2PFVPhDV9ctiy2SetENAOD8CwH4-qvgdiijt4oopdbD-MP6WbIEmiajdeyhWmmF61fDwD3J7tfNJUl-KYQBczu9FjH4DmfHEz0LbKcJYVm00)

## 🧩 Roadmap
1. Grobe Phasen

Setup & Planung

Datenmodell & DB-Schicht

Business-Logik & Services

API & Auth

Frontend / Client

Docker & Infrastruktur

Security, SAST & Feinschliff

Dokumentation & Extras (SBOM, CI, etc.)

2. Teamrollen (Beispiel)

Du kannst die Aufgaben so clustern:

Person A – Lead / Backend & Architektur

Person B – DB & DevOps (SQL, Docker, Redis)

Person C – Frontend / UI & API-Integration

Person D – QA & Security (Tests, SAST, Doku)

Wenn ihr weniger Leute seid, kann eine Person zwei Rollen übernehmen.

3. Roadmap Schritt für Schritt
   Phase 1 – Setup & Planung (Starten!)

Ziele: Gemeinsame Basis, Architektur festlegen.

Tasks:

Repo & Branch-Struktur

[A] Git-Repo anlegen (GitLab FH oder GitHub).

Branch-Konvention: main, develop, Feature-Branches (feature/api-auth, …).

Basic .gitignore, README.md mit ganz grobem Projekttext.

Architektur & UML/Klassendiagramm finalisieren

[A + B + C + D] Kurz-Meeting: UML (das von uns) durchgehen → was übernehmen, was vereinfachen?

Entscheiden: Techstack: z.B. .NET 8 Web API, SQL Server, Redis.

Komponenten festlegen: App, API, SQL, Redis als 4 Docker-Container.

Solution-Skeleton

[A]

.NET Solution anlegen:

SIMS.Domain

SIMS.Persistence

SIMS.Services

SIMS.API

optional: SIMS.Tests

Basis-Referenzen setzen (Domain → nichts, Persistence → Domain, Services → Domain+Persistence, API → Services).

➡️ Am Ende von Phase 1: Projekt baut, leere API startet, Basis-Architektur ist fix.

Phase 2 – Datenmodell & Persistence

Ziele: DB-Modelle und Repositories stehen.

Tasks:

ER-Diagramm & SQL-Schema

[B]

Tabellen: Users, Roles, UserRoles, Incidents, SystemAssets, EscalationLevels, Logs, Sessions (wenn nicht Redis-only).

ER-Diagramm zeichnen.

SQL-Skript für CREATE TABLES (wenn kein EF-Code-First).

ORM / Persistence-Implementierung

[B] mit Unterstützung von [A]

Entscheidet: Entity Framework vs. eigenes Repository mit ADO.NET/Dapper.

SqlIncidentRepository, SqlUserRepository, SqlLogRepository, … implementieren.

Sicherstellen: Prepared Statements / EF → keine SQL Injection.

Docker-Setup SQL Server

[B]

SQL-Server-Container per docker-compose oder eigenem Dockerfile.

DB-Init-Skript einbinden (Migrations oder manuelles SQL).

➡️ Ende Phase 2: DB läuft in Docker, Repositories existieren, erste einfache CRUD-Funktionen funktionieren in Tests oder Konsolenprogramm.

Phase 3 – Business-Logik & Services

Ziele: Incident-Logik, User-Logik, Logging als Services.

Tasks:

Domain-Klassen implementieren

[A]

Incident, User, Role, SystemAsset, EscalationLevel, LogEntry, Session, Enums (Severity, IncidentStatus, LogLevel).

IncidentService

[A]

Methoden: CreateIncident, UpdateIncident, CloseIncident, EscalateIncident, GetIncidents.

Validierung (z.B. kein Close ohne Statuswechsel usw.).

UserService

[A]

CreateUser, DisableUser, GetUsers.

einfache Password-Hashing-Funktion (z.B. PBKDF2/BCrypt arg im Code, nicht Klartext!).

LoggingService & LogRepository

[B]

ILoggingService, LoggingServiceImpl.

LogEntry in SQL speichern (oder optional Redis).

EscalationService

[A]

Logik: Finde nächste Eskalationsstufe → update Incident → logge Aktion.

➡️ Ende Phase 3: Services funktionieren ohne API, können über Unit-Tests geprüft werden.

Phase 4 – API & Auth

Ziele: REST-API für User, Incidents und Auth (Login / Sessions).

Tasks:

AuthService & RedisSessionStore

[A + B]

AuthService.Login(username, password):

holt User aus IUserRepository.

vergleicht Passwort-Hash.

erstellt Session mit SessionId, speichert in ISessionStore (Redis).

ValidateSession, Logout.

Redis-Container & Store

[B]

Redis in Docker starten.

RedisSessionStore implementieren (String → JSON Session).

API Controllers

[A + C]

IncidentController: POST /incidents, PUT /incidents/{id}, POST /incidents/{id}/close, POST /incidents/{id}/escalate, GET /incidents.

UserController: POST /users, PUT /users/{id}/disable, GET /users.

AuthController: POST /auth/login, POST /auth/logout.

Middleware/Filter für Session-Check (Auth).

Security in der API

[D]

Input-Validierung (DTOs).

Auth/Authorization: z.B. nur Admin darf User anlegen.

Sensible Daten in Responses minimieren (z.B. kein Passwort-Hash).

➡️ Ende Phase 4: API kann mit Postman getestet werden, Login + Incident CRUD funktionieren end-to-end.

Phase 5 – Frontend / Client

Ziele: Simpler Client, der API nutzt (z.B. Web-Frontend oder Konsolenclient).

Tasks:

Client-Entscheidung

[C]

Minimal: Konsolen-App (C#) oder kleines Web-Frontend (Razor/React/etc.).

Muss können:

Login

Incident anlegen/listen/schließen/eskalieren

Userliste anzeigen (mind. read-only)

Client-Implementierung

[C]

API-Calls bauen (HttpClient in .NET oder Fetch im Browser).

Session-Handling (Speichern der SessionId / Token).

UX-Feinschliff

[C + D]

einfache, aber klare Oberfläche (Fehlermeldungen, Bestätigungstexte).

➡️ Ende Phase 5: Demo möglich: „Login als Admin, Incident anlegen, eskalieren, schließen“.

Phase 6 – Docker & Deployment

Ziele: Alles läuft in Docker-Network, 4 Container.

Tasks:

Dockerfile für API

[B]

Multi-stage build (.NET SDK + Runtime).

Environment-Variablen für DB/Redis-Connection.

Dockerfile für App (Client)

[B + C]

Falls Web-Frontend: z.B. Nginx + statische Files.

Falls Konsole: optional Docker-Container oder lokal starten (minimal).

docker-compose.yml

[B]

Services:

sims-api

sims-app (optional)

sims-sql

sims-redis

Gemeinsames Network, Volumes für SQL-Daten.

➡️ Ende Phase 6: docker-compose up → System läuft komplett.

Phase 7 – Security, SAST & Codequalität

Ziele: Qualität + Securitymaßnahmen nachweisbar.

Tasks:

SAST (Semgrep)

[D]

Semgrep im Repo laufen lassen (Docker-Befehl laut Aufgabenblatt).

Findings dokumentieren:

Was wurde gefunden?

Was habt ihr gefixt?

Was ist „false positive“?

Security-Maßnahmen dokumentieren

[D + A]

Passworthashing

Prepared Statements / EF

Input-Validierung

Role-Based-Access (RBAC)

Session-Handling, TTL

Logging von sicherheitsrelevanten Events

Refactoring & Code-Smells

[Alle]

kurze Code-Review-Runde: Methoden kürzen, Duplikate raus, sinnvolle Namen, Kommentare minimieren/gezielt nutzen.

Phase 8 – Tests & Dokumentation & Bonus

Ziele: Punkte abholen + Projekt sauber abschließen.

Tasks:

Unit-Tests

[D + A]

Tests für IncidentService, AuthService.

Repositories mocken (z.B. mit Moq).

Fokus: Business-Logik, nicht UI.

SBOM & DependencyTrack (Sonderpunkte)

[D]

CycloneDX-Tool auf Solution laufen lassen.

Ergebnis erwähnen + README-Abschnitt.

CI-Pipeline (Sonderpunkte)

[B]

z.B. GitLab CI oder GitHub Actions:

Build

Tests

Semgrep

README.md finalisieren

[D] (mit Input von allen)

Projektbeschreibung, Features

Version, Lizenz, Mitwirkende

Systemvoraussetzungen (.NET, Docker)

Start-Anleitung (docker-compose up, Migrations, etc.)

ER-Diagramm + Klassendiagramm-Screenshots

Security-Maßnahmen

SAST-Ergebnisse

---

## 🔒 Security Considerations
- **Authentication:** <span style="color:red">Password hashing</span>
- **Authorization:** Role-based access control
- **Data Protection:** Use parameterized queries / EF Core to prevent SQL Injection
- **Secrets Management:** Redis or AWS Secret Manager (for sensitive session info)
- **Logging:** Secure logging, avoiding sensitive data in plain text

---

## ✅ SAST (Static Analysis)
- Semgrep configuration is used for detecting common security and code quality issues.
- Run Semgrep:
``` 
docker run --rm -v "C:/temp/SIMS:/src" returntocorp/semgrep semgrep --config auto
```  

## 🧭 Before You Code

Follow these steps to keep the project clean and up to date:

1. **Pull the latest changes**  
   Make sure you’re starting from the most recent version of the code.
```
git checkout main
git pull origin main
```

2. **Create a new test branch**
   Use a descriptive name for your branch
```
git checkout -b feature/<your-feature-name>
```

3. **Implement and test your changes**\
   Work only in your test branch until everything runs smoothly.
   Run the tests locally and confirm that nothing else breaks.\
   <br />

4. **Stage and commit changes**
```
git add .
git commit -m "Describe your changes"
```

5. **Merge back into main**
   Once verified, merge your branch and push to main.
```
git checkout main
git merge feature/<your-feature-name>
git push origin main
 ```
