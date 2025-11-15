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
![Diagramm](https://www.plantuml.com/plantuml/png/ZLXDSzis4BtpL-pe4gLrvAQzTV8HsT8acd5iZMItPvXSqnY3e0g0IXNN_xq42N8f0ZIb6LCatiD-WBiFaBzemvGfCX7f9ovtJB4CTYn-OYbkpK4WA8mDawd0A7e37uS_9RfcJsXmXEQCmsIHPupB2Jn7K7vYmRI6bOnvWjAuGVlvbPUFguIUjL5Sfd3BZK1lT84wLdndU2u9Mp23jpn3k5HOtYPpusEVuMwN38EN8jV7s1RtgBWvG7D3K9F5rZ1JQAY_-g6MDlVeydg9Ecjmfr6Dvr_H9ClG0zPCwn-vIhun_UY1ounnGQFtUIvWfUUnuNlqGzda0ay8vPfb2F06vellg-ipkDikDsU09fxv5hS7RJ2RQutcDCCZhxXlVwbZ9fZ5hd2FukJWmSR_StOnWwltPt3rU_dtn_7K6vMW0d3K3V97b0-vI0FBTfMdIsdKmVSUg4bxqOPbEyBA-NNqrTMB-3jgpLBq2sgR5oh6mAAZrZoNyEoPSaWT60LgQul6JciWMFwxumgrnIW0b4NMTaWdWAlyHtl_7HDUPEtZDvvItLwMytZCX6UprsDa-MQ7rFehkLPvgb1J-xaAGKglxctFG_iMoFO2xukqO_mXRn_-PafoIU1IgLmDfV4ohgKRtEMQcrnnr70EQrIQQuCoFbbVErCQaUNIe7fWCSAgMR_6pt6rDYXyHNDnM2LJMnKyUTjXBCirGiNk1Nves9yiVIx4jCFRvpo1UP9CMvFStVH8Jd-7U2zHFmDRfE7eBHAAdD3FDTnewDIrG-6U1_Aqz5Tpj8JAI3YtFkxdP0NNoycBmx92STZnEh7hJbAKaE-lhF6WEqgfrJAqru65QKYVQkzLsqpR_X7sEXH1PqCOJvp8mLeZE5ouldUdVzlIANhfRzaUfuu1klxkU7D8LKhDMkj6J_i5i4211WCqNwp_4Nvl7kDK-Jv65UHZzBOzo7iDFSe64wwxgrLhs2hR2SnG6ewga2dAA2Gi7_wRpGRoeYucQY15QWoY1RAbUYQMbtUmv8WSNedZIh5SVqd6HNsBQizZr32zA3INQCyAx63bu4HDRmo4JyqE3GcvsxcRn-biDWjg5356zTfkcqJd7QPV_cxJ7QQFxolDWwROlMDpO07ii4lUteOINt1jtLMmZQkeJZzZUu2zqTD08FF2F58WlboKrSXbVySv0pUmSwVtjxr3-bzCSFj-d9anmR5UyiA4QKD7Peew_FPEtvjBxsdfbmnwmVMsXpR_h3xSDi-VGLU7MlW8iX0Y4FwnAoj8Lfhw4TYE3L6fAU7Tf_wXg-fg7VNRwrt93CXSc6VBP8JJYpN4yLzI55711rtvE8cbZmV2YAYGWmvyl2k67kgPfvJ65ZRCz0pwhxVbaR5naPwlLxKgmtIptDwUhCrsNZqZhCwNkJGg5-Bur_twPdiBvznnT0UuwuwVF_Fa9JIBqFFO2l881rqh4-thqlFlwUfheLi5wuTjnvp3f1RNdZ-Qv4ddQxvOYPyBgvy3YDKy-eqLM7bR4Bt-gXgXHw7Ug0kv1tTgUxoUBl0dnyVgT0GyW_hVNdM5ZSorKS3a_QJq2PFVPhDV9ctiy2SetENAOD8CwH4-qvgdiijt4oopdbD-MP6WbIEmiajdeyhWmmF61fDwD3J7tfNJUl-KYQBczu9FjH4DmfHEz0LbKcJYVm00)
