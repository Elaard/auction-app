#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["auction-app.sln", "auction-app.sln"]
COPY ["src/AuctionService/AuctionService.csproj", "src/AuctionService/"]
COPY ["src/Contracts/Contracts.csproj", "src/Contracts/"]
COPY ["src/GatewayService/GatewayService.csproj", "src/GatewayService/"]
COPY ["src/IdentityService/IdentityService.csproj", "src/IdentityService/"]
COPY ["src/SearchService/SearchService.csproj", "src/SearchService/"]

RUN dotnet restore "src/AuctionService/AuctionService.csproj"
RUN dotnet restore "src/Contracts/Contracts.csproj"
RUN dotnet restore "src/GatewayService/GatewayService.csproj"
RUN dotnet restore "src/IdentityService/IdentityService.csproj"
RUN dotnet restore "src/SearchService/SearchService.csproj"


COPY . .
WORKDIR "/src/src/IdentityService"
RUN dotnet build "./IdentityService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IdentityService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.dll"]