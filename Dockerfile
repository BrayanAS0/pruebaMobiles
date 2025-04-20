# Base runtime de ASP.NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# SDK de .NET 8 para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["pruebaMobiles.csproj", "."]
RUN dotnet restore "./pruebaMobiles.csproj"
COPY . .
RUN dotnet build "./pruebaMobiles.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica el proyecto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./pruebaMobiles.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final para producción
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ✅ Aquí es donde debe ir la línea:
ENV ASPNETCORE_URLS=http://+:8080

# Ejecuta la app
ENTRYPOINT ["dotnet", "pruebaMobiles.dll"]
