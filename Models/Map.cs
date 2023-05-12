using System;
namespace AIM_Geocaching_Backend.Models
{
	public class Map
	{
	    public double LatitudeBoundSW { get; private set; }
	    public double LongitudeBoundSW { get; private set; }
	    public double LatitudeBoundNE { get; private set; }
	    public double LongitudeBoundNE { get; private set; }

		public Map(string ?latSW, string ?lonSW, string ?latNE, string ?lonNE)
		{
		    this.LatitudeBoundSW = latSW != "" ? Convert.ToDouble(latSW) : 0;
		    this.LongitudeBoundSW = lonSW != "" ? Convert.ToDouble(lonSW) : 0;
		    this.LatitudeBoundNE = latNE != "" ? Convert.ToDouble(latNE) : 0 ;
		    this.LongitudeBoundNE = lonNE != "" ? Convert.ToDouble(lonNE) : 0;
		}

		public bool Contains(string lat, string lon)
		{
		    if (LatitudeBoundSW == 0 || LongitudeBoundSW == 0 || LatitudeBoundNE == 0 || LongitudeBoundNE == 0)
			return true;

		    double wpLat = Convert.ToDouble(lat);
		    double wpLon = Convert.ToDouble(lon);

		    return (wpLat >= LatitudeBoundSW && wpLat <= LatitudeBoundNE && wpLon >= LongitudeBoundSW && wpLon <= LongitudeBoundNE);
		}
	}
}

