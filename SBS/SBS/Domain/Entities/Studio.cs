namespace SBS.Domain.Entities
{
    public class Studio
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Location { get; set; }
        public required string Amenities { get; set; }
        public required decimal PricePerHour { get; set; }
        public decimal? Rating { get; set; }
        public required string Area { get; set; }
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public required int RadiusKm { get; set; }
    }
}
