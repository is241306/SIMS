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
	
Diagram: <span style="color:red">TBD</span>

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
   
6. **Clean up**
Remove the temporary test branch once it’s no longer needed
```
git branch -d test/<your-feature-name>
```
