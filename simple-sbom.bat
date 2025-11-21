@echo off
echo ==========================================
echo    Creating Simple SBOM 
echo ==========================================
echo.

echo Creating SBOM folder...
if not exist "sbom" mkdir sbom

echo Getting all dependencies...
echo SIMS Project - Software Bill of Materials > sbom\complete-sbom.txt
echo Generated on: %date% %time% >> sbom\complete-sbom.txt
echo. >> sbom\complete-sbom.txt

echo ========== API DEPENDENCIES ========== >> sbom\complete-sbom.txt
dotnet list api/api.csproj package >> sbom\complete-sbom.txt

echo. >> sbom\complete-sbom.txt
echo ========== FRONTEND DEPENDENCIES ========== >> sbom\complete-sbom.txt
dotnet list frontend/frontend.csproj package >> sbom\complete-sbom.txt

echo.
echo ==========================================
echo    SBOM Created!
echo ==========================================
echo.
echo File created: sbom\complete-sbom.txt
echo.
echo This file contains all your software dependencies.
echo You can share this with security teams or use it
echo to check for vulnerabilities.
echo.
echo To view the file: notepad sbom\complete-sbom.txt
echo.
pause
