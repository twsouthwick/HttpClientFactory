ARG csproj
FROM microsoft/aspnetcore-build as build
WORKDIR /src

#Copy all the MSBUILD stuff over and just save it. Takes advantage of Docker layer caching to not repeat
#any restore oprations unless they project files change.
COPY *.sln *.props *.targets NuGet.config ./
COPY ./build/ ./build
COPY ./samples/DockerMultipleServices/Service/Service.csproj ./samples/DockerMultipleServices/Service/Service.csproj
COPY ./src/Microsoft.Extensions.Http/Microsoft.Extensions.Http.csproj ./src/Microsoft.Extensions.Http/Microsoft.Extensions.Http.csproj

#Run operations on MSBUILD stuff.
RUN dotnet restore ./samples/DockerMultipleServices/Service/Service.csproj

#Copy in all the source, everything after this COPY will be run every time we run build, everything above is more cached.
COPY . .
RUN dotnet publish --no-restore -c Release -o /output ./samples/DockerMultipleServices/Service/

FROM microsoft/aspnetcore
EXPOSE 80
WORKDIR /app
COPY --from=build /output .
ENTRYPOINT ["dotnet", "Service.dll"]