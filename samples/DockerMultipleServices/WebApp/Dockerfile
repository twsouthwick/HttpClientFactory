FROM microsoft/aspnetcore-build as build
ARG projectFile="./samples/DockerMultipleServices/WebApp/WebApp.csproj"
WORKDIR /src
COPY $projectFile .
COPY NuGet.config .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /output ./samples/DockerMultipleServices/WebApp/

FROM microsoft/aspnetcore
EXPOSE 80
WORKDIR /app
COPY --from=build /output .
ENTRYPOINT ["dotnet", "WebApp.dll"]