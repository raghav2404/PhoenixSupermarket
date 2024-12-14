# Use the official .NET SDK image for building the solution
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the solution and project files into the container
COPY ["demoMvcCore.sln", "./"]
COPY ["demoMvcCore/demoMvcCore.csproj", "demoMvcCore/"]
COPY ["UseCases/UseCases.csproj", "UseCases/"]
COPY ["Plugins.DataStore.SQL.csproj", "Plugins.DataStore.SQL/"]
COPY ["CoreBusiness/CoreBusiness.csproj", "CoreBusiness/"]

# Restore dependencies
RUN dotnet restore

# Copy all source files
COPY . .

# Build the application
RUN dotnet build --configuration Release

# Publish the application
RUN dotnet publish "demoMvcCore/demoMvcCore.csproj" --configuration Release --output /app/publish

# Use the .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Set the working directory in the container
WORKDIR /app

# Copy the published files from the build container
COPY --from=build /app/publish .

# Expose the port the app will run on
EXPOSE 80

# Set the entry point to start the MVC app
ENTRYPOINT ["dotnet", "demoMvcCore.dll"]
