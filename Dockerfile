#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install Git
RUN apt-get update && apt-get install -y git

# Clone the repository
RUN git clone https://github.com/ashwarya177/AIM-Geocaching-Backend.git .

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AIM-Geocaching-Backend.csproj", "."]
RUN dotnet restore "./AIM-Geocaching-Backend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AIM-Geocaching-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AIM-Geocaching-Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AIM-Geocaching-Backend.dll"]
