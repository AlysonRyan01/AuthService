FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY AuthService.sln ./
COPY src/Application/Application.csproj ./src/Application/
COPY src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/
COPY src/Domain/Domain.csproj ./src/Domain/
COPY src/API/API.csproj ./src/API/

RUN dotnet restore

COPY . .

WORKDIR /src/src/API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "API.dll"]
