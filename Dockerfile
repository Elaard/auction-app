FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

# copy all csproj files and restore as distinct layers. Use of the same COPY command
# for every dockerfile in the project to take advantage of docker caching
COPY auction-app.sln auction-app.sln
COPY AuctionService/WebApi/WebApi.csproj AuctionService/WebApi/WebApi.csproj
COPY AuctionService/Infrastructure/Infrastructure.csproj AuctionService/Infrastructure/Infrastructure.csproj
COPY AuctionService/AppCore/AppCore.csproj AuctionService/AppCore/AppCore.csproj

COPY SearchService/SearchService/SearchService.csproj SearchService/SearchService/SearchService.csproj

COPY src/GatewayService/GatewayService.csproj src/GatewayService/GatewayService.csproj

COPY src/IdentityService/IdentityService.csproj src/IdentityService/IdentityService.csproj

COPY Contracts/Contracts.csproj Contracts/Contracts.csproj

# Restore package deps
RUN dotnet restore auction-app.sln

# Copy the app folders over
COPY AuctionService/AuctionService AuctionService/AuctionService
COPY Contracts Contracts

WORKDIR /app/src/AuctionService
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT ["dotnet", "AuctionService.dll" ]