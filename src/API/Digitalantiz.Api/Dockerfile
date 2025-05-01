# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/API/Digitalantiz.Api/Digitalantiz.Api.csproj", "src/API/Digitalantiz.Api/"]
COPY ["src/Modules/Events/Digitalantiz.Modules.Events.Infrastructure/Digitalantiz.Modules.Events.Infrastructure.csproj", "src/Modules/Events/Digitalantiz.Modules.Events.Infrastructure/"]
COPY ["src/Modules/Events/Digitalantiz.Modules.Events.Application/Digitalantiz.Modules.Events.Application.csproj", "src/Modules/Events/Digitalantiz.Modules.Events.Application/"]
COPY ["src/Modules/Events/Digitalantiz.Modules.Events.Domain/Digitalantiz.Modules.Events.Domain.csproj", "src/Modules/Events/Digitalantiz.Modules.Events.Domain/"]
COPY ["src/Modules/Events/Digitalantiz.Modules.Events.Presentation/Digitalantiz.Modules.Events.Presentation.csproj", "src/Modules/Events/Digitalantiz.Modules.Events.Presentation/"]
RUN dotnet restore "./src/API/Digitalantiz.Api/Digitalantiz.Api.csproj"
COPY . .
WORKDIR "/src/src/API/Digitalantiz.Api"
RUN dotnet build "./Digitalantiz.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Digitalantiz.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Digitalantiz.Api.dll"]