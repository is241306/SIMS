# SIMS - Security Incident Management System
[![Build Status](https://img.shields.io/badge/build-passing-green)]()
[![Docker](https://img.shields.io/badge/docker-ready-blue)]()
[![.NET](https://img.shields.io/badge/.NET-8.0-purple)]()
[![Semgrep](https://img.shields.io/badge/SAST-Semgrep-yellow)]()

SIMS is a system for logging and managing IT security incidents. It provides incident tracking, escalation, user management, and secure logging, all running in Docker containers.

---

## 🧩 Features

- **Role-based Authentication & Authorization**  
  - Local credential authentication (username/password)  
  - Token-style session handling (JWT-inspired structure stored client-side)  
  - Role enforcement (Administrator / User)  
  - Protected routes and restricted actions based on permissions  

- **Incident Lifecycle Management**  
  - Create, view, edit, and delete incidents  
  - Structured fields: severity, status, system, CVE, description, reporter, assignee  
  - Accurate timestamp handling with automatic daylight-saving adjustments  
  - Validation and meaningful error states for missing or invalid incidents  

- **User & Role Administration**  
  - Full CRUD for users  
  - Role assignment and permission enforcement  
  - Secure password handling  

- **Centralized Logging**  
  - Logs persisted to SQL Server or Redis  
  - Captures timestamp, log level, and message context  
  - Supports auditing and system monitoring  

- **Service & Data Layers**  
  - Clear separation between UI, business logic, and persistence  
  - Repository abstraction for database interactions  
  - Strong async service patterns  

---

## 🛠 Tech Stack

- **.NET 8**  
- **ASP.NET Core / Blazor Server**  
- **Entity Framework Core**  
- **SQL Server** (primary database)  
- **Redis** (optional, for log storage)  
- **Token-style auth (JWT-like)** stored in session/local storage  
- **Dependency Injection** via .NET built-in DI  
- **Async/await** used across services and repositories  

### **Frontend**
- **Blazor Server (InteractiveServer)**  
- **Razor Components**  
- **Bootstrap Icons**  

### **DevOps / Operations**
- **Docker & Docker Compose**  
- **Semgrep** for SAST  
- **Environment-based configuration**  
- **Git branching workflow** 

---

## 🏗 Architecture
- **App Container:** Hosts the web frontend
- **API Container:** RESTful requests, business logic, and database communication
- **SQL Server Container:** Relational database with EF Core schema
- **Redis Container:** Caching for sessions and/or logs

Diagram:
![](https://www.plantuml.com/plantuml/svg/bLVTSjis4xtdK-me5v6_-QIHCvEPL4tLo5RSQ2O_6Ijz08XSInYJX0O0BRjjRli0VSG-IS6rI2_XjSpeHkIUFG3sx09Sl7DUMLyLUQBotEmBVQlBJPBZbGTlmEhDraEcBQPUcp9ngSeH2dKBfsyc4zZhp6-Jn5thSgUiAc2dqckrmPM_2surIPMR79b3cYldvjvRlQuyBbDJhlGV21FcChVMxBzjTNfTedDmEdwT92_X5_aNaCMNJ_FbvoCkXqN1O64AfSi1_9aa05XM1IpBL6TO-fLNld81WF3xiiEoVWZeLsis5fsZrqjq9h_1Z5xUrr8eJs_Vs_5MU8DM-xl3I1_Ddlu_OQQhWXu_14NfuJpuwJ16moTbu7U7za1UPZ05NVhwXUobAZ2OdBSXHMJz6YXxOxCFocsxoDBDKwzlQl-rCT4aboP7QPBFqGJHkXYjVkrGQumP67EUe_NIR2jJsJGAw1CwfpQHiHLrsZvsfsYoACtoJVkyrtW0XoAOHbL1sDmvlIanuu7_IWZ5nqsqi9UGKR61SiwaMjMxfnw9yWk3qm6CHZ2OZCV_6xJQ9lSo7e5fhWXk5ii65-7lp-oYRrzShpqK_6W7jSM46-qyseKthUsZsUZoaU4ItIweW1oWu0JxGZkrph66cVcGXbeDRYLPkA49cjlEBIgF3N9XJT7I4bOJzx-tup4RLK2xKqGL4piyf_qbxepJtjYxmF9ehrIAlP8X4PliwCO0InAvTUrYjPOnndd7S5BeAR29d-7FoB12UwDxHjxuoi4Uq6YrbT-A08KH8po65WnekqmOpNZYXkkyGiYKss9saa1d7G0m7i_YF0JhYzFtFqqkBc0AbKCditY6UhEatCMy19Wc_HUPG5Un0osg1OaMoqb4eKuYgiIKfuI-p3X6CKew4-iiDzHXNdT3eur5B24ptcFsCxYjsJlGvNsF18ipg7QPyWWxvRUX4FZv2EsFYzqCJwkOJERpoOG-9hlA9n0TX3zAxnwOFpfx0kr9JdZCvzKZJqyfakbH5Odq9dcYTb5c1VhJHtw_4PuvhyvDwQt9mv2zZYpcJgSM_mG-OAsv5bSmKmI2lOc5GG7ZY-oKiZEvpe1AEHHfj0RIU3IIA-JDX1HALPwx8qnM6o8pWIZ2_bI8HMYPlA94fY0JCQLIuCnOIpeag6U2OH3nxl_WTB7B4JBSOHa6Ikz4MQbqevP9TX8w8zcHRV5ZRj518kjFZisMVyQ3hqrC2Rco7alGdbp4JYfsahTod-PgMLvPvRojKbzPXE7xYv17YoTzjcoNszcrArsuUeruwzcTo956KrYiL-ZVrfPPUptgOhLbrl88x_0US0hKSIvP26pbUY0tbfbmWMEj6hiASZFtbY6QNB0B_HvjccMzBue0q1q8p1NOrkEXrt9r0nLa3vOjMkrLcMAzWuGlDOp-cWazBIrNyepZ48BZOyRUKRmFuqO0gzr70p-b3NCSpNX91JMisPUidvI468-xf1VpoUjNhnOmXKEHnxBqvOaYzU29SlNWYThru96At8NEvURgZQNNNjUbjSlZgtWjAUSr9wvWhbLumbk6xZKGxBtluighjN9un2axkC2WSHw0Sh0uIvAk8ADPCC8mK_PwP35hAofUMt1wyUPiSl_DMwaRFD-gSeDkU79yhHUvsGFU1eLBKlQ8SsaymjfuRuhaDsgYgGkPyk_glt__0yrjw-EZTdjABJdpWI5rQYV9sSFjQzg0vCYst1dRKbC6a1_J8rbqnPfoa9pR166PGHrMyYuyLKN-7m00)



---

## 🔒 Security Considerations
- **Token-based Authentication**  
  - JWT-style structured token stored in browser storage  
  - Contains identity + role information  
  - Validated server-side for privileged operations  

- **Role-Based Access Control (RBAC)**  
  - Admins manage users  
  - Users have restricted access and cannot reach admin-only operations  

- **Secure Password Handling**  
  - Passwords hashed before storage  
  - Never exposed in logs or responses  

- **Input Validation**  
  - Server-side validation for incidents, login, and user management  
  - Protects against malformed or malicious input  

- **Audit & Activity Logging**  
  - Logs all relevant actions  
  - Optionally backed by Redis for high throughput  
  - Each entry includes level, timestamp, message  

- **Environment Security**  
  - Secrets injected via environment variables in Docker  
  - Configurable connection strings per environment

---

## ✅ SAST (Static Application Security Testing)

### Semgrep Scan Results

**Scan Status:** ✅ Completed Successfully  
**Date:** November 2025  
**Rules Run:** 274  
**Files Scanned:** 102  
**Total Findings:** 6 (6 blocking)

### 🔍 Security Findings

#### 1. Missing USER in Dockerfiles (High Priority)
- **Affected Files:** `api/Dockerfile`, `frontend/Dockerfile`
- **Severity:** High
- **Issue:** Containers run as root by default, which is a security hazard
- **Risk:** If an attacker controls a process running as root, they have full control over the container
- **Recommendation:** Add `USER non-root` before ENTRYPOINT directive

#### 2. Docker Compose Security Configuration (Medium Priority)

**Database Service (`db`):**
- Missing `no-new-privileges:true` in `security_opt`
  - Risk: Allows privilege escalation via setuid/setgid binaries
- Writable root filesystem
  - Risk: Malicious applications can download/run payloads or modify container files
  - Recommendation: Add `read_only: true` to service configuration

**Redis Service (`redis`):**
- Missing `no-new-privileges:true` in `security_opt`
  - Risk: Allows privilege escalation via setuid/setgid binaries
- Writable root filesystem
  - Risk: Malicious applications can download/run payloads or modify container files
  - Recommendation: Add `read_only: true` to service configuration

### ✅ Positive Security Findings
- ✅ No critical vulnerabilities detected
- ✅ No SQL injection vulnerabilities (EF Core parameterized queries working correctly)
- ✅ No hardcoded secrets or credentials found
- ✅ Code quality is clean with no major code smells
- ✅ 274 security rules passed successfully

### Running Semgrep Scan
To reproduce the security scan:
```bash
docker run --rm -v "${PWD}:/src" returntocorp/semgrep semgrep --config auto
```

### Scan Summary
```
✅ Scan completed successfully.
 • Findings: 6 (6 blocking)
 • Rules run: 274
 • Targets scanned: 102
 • Parsed lines: ~100.0%
```

## 🧭 Before You Code

Follow these steps to keep the project clean and up to date:

1. **Get newest version of main**  
   Make sure you’re starting from the most recent version of the code.
```
git fetch origin
git checkout main
git pull --rebase origin main
```

2. **Create a new feature branch**
```
git checkout -b feature/<your-feature-name>
```

3. **Implement and test your changes**\
   Work only in your feature branch until everything runs smoothly.
   Run the tests locally and confirm that nothing else breaks.\
   <br />

4. **Implement changes and commit**
```
git status
git add .
git commit -m "Describe your changes"
```

5. **Keep your feature branch up to date (avoid future conflicts)**\
   Before pushing or merging, replay your work on top of the latest main:
```
git fetch origin
git rebase origin/main
 ```
   If conflicts appear:
```
# Fix the conflicting files manually

git add <fixed-file>
git rebase --continue
 ```
 Repeat until the rebase completes.
 
 6. **Push your feature branch**
 ```
 git push -u origin feature/<your-feature-name>
 ```
 
 7. **Merge back to main**
    1. Open a Pull request on GitHub website \
        ```base: main <-- compare: feature/<your-feature-name>```
    2. Ensure:
        - Able to merge
        - CI checks pass
        - Merge
        
8. **Sync your local main**
 ```
git checkout main
git pull --rebase origin main
 ```
