FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /App
COPY HomeFinances.WebApi/ .

RUN dotnet restore && dotnet publish -c release -o /build --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /App
COPY --from=build /build ./

ENTRYPOINT ["dotnet", "HomeFinances.WebApi.API.dll"]