FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

COPY Estacionamento.Api/Estacionamento.Api.csproj Estacionamento.Api/
COPY Estacionamento.Domain/Estacionamento.Domain.csproj Estacionamento.Domain/
COPY Estacionamento.Data/Estacionamento.Data.csproj Estacionamento.Data/
COPY Estacionamento.Tests/Estacionamento.Tests.csproj Estacionamento.Tests/
COPY Estacionamento.sln .

RUN dotnet restore Estacionamento.sln

COPY . .

WORKDIR /src/Estacionamento.Tests
RUN dotnet test .

WORKDIR /src/Estacionamento.Api
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "Estacionamento.Api.dll" ]
