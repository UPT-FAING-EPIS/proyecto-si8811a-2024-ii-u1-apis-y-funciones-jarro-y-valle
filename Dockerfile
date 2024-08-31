# Utilizar la imagen base de .NET ASP.NET Core Runtime para la ejecución de la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Utilizar la imagen base de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos de proyecto y restaurar las dependencias
COPY ["proyecto-si8811a-2024-ii-u1-desarrollo-api-back.csproj", "./"]
RUN dotnet restore "proyecto-si8811a-2024-ii-u1-desarrollo-api-back.csproj"

# Copiar el resto de los archivos y compilar la aplicación
COPY . .
RUN dotnet build "proyecto-si8811a-2024-ii-u1-desarrollo-api-back.csproj" -c Release -o /app/build

# Publicar la aplicación para producción
FROM build AS publish
RUN dotnet publish "proyecto-si8811a-2024-ii-u1-desarrollo-api-back.csproj" -c Release -o /app/publish --no-restore

# Configurar la imagen final basada en ASP.NET Core Runtime
FROM base AS final
WORKDIR /app

# Copiar los archivos publicados a la carpeta de trabajo
COPY --from=publish /app/publish .

# Asegurarse de que la aplicación se ejecuta en el entorno de desarrollo
ENV ASPNETCORE_ENVIRONMENT=Development

# Configurar la URL para que el contenedor escuche en todas las interfaces
ENV ASPNETCORE_URLS=http://+:80

# Configurar el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "proyecto-si8811a-2024-ii-u1-desarrollo-api-back.dll"]
