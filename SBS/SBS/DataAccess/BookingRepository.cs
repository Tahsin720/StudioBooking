using SBS.DataAccess.Interfaces;
using SBS.Domain.Database;
using SBS.Domain.Entities;

namespace SBS.DataAccess
{
    public class BookingRepository : Repository<Booking, int>, IBookingRepository
    {
        private readonly AppDbContext _db;
        public BookingRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
