FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER app

WORKDIR /app

EXPOSE 5058

EXPOSE 7292

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY Lanchonete40App.sln ./

COPY src/ ./src/

COPY test/ test/

RUN dotnet restore

RUN dotnet build . -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish

ARG BUILD_CONFIGURATION=Release

RUN dotnet publish . -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Adapter.Api.dll"]
