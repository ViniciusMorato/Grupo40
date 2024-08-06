FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER app

WORKDIR /app

EXPOSE 8080

EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY Lanchonete40App.sln ./
COPY src/Core/Core.csproj src/Core/
COPY src/Adapter.Api/Adapter.Api.csproj src/Adapter.Api/
COPY src/Adapter.PostgreSQL/Adapter.PostgreSQL.csproj src/Adapter.PostgreSQL/

COPY test/Core.Tests/Core.Tests.csproj test/Core.Tests/
COPY test/Adapter.Api.Tests/Adapter.Api.Tests.csproj test/Adapter.Api.Tests/
COPY test/Adapter.PostgreSQL.Tests/Adapter.PostgreSQL.Tests.csproj test/Adapter.PostgreSQL.Tests/

RUN dotnet restore

COPY src/ ./src/

WORKDIR /src

RUN dotnet build . -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish

ARG BUILD_CONFIGURATION=Release

RUN dotnet publish . -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Adapter.Api.dll"]