using Microsoft.EntityFrameworkCore;
using SBS.Domain.Entities;

namespace SBS.Domain.ContextEntension
{
    public static class ContextEntensions
    {
        public static void Seeds(this ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Studio>().HasData(
                new Studio { Id = 1, Name = "Studio A", Type = "Recording", Location = "Downtown, City A", Amenities = "Microphones, Soundproofing", PricePerHour = 50.00m, Rating = 4.5m, Area = "Central", Latitude = 40.7128m, Longitude = -74.0060m, RadiusKm = 10 },
                new Studio { Id = 2, Name = "Studio B", Type = "Photography", Location = "Westside, City B", Amenities = "Lighting, Backdrops", PricePerHour = 30.00m, Rating = 4.0m, Area = "Western", Latitude = 34.0522m, Longitude = -118.2437m, RadiusKm = 15 },
                new Studio { Id = 3, Name = "Studio C", Type = "Video", Location = "Eastside, City A", Amenities = "Cameras, Green Screen", PricePerHour = 70.00m, Rating = 4.8m, Area = "Eastern", Latitude = 41.8781m, Longitude = -87.6298m, RadiusKm = 20 }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, StudioId = 1, UserName = "John Doe", Email = "john.doe@email.com", Date = new DateTime(2025, 7, 28), TimeSlot = "10:00-12:00" },
                new Booking { Id = 2, StudioId = 2, UserName = "Jane Smith", Email = "jane.smith@email.com", Date = new DateTime(2025, 7, 29), TimeSlot = "14:00-16:00" }
            );
        }
    }
}
