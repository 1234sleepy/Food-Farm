FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY . ./
RUN dotnet restore Account.MicroService.API
RUN dotnet publish Account.MicroService.API -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "Account.MicroService.API.dll"]