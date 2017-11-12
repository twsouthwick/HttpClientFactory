FROM microsoft/aspnetcore-build as build
ARG projectFile="./samples/DockerMultipleServices/WebApp/WebApp.csproj"
WORKDIR /src
COPY *.sln *.props *.targets NuGet.config ./
COPY ./build/ ./build
COPY ./src/Microsoft.Extensions.Http/Microsoft.Extensions.Http.csproj ./src/Microsoft.Extensions.Http/Microsoft.Extensions.Http.csproj
COPY $projectFile $projectFile
RUN dotnet restore $projectFile
COPY . .
RUN dotnet publish --no-restore -c Release -o /output ./samples/DockerMultipleServices/WebApp/

FROM microsoft/aspnetcore
EXPOSE 80
WORKDIR /app
COPY --from=build /output .
ENTRYPOINT ["dotnet", "WebApp.dll"]