# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Base image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY *.sln .
COPY AdventureWorksAPI/*.csproj AdventureWorksAPI/
RUN dotnet restore

# Copy the rest of the application and build it
COPY AdventureWorksAPI/. AdventureWorksAPI/
WORKDIR /src/AdventureWorksAPI
RUN dotnet publish -c Release -o /app/publish

# Final stage for running the application
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AdventureWorksAPI.dll"]
