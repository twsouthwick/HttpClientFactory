ARG csproj
FROM microsoft/aspnetcore-build as build
WORKDIR /src
COPY ./samples/DockerMultipleServices/Service/Service.csproj .
COPY NuGet.config .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /output ./samples/DockerMultipleServices/Service/

FROM microsoft/aspnetcore
EXPOSE 80
WORKDIR /app
COPY --from=build /output .
ENTRYPOINT ["dotnet", "Service.dll"]