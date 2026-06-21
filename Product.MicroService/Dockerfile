FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY Product.MicroService/ ./Product.MicroService
COPY ./_Contracts/ ./_Contracts/
RUN dotnet restore Product.MicroService/Product.MicroService.API
RUN dotnet publish Product.MicroService/Product.MicroService.API -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "Product.MicroService.API.dll"]