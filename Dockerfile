# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet publish Payment.HttpApi.Host/Payment.HttpApi.Host.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development


COPY --from=build /app/publish .
EXPOSE 8080

ENTRYPOINT ["dotnet", "Payment.HttpApi.Host.dll"]
