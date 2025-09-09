FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

COPY Estacionamento.Console/Estacionamento.App.csproj Estacionamento.Console/
COPY Estacionamento.Domain/Estacionamento.Domain.csproj Estacionamento.Domain/
COPY Estacionamento.Data/Estacionamento.Data.csproj Estacionamento.Data/
COPY Estacionamento.sln .

RUN dotnet restore Estacionamento.sln

COPY . .

WORKDIR /src/Estacionamento.Console
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "Estacionamento.App.dll" ]
