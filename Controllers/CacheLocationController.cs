using AIM_Geocaching_Backend.Models;
using AIM_Geocaching_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIM_Geocaching_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CacheLocationController : ControllerBase
{
    private readonly ILogger<CacheLocationController> _logger;

    public CacheLocationController(ILogger<CacheLocationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCacheLocation")]
    public IActionResult Get()
    {
        var queryParams = HttpContext.Request.Query;
        queryParams.TryGetValue("lat", out var latitude);
        queryParams.TryGetValue("lon", out var longitude);

        // Currently the code does not make use of user's current location params
        // latitude, longitude provided in Query String.
        // However, we can add logic based on the user's current location
        // to show only nearby caches.
        
        ParseGPX parse = new ParseGPX("aim.geocaches.gpx");
        var cacheLocations = parse.LoadGPXWaypoints();

        return Ok(cacheLocations);
    }
}

