namespace SBS.Models.DTOS.BookingDtos
{
    public class CreateBookingDto
    {
        public required int StudioId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required DateTime Date { get; set; }
        public required string TimeSlot { get; set; }
    }
}
