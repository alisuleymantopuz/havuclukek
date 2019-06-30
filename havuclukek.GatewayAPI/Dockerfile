FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY havuclukek.gatewayAPI/havuclukek.gatewayAPI.csproj havuclukek.gatewayAPI/
RUN dotnet restore "havuclukek.gatewayAPI/havuclukek.gatewayAPI.csproj"
COPY . .
WORKDIR "/src/havuclukek.gatewayAPI"
RUN dotnet build "havuclukek.gatewayAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "havuclukek.gatewayAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "havuclukek.gatewayAPI.dll"]
