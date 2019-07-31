FROM microsoft/dotnet:2.1-sdk

WORKDIR /app

# resolve dependencies first as a separate layer to make rebuilding quicker
COPY /csharpcore.csproj /app/
RUN ["dotnet", "restore"]

# copy all source code and run the project
COPY / /app/
ENTRYPOINT ["dotnet", "run"]
