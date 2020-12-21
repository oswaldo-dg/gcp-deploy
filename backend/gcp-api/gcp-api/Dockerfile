#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 7001
EXPOSE 7000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
WORKDIR "/src/backend/gcp-api/gcp-api"
RUN dotnet restore "gcp-api.csproj"

FROM build AS publish
RUN dotnet publish "gcp-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set CA trust for HTTPS
COPY ["resources/localhost.pfx", "/app/localhost.pfx"]
COPY ["resources/cacertpem.crt", "/usr/local/share/ca-certificates/cacertpem.crt"]
RUN update-ca-certificates


ENTRYPOINT ["dotnet", "gcp-api.dll"]