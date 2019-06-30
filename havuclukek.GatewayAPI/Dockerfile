FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY havuclukek.GatewayAPI/havuclukek.GatewayAPI.csproj havuclukek.GatewayAPI/
RUN dotnet restore "havuclukek.GatewayAPI/havuclukek.GatewayAPI.csproj"
COPY . .
WORKDIR "/src/havuclukek.GatewayAPI"
RUN dotnet build "havuclukek.GatewayAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "havuclukek.GatewayAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "havuclukek.gatewayAPI.dll"]
