FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY havuclukek.catalogServer/havuclukek.catalogServer.csproj havuclukek.catalogServer/
RUN dotnet restore "havuclukek.catalogServer/havuclukek.catalogServer.csproj"
COPY . .
WORKDIR "/src/havuclukek.catalogServer"
RUN dotnet build "havuclukek.catalogServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "havuclukek.catalogServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "havuclukek.catalogServer.dll"]
