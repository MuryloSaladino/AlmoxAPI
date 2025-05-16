FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["Almox.API/Almox.API.csproj", "Almox.API/"]
COPY ["Almox.Persistence/Almox.Persistence.csproj", "Almox.Persistence/"]
COPY ["Almox.Application/Almox.Application.csproj", "Almox.Application/"]
COPY ["Almox.Domain/Almox.Domain.csproj", "Almox.Domain/"]
RUN dotnet restore "Almox.API/Almox.API.csproj"

COPY . .
WORKDIR "/src/Almox.API"
RUN dotnet build "Almox.API.csproj" -c Debug -o /app/build

FROM build AS publish

RUN dotnet publish "Almox.API.csproj" -c Debug -o /app/publish

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Almox.API.dll"]