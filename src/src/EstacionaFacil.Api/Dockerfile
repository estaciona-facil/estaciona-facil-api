FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# COPY dos projetos para restore
COPY ["src/EstacionaFacil.Api/EstacionaFacil.Api.csproj", "EstacionaFacil.Api/"]
COPY ["src/EstacionaFacil.Domain/EstacionaFacil.Domain.csproj", "EstacionaFacil.Domain/"]
COPY ["src/EstacionaFacil.Infra.Data/EstacionaFacil.Infra.Data.csproj", "EstacionaFacil.Infra.Data/"]
COPY ["src/EstacionaFacil.Infra.IoC/EstacionaFacil.Infra.IoC.csproj", "EstacionaFacil.Infra.IoC/"]
COPY ["src/EstacionaFacil.Infra.CrossCutting/EstacionaFacil.Infra.CrossCutting.csproj", "EstacionaFacil.Infra.CrossCutting/"]

RUN dotnet restore "EstacionaFacil.Api/EstacionaFacil.Api.csproj"

# copia todo o código agora que o restore está cacheado
COPY . .

WORKDIR "EstacionaFacil.Api"
RUN dotnet build "EstacionaFacil.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EstacionaFacil.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EstacionaFacil.Api.dll"]
