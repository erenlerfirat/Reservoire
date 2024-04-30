FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

ENTRYPOINT ["dotnet", "ReservoireApi.dll"]

# dotnet run --project ./ReservoireApi/ReservoireApi.csproj

#    docker build -t reservoire:v1 .

#    docker images

#    docker run --name firat -p 8080:8080 -it b330845f71cb  ImageId

#    curl  http://localhost:8080/api/login/Test