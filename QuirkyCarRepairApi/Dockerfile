# syntax=docker/dockerfile:1

# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build-env
WORKDIR /app

# Copy and restore QuirkyCarRepair.API.csproj
COPY QuirkyCarRepair.API/QuirkyCarRepair.API.csproj ./QuirkyCarRepair.API/
RUN dotnet restore QuirkyCarRepair.API/QuirkyCarRepair.API.csproj

# Copy and publish QuirkyCarRepair.BLL.csproj
COPY QuirkyCarRepair.BLL/QuirkyCarRepair.BLL.csproj ./QuirkyCarRepair.BLL/
RUN dotnet restore QuirkyCarRepair.BLL/QuirkyCarRepair.BLL.csproj

# Copy and publish QuirkyCarRepair.DAL.csproj
COPY QuirkyCarRepair.DAL/QuirkyCarRepair.DAL.csproj ./QuirkyCarRepair.DAL/
RUN dotnet restore QuirkyCarRepair.DAL/QuirkyCarRepair.DAL.csproj

# Copy and publish QuirkyCarRepair.Tests.csproj
COPY QuirkyCarRepair.Tests/QuirkyCarRepair.Tests.csproj ./QuirkyCarRepair.Tests/
RUN dotnet restore QuirkyCarRepair.Tests/QuirkyCarRepair.Tests.csproj

# Copy the entire solution and build
COPY . ./
RUN dotnet publish QuirkyCarRepair.API/QuirkyCarRepair.API.csproj -c Release -o /publish

# Stage 2: Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "QuirkyCarRepair.API.dll"]