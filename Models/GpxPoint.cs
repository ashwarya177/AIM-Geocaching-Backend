namespace AIM_Geocaching_Backend.Models
{
    public class GpxPoint
    {
        public double ?Latitude { get; set; }
        public double ?Longitude { get; set; }
        public string ?Name { get; set; }
        public string ?Hash { get; set; }

        public GpxPoint(string lat, string lon, string name, string hash)
        {
            this.Latitude = Convert.ToDouble(lat);
            this.Longitude = Convert.ToDouble(lon);
            this.Name = name;
            this.Hash = hash;
        }
    }
}