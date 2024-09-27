# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY ./*.csproj ./
RUN dotnet restore

# Copy the rest of the application files
COPY . ./

# Build and publish the application in Debug mode
RUN dotnet build -c Debug -o /app/build \
    && dotnet publish -c Debug -o /app/publish

# Use the official .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Set environment variable for ASP.NET Core
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose the port the app runs on
EXPOSE 5248

# Specify the command to run the application
ENTRYPOINT ["dotnet", "PokeMonAPi.dll"]
