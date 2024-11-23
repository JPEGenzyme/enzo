FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY *.sln .
COPY AdventureWorksAPI/*.csproj AdventureWorksAPI/
RUN dotnet restore

COPY AdventureWorksAPI/. AdventureWorksAPI/
WORKDIR /src/AdventureWorksAPI
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AdventureWorksAPI.dll"]
