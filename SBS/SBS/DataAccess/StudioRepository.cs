using SBS.DataAccess.Interfaces;
using SBS.Domain.Database;
using SBS.Domain.Entities;

namespace SBS.DataAccess
{
    public class StudioRepository : Repository<Studio, int>, IStudioRepository
    {
        private readonly AppDbContext _db;
        public StudioRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
