FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Survey.Api/Survey.Api.csproj", "Survey.Api/"]
RUN dotnet restore "./Survey.Api/Survey.Api.csproj"
COPY . .
WORKDIR "/src/Survey.Api"
RUN dotnet build "./Survey.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Survey.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Survey.Api.dll"]

COPY init.sql /docker-entrypoint-initdb.d/