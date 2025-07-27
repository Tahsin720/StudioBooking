using SBS.DataAccess.Interfaces;
using SBS.Domain.Entities;
using SBS.Services.Interfaces;

namespace SBS.Services
{
    public class StudioService : Service<Studio, int>, IStudioService
    {   
        private readonly IStudioRepository _studioRepository;
        public StudioService(IStudioRepository studioRepository) : base(studioRepository)
        {
            _studioRepository = studioRepository;
        }
    }
}
