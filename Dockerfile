#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9091

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["proyecto-si8811a-2024-ii-u1-apis-y-funciones-jarro-y-valle.csproj", "."]
RUN dotnet restore "./proyecto-si8811a-2024-ii-u1-apis-y-funciones-jarro-y-valle.csproj"
COPY . .
WORKDIR "/src/."
#RUN dotnet build "proyecto-si8811a-2024-ii-u1-apis-y-funciones-jarro-y-valle.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "proyecto-si8811a-2024-ii-u1-apis-y-funciones-jarro-y-valle.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "proyecto-si8811a-2024-ii-u1-apis-y-funciones-jarro-y-valle.dll"]