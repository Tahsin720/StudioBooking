using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBS.Models.Common;
using SBS.Services.Interfaces;
using SBS.Utilities.Exceptions;

namespace SBS.Controllers
{
    [Route("api/studios/")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly IStudioService _studioService;
        public StudioController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetStudios()
        {
            var result = await _studioService.ListAsync();
            return result.Match(
                data => Ok(new ApiResponse(data)),
                error => error.HandleError()
            );
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetDetails(int id)
        {
            var result = await _studioService.GetByIdAsync(id);
            return result.Match(
                data => Ok(new ApiResponse(data)),
                error => error.HandleError()
            );
        }

        [HttpGet("search")]
        public async Task<ActionResult<ApiResponse>> SearchByStudioArea(string area)
        {
            var result = await _studioService.ListAsync(studio => studio.Area == area);
            return result.Match(
                data => Ok(new ApiResponse(data)),
                error => error.HandleError()
            );
        }

        [HttpGet("nearby")]
        public async Task<ActionResult<ApiResponse>> SearchByStudioArea(decimal lat, decimal lng, decimal radius)
        {
            var result = await _studioService.ListAsync(studio => studio.Latitude == lat && studio.Longitude == lng && studio.RadiusKm == radius);
            return result.Match(
                data => Ok(new ApiResponse(data)),
                error => error.HandleError()
            );
        }

    }
}
