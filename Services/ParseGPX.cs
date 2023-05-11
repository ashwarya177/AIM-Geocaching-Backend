using System;
using System.Xml.Linq;
using AIM_Geocaching_Backend.Models;

namespace AIM_Geocaching_Backend.Services{    public class ParseGPX    {    private string fileName;        public ParseGPX(string fileName)        {            this.fileName = fileName;        }        public IEnumerable<GpxPoint> LoadGPXWaypoints()        {            XElement gpxDoc = GetGpxDoc();            var waypoints = gpxDoc.Descendants("wpt")
                .Where(x => x.Attribute("lat") != null && x.Attribute("lon") != null)
                // Can apply logic here for deciding which Caches to show,                // while picking waypoints from GPX File.
                .Take(300)
                .Select(wp => new GpxPoint(
                    wp.Attribute("lat")?.Value,
                    wp.Attribute("lon")?.Value,
                    wp.Element("name")?.Value,
                    wp.Element("hash")?.Value
                ));            return waypoints;        }        private XElement GetGpxDoc()
        {
            XElement gpxDoc = XElement.Load(fileName);
            return gpxDoc;        }    }}