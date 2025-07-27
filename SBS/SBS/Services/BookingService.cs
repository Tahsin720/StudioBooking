using LanguageExt.Common;
using SBS.DataAccess.Interfaces;
using SBS.Domain.Entities;
using SBS.Models.DTOS.BookingDtos;
using SBS.Services.Interfaces;

namespace SBS.Services
{
    public class BookingService : Service<Booking, int>, IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Result<bool>> AddAsync(CreateBookingDto model)
        {
            var booking = new Booking
            {
                StudioId = model.StudioId,
                Email = model.Email,
                Date = model.Date,
                TimeSlot = model.TimeSlot,
                UserName = model.UserName
            };
            return await _bookingRepository.AddAsync(booking);
        }
    }
}
