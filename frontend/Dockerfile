# ===============================
# BASE IMAGE (Runtime)
# ===============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# ===============================
# BUILD IMAGE
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["frontend.csproj", "./"]
RUN dotnet restore "frontend.csproj"

COPY . .

WORKDIR "/src"
RUN dotnet build "frontend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ===============================
# PUBLISH ARTIFACTS
# ===============================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "frontend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ===============================
# FINAL RUNTIME IMAGE
# ===============================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "frontend.dll"]