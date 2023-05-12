using System;
using System.Xml.Linq;
using AIM_Geocaching_Backend.Models;

namespace AIM_Geocaching_Backend.Services
{
    public class ParseGPX
    {
    private string fileName;

        public ParseGPX(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<GpxPoint> LoadGPXWaypoints(Map gmap)
        {
            
            XElement gpxDoc = GetGpxDoc();

            var waypoints = gpxDoc.Descendants("wpt")
                // Take only top 20 waypoints that are within map bounds.
                .Where(x => gmap.Contains(x.Attribute("lat")?.Value, x.Attribute("lon")?.Value))
                .Take(20)
                .Select(wp => new GpxPoint(
                    wp.Attribute("lat")?.Value,
                    wp.Attribute("lon")?.Value,
                    wp.Element("name")?.Value,
                    wp.Element("hash")?.Value
                ));

            return waypoints;
        }

        private XElement GetGpxDoc()
        {
            XElement gpxDoc = XElement.Load(fileName);
            return gpxDoc;
        }
    }
}

