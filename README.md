# AIM-Geocaching-Backend
Geocaching is an outdoor activity where participants use a GPS receiver or mobile device to locate “caches” which are usually weather resistant containers with various objects hidden inside. Upon finding a cache, the participant records the find online, or signs a logbook that is sometimes kept in the cache. This repo contains the backend of a web based mobile application for a subset of the traditional geocaching experience.

# Features
View caches location markers on the Google map, particularly in the local area.

# Prerequisites
Visual Studio - Download at https://visualstudio.microsoft.com/downloads/

# Installation
1. Clone the repository: git clone https://github.com/ashwarya177/AIM-Geocaching-Backend.git
2. Navigate to the project directory: cd Aim-Geocaching-Backend
3. Restore dependencies: dotnet restore
4. Build the project: dotnet build

# Usage 
Run or start the .NET Core API:

1. Run the project locally: dotnet run
2. The APIs will be accessible at: https://localhost:7159/swagger/index.html 

# API Endpoints
GET /api/CacheLocation:  Retrieve a list of the top 20 Cache Locations based on the Map Bounds (if provided) otherwise return any top 20 cache locations.

Request: 

URL: "https://localhost:7159/api/CacheLocation?latSW=VALUE&lonSW=VALUE&latNE=VALUE&lonNE=VALUE"
  
  (where latSW corresponds to Latitude Southwest, lonNE corresponds to Longitude Northeast & so on, in the Google Map embedded on the UI.)
  
Eg.: https://localhost:7159/api/CacheLocation?latSW=47.56563091063401&lonSW=-122.31515977695311&latNE=47.65821111569607&lonNE=-121.97183702304686

# Configuration
/aim.geocaches.gpx in the project directory is the file that contains all cache location waypoints.







