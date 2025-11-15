# SIMS - Security Incident Management System
[![Build Status](https://img.shields.io/badge/build-passing-green)]()
[![Docker](https://img.shields.io/badge/docker-ready-blue)]()
[![.NET](https://img.shields.io/badge/.NET-8.0-purple)]()
[![Semgrep](https://img.shields.io/badge/SAST-Semgrep-yellow)]()

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
- **Frontend:** MudBlazor Blazor Library

---

## 🏗 Architecture
- **App Container:** Hosts the web frontend
- **API Container:** RESTful requests, business logic, and database communication
- **SQL Server Container:** Relational database with EF Core schema
- **Redis Container:** Caching for sessions and/or logs

Diagram:
![Diagramm](https://www.plantuml.com/plantuml/uml/hLXDSzis4BtZLs1qIT8cRdljk7POIMauOriUIUcT9ZSonYIW0I0bdZJ_lLn-h80LBR6Pvk20sBUBXyNk8uNtpcVMxwfIk2UbjvdDAhdDygTi0ol_N8AqaFjCRqeGufNyuyL_jN6sk4tIE_cBd2Nhv3GuBpFdv2S7zjOKKCflGjR_VbRQoxHenyvRfJSDHcSLH9FtjVSNOukFcNji3G_6b39rIUxL7iHtqQsmD2MSM-6kZbu_lfAJfAYKdhoL4roq_XzyVd68XPCOBmo5SsbnU4Px_Km-gSvL0TgVux1MleotE0ENMxNrokXeVWLxiCe_7qAjVEPthdsUPHxMgW8vjL0FYyJ7yzToMXf7y-X_BHFdr4P3WPjfo8FULKJTDU5hxcOBMbXmfjn38L9zRyscVdHYxlAiz82UiMlFjNQ-CL_4BHHgLucFQlCeydfUrMxeq-KgAS6UJTJAx6mUP-eMdCisG2uiHPGI_EDyLcqFnxDIbPiQxU6hxzUSFQp0Nr9bNaaSkj16DNKbSUYu7qwsRaVcg1okA4yHXj9G0vgn2tQMxM7wcEaDkDTlS1klv1BA38l4FQgj4yHRJdwRo7VlvEJNYukV9iH6u9-JW7xG6X1orK39yKK4hIrOwI0WshdW1N8C2SNcfEWiv_UBLRfUBDFvQfoFqXxivom7cJPRWQrnoXlxt9V0N-3_V4wBn3th_3McNHLl0aklIAszAy9TDta09cNP8hgffEWYKfuQfyxwQLja7eO1tqN86LFFEFC50x9td2YIv25nGHwMIADXRH122MbufSLRYMEBajSdQ0cLsGEwVB2c6kbqevn75_V1s24NJhSlb54dD-90Of5MtHCxc1D0Hgzfsl4dnEWoRe4ePZZix3CemKFao5vKj7xm9Wmd2Jbee1Hp0zkS4Bo7Bl-vkE0CUCqYXXDYHSXYCIpHOzW1sk5n4F1u6smNg4V1oq4mOjoCtcSW0vGvX3Fbzj6Qk9el_qwdFwY7Ax1xbTDNpX8solc-AVkdcJUoyAPlOBDHkWKqmzWwKovxA66miwaFqEhYzco-IZ2hnnBIQHcgo5qakWXtv_GZsVb7skM87Q3Lx7maezuyWNv9c5ZmzbkiDyPIGWlrE-WDb0nIeN4XyFkEW5nPY0ogCvPRXuWPaf4Y3mWSxP6OupJH3XSB5Wh3Xb96c64zewhiPe8JP8B5S05J8QBo9ctfpLGMP0rNYSwM47nLIWr168MG0ROtKqzkvs_xON-6GTgdrY3I8QQVF8VZmedFfn6ZLMkwk5il5pSty-KuuGgg0nNIch84osKhLAnZFQ9QOuepJcmmGliT7fGbez9h2ybA92c1CzKI3y3r8-pxu0EAT8DBnh0NLugJ8d527yBTurJ0dYl3W2YG7XnhGIW3x8YfgFksmhnpUzYyFN6EuUtBTq3rJ8ZHnJnRBzn_gUBmnVfj_0N88VlqslfnxoMuhT4EZgEiyMsti2jmJXcT5koNzVphLbbmYOyrcyKRSS73xt6ekYzRSF-BcvQXNgRCiPiPGXwQUm38A2sxLZzkJlBz_svnQFBCHGvhD68ozcg4OADlHuQxdkUWcOiJSIsJeb2uwQnCzMVJtbGqG1dyq9UvqJKNXybfZE75n5LplL0FunzTltTE7efKUoFUWovsLVal)

---

## 🔒 Security Considerations
- **Authentication:** Password hashing
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
