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
![](https://www.plantuml.com/plantuml/svg/bLVTSjis4xtdK-me5v6_-QIHCvEPL4tLo5RSQ2O_6Ijz08XSInYJX0O0BRjjRli0VSG-IS6rI2_XjSpeHkIUFG3sx09Sl7DUMLyLUQBotEmBVQlBJPBZbGTlmEhDraEcBQPUcp9ngSeH2dKBfsyc4zZhp6-Jn5thSgUiAc2dqckrmPM_2surIPMR79b3cYldvjvRlQuyBbDJhlGV21FcChVMxBzjTNfTedDmEdwT92_X5_aNaCMNJ_FbvoCkXqN1O64AfSi1_9aa05XM1IpBL6TO-fLNld81WF3xiiEoVWZeLsis5fsZrqjq9h_1Z5xUrr8eJs_Vs_5MU8DM-xl3I1_Ddlu_OQQhWXu_14NfuJpuwJ16moTbu7U7za1UPZ05NVhwXUobAZ2OdBSXHMJz6YXxOxCFocsxoDBDKwzlQl-rCT4aboP7QPBFqGJHkXYjVkrGQumP67EUe_NIR2jJsJGAw1CwfpQHiHLrsZvsfsYoACtoJVkyrtW0XoAOHbL1sDmvlIanuu7_IWZ5nqsqi9UGKR61SiwaMjMxfnw9yWk3qm6CHZ2OZCV_6xJQ9lSo7e5fhWXk5ii65-7lp-oYRrzShpqK_6W7jSM46-qyseKthUsZsUZoaU4ItIweW1oWu0JxGZkrph66cVcGXbeDRYLPkA49cjlEBIgF3N9XJT7I4bOJzx-tup4RLK2xKqGL4piyf_qbxepJtjYxmF9ehrIAlP8X4PliwCO0InAvTUrYjPOnndd7S5BeAR29d-7FoB12UwDxHjxuoi4Uq6YrbT-A08KH8po65WnekqmOpNZYXkkyGiYKss9saa1d7G0m7i_YF0JhYzFtFqqkBc0AbKCditY6UhEatCMy19Wc_HUPG5Un0osg1OaMoqb4eKuYgiIKfuI-p3X6CKew4-iiDzHXNdT3eur5B24ptcFsCxYjsJlGvNsF18ipg7QPyWWxvRUX4FZv2EsFYzqCJwkOJERpoOG-9hlA9n0TX3zAxnwOFpfx0kr9JdZCvzKZJqyfakbH5Odq9dcYTb5c1VhJHtw_4PuvhyvDwQt9mv2zZYpcJgSM_mG-OAsv5bSmKmI2lOc5GG7ZY-oKiZEvpe1AEHHfj0RIU3IIA-JDX1HALPwx8qnM6o8pWIZ2_bI8HMYPlA94fY0JCQLIuCnOIpeag6U2OH3nxl_WTB7B4JBSOHa6Ikz4MQbqevP9TX8w8zcHRV5ZRj518kjFZisMVyQ3hqrC2Rco7alGdbp4JYfsahTod-PgMLvPvRojKbzPXE7xYv17YoTzjcoNszcrArsuUeruwzcTo956KrYiL-ZVrfPPUptgOhLbrl88x_0US0hKSIvP26pbUY0tbfbmWMEj6hiASZFtbY6QNB0B_HvjccMzBue0q1q8p1NOrkEXrt9r0nLa3vOjMkrLcMAzWuGlDOp-cWazBIrNyepZ48BZOyRUKRmFuqO0gzr70p-b3NCSpNX91JMisPUidvI468-xf1VpoUjNhnOmXKEHnxBqvOaYzU29SlNWYThru96At8NEvURgZQNNNjUbjSlZgtWjAUSr9wvWhbLumbk6xZKGxBtluighjN9un2axkC2WSHw0Sh0uIvAk8ADPCC8mK_PwP35hAofUMt1wyUPiSl_DMwaRFD-gSeDkU79yhHUvsGFU1eLBKlQ8SsaymjfuRuhaDsgYgGkPyk_glt__0yrjw-EZTdjABJdpWI5rQYV9sSFjQzg0vCYst1dRKbC6a1_J8rbqnPfoa9pR166PGHrMyYuyLKN-7m00)



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