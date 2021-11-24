FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DistributedSystems.Web.csproj", "DistributedSystems/"]
RUN dotnet restore DistributedSystems.Web
COPY . .
RUN dotnet build DistributedSystems.Web -c Release -o /app/build

FROM build AS publish
RUN dotnet publish DistributedSystems.Web -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DistributedSystems.Web.dll"]
