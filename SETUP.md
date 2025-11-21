# SIMS Setup Guide

## Environment Configuration

This project uses environment variables to manage sensitive credentials and configuration.

### 1. Create Environment File

Copy the example environment file and update with your values:

```bash
cp .env.example .env
```

### 2. Configure Environment Variables

Edit the `.env` file with your actual credentials:

```bash
# Database Configuration
DB_SERVER=localhost
DB_PORT=1433
DB_NAME=simsdb
DB_USER=sa
DB_PASSWORD=your_secure_password_here

# Redis Configuration
REDIS_HOST=redis
REDIS_PORT=6379

# JWT Configuration
JWT_SECRET_KEY=your_jwt_secret_key_minimum_32_characters
JWT_ISSUER=SIMS.Api
JWT_AUDIENCE=SIMS.Frontend
JWT_EXPIRES_MINUTES=60

# Docker Compose - Database
MSSQL_SA_PASSWORD=your_secure_password_here

# API Base URL (for frontend)
API_BASE_URL=http://api:8080
```

### 3. Security Notes

⚠️ **IMPORTANT:**
- **NEVER** commit the `.env` file to version control
- The `.env` file is already in `.gitignore`
- Use strong, unique passwords for production
- Change the JWT secret key to a random 32+ character string
- The `.env.example` file is safe to commit (contains no real secrets)

### 4. Running the Application

Once your `.env` file is configured:

```bash
# Start all services
docker-compose up -d

# View logs
docker-compose logs -f

# Stop services
docker-compose down
```

### 5. Local Development

For local development without Docker, ensure your environment variables are set:

**Windows (PowerShell):**
```powershell
$env:ConnectionStrings__DefaultConnection="Server=localhost,1433;Database=simsdb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
$env:Jwt__Key="YourJwtSecretKey"
```

**Linux/Mac:**
```bash
export ConnectionStrings__DefaultConnection="Server=localhost,1433;Database=simsdb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
export Jwt__Key="YourJwtSecretKey"
```

## Troubleshooting

### Environment Variables Not Loading

If environment variables aren't being picked up:

1. Ensure `.env` file is in the project root
2. Restart Docker containers: `docker-compose down && docker-compose up -d`
3. Check Docker logs: `docker-compose logs api`

### Database Connection Issues

1. Verify `DB_PASSWORD` matches `MSSQL_SA_PASSWORD`
2. Ensure SQL Server container is running: `docker ps`
3. Check connection string format in logs
