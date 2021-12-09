FROM mcr.microsoft.com/dotnet/sdk:6.0 AS sdk
WORKDIR /build

# Copy csproj and restore as distinct layers
COPY ./**/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore DistributedSystems.Web

# Copy everything else and build
COPY . ./
RUN dotnet publish DistributedSystems.Web -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=sdk /build/out .

ENTRYPOINT ["dotnet", "DistributedSystems.Web.dll"]