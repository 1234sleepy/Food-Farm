FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY . ./
RUN dotnet restore Gateway.API
RUN dotnet publish Gateway.API -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "Gateway.API.dll"]