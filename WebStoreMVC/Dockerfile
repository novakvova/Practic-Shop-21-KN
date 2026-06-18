# ===== BUILD =====
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY WebStoreMVC/WebStoreMVC.csproj WebStoreMVC/
RUN dotnet restore WebStoreMVC/WebStoreMVC.csproj

COPY . .
WORKDIR /src/WebStoreMVC
RUN dotnet publish -c Release -o /app/publish

# ===== RUNTIME =====
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

EXPOSE 8080

COPY --from=build /app/publish .


ENTRYPOINT ["dotnet", "WebStoreMVC.dll"]
