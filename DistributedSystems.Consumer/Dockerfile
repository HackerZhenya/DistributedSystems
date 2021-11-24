FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DistributedSystems.Consumer.csproj", "DistributedSystems.Consumer/"]
RUN dotnet restore DistributedSystems.Consumer
COPY . .
RUN dotnet build DistributedSystems.Consumer -c Release -o /app/build

FROM build AS publish
RUN dotnet publish DistributedSystems.Consumer -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DistributedSystems.Consumer.dll"]
