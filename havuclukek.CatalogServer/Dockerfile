FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY havuclukek.CatalogServer/havuclukek.CatalogServer.csproj havuclukek.CatalogServer/
RUN dotnet restore "havuclukek.CatalogServer/havuclukek.CatalogServer.csproj"
COPY . .
WORKDIR "/src/havuclukek.CatalogServer"
RUN dotnet build "havuclukek.CatalogServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "havuclukek.CatalogServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "havuclukek.catalogServer.dll"]
