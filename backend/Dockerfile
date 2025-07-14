# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./App/*.csproj ./App/
RUN dotnet restore ./App/App.csproj

COPY ./App/. ./App/
WORKDIR /app/App
RUN dotnet publish -c Release -o /out

# Runtime stage
# tutaj jest Development!!!
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development 
ENTRYPOINT ["dotnet", "App.dll"]
