﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Guths.Cep.Api.csproj", "./"]
RUN dotnet restore "Guths.Cep.Api.csproj"
COPY . .

WORKDIR "/src/"
RUN dotnet build "./Guths.Cep.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build /p:DisableBuildServers=true

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Guths.Cep.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Guths.Cep.Api.dll"]
