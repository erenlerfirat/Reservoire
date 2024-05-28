FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build-env

WORKDIR /app


EXPOSE 8080

COPY . /app
RUN dotnet restore
RUN dotnet publish -c Release -o out --no-build

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy
WORKDIR /app
# ENV ASPNETCORE_ENVIRONMENT=Development
# ENV ASPNETCORE_URLS=http://*:5000

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "ReservoireApi.dll"]

# dotnet run --project ./ReservoireApi/ReservoireApi.csproj

#    docker build -t reservoire:v1 . --no-cache 

#    docker images

#    docker run --rm --name firat -p 5000:8080 -it reservoire:v1   ImageId

#    curl  http://localhost:5000/api/Auth/Test

#    docker rmi ImageId

#    open wsl-2 system win prompt => code --remote wsl+Ubuntu /mnt/c/Users/Onur/source/repos/Reservoire