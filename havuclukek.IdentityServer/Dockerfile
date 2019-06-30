FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY havuclukek.IdentityServer/havuclukek.IdentityServer.csproj havuclukek.IdentityServer/
RUN dotnet restore "havuclukek.IdentityServer/havuclukek.IdentityServer.csproj"
COPY . .
WORKDIR "/src/havuclukek.IdentityServer"
RUN dotnet build "havuclukek.IdentityServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "havuclukek.IdentityServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "havuclukek.identityServer.dll"]
