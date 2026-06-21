FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY Order.MicroService/ ./Order.MicroService
COPY ./_Contracts/ ./_Contracts/
RUN dotnet restore Order.MicroService/Order.MicroService.API
RUN dotnet publish Order.MicroService/Order.MicroService.API -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "Order.MicroService.API.dll"]