FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build-env

WORKDIR /App

EXPOSE 7070
# Copy everything
COPY . /App

# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy

WORKDIR /App

COPY --from=build-env /App/out .

ENV ASPNETCORE_URLS http://*:7070

ENTRYPOINT ["dotnet", "ReservoireApi.dll"]

# dotnet run --project ./ReservoireApi/ReservoireApi.csproj

#    docker build -t reservoire:v1 . --no-cache 

#    docker images

#    docker run --rm --name firat -p 4000:7070 -it reservoire:v1   ImageId

#    curl  http://localhost:4000/api/login/Test

#    docker rmi ImageId

#    open wsl-2 system win prompt => code --remote wsl+Ubuntu /mnt/c/Users/Onur/source/repos/Reservoire