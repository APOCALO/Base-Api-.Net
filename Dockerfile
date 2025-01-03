# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /app

# Copiar archivos de proyecto
COPY ["Web.Api/*.csproj", "Web.Api/"]
COPY ["Application/*.csproj", "Application/"]
COPY ["Domain/*.csproj", "Domain/"]
COPY ["Infrastructure/*.csproj", "Infrastructure/"]

# Restaurar dependencias
RUN dotnet restore "Domain.csproj"
RUN dotnet restore "Application.csproj"
RUN dotnet restore "Infrastructure.csproj"
RUN dotnet restore "Web.Api.csproj"

# Copiar todo el código fuente
COPY . .

# Publicar la aplicación para producción
RUN dotnet publish "Web.Api.csproj" -c Release -o /app/publish --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de build
COPY --from=build /app/publish .

# Exponer el puerto en el contenedor
EXPOSE 5000

# Establecer el punto de entrada
ENTRYPOINT ["dotnet", "Web.Api.dll"]
