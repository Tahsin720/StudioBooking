namespace SBS.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public required int StudioId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required DateTime Date { get; set; }
        public required string TimeSlot { get; set; }
        public Studio Studios { get; set; }
    }
}
