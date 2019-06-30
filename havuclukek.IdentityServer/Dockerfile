FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY havuclukek.identityServer/havuclukek.identityServer.csproj havuclukek.identityServer/
RUN dotnet restore "havuclukek.identityServer/havuclukek.identityServer.csproj"
COPY . .
WORKDIR "/src/havuclukek.identityServer"
RUN dotnet build "havuclukek.identityServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "havuclukek.identityServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "havuclukek.identityServer.dll"]
