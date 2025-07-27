using LanguageExt;
using LanguageExt.Common;
using SBS.Domain.Entities;
using SBS.Models.DTOS.BookingDtos;

namespace SBS.Services.Interfaces
{
    public interface IBookingService : IService<Booking, int>
    {
        Task<Result<bool>> AddAsync(CreateBookingDto model);
    }
}
