using System.Globalization;

namespace DDDTemplate.Domain.Models
{
    public class GeoLocation
    {
        public double Latitude { get; }
        public double Longitude { get; }
        public GeoLocation(double latitude, double longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public override string ToString()
        {
            return $"({Latitude.ToString(CultureInfo.InvariantCulture)}, {Longitude.ToString(CultureInfo.InvariantCulture)})";
        }
    }
}
