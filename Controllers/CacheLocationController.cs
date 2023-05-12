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
        queryParams.TryGetValue("latSW", out var latSW);
        queryParams.TryGetValue("lonSW", out var lonSW);
        queryParams.TryGetValue("latNE", out var latNE);
        queryParams.TryGetValue("lonNE", out var lonNE);
        
        ParseGPX parse = new ParseGPX("aim.geocaches.gpx");
        Map gmap = new Map(latSW, lonSW, latNE, lonNE);

        var cacheLocations = parse.LoadGPXWaypoints(gmap);

        return Ok(cacheLocations);
    }
}

