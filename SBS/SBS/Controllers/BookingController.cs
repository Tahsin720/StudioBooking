using Microsoft.AspNetCore.Mvc;
using SBS.Models.Common;
using SBS.Models.DTOS.BookingDtos;
using SBS.Services.Interfaces;
using SBS.Utilities.Exceptions;

namespace SBS.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IStudioService _studioService;
        public BookingController(IBookingService bookingService, IStudioService studioService)
        {
            _bookingService = bookingService;
            _studioService = studioService;
        }

        [HttpPost("bookings")]
        public async Task<ActionResult<ApiResponse>> CreateBooking([FromBody] CreateBookingDto model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
                var errorMessage = string.Join(", ", errors);
                return BadRequest(new ApiResponse($"Validation failed: {errorMessage}"));
            }
            var result = await _bookingService.AddAsync(model);
            return result.Match(
                success => Ok(new ApiResponse("Booking created successfully.")),
                error => error.HandleError()
            );
        }

        [HttpGet("bookings")]
        public async Task<ActionResult<ApiResponse>> GetBookings()
        {
            var result = await _bookingService.ListAsync();
            return result.Match(
                data => Ok(new ApiResponse(data)),
                error => error.HandleError()
            );
        }

        [HttpGet("studios/{id}/availability")]
        public async Task<ActionResult<ApiResponse>> GetStudioAvailability(int id, [FromQuery] DateTime date)
        {
            // Validate input
            if (id <= 0)
            {
                return BadRequest(new ApiResponse("Invalid StudioId."));
            }
            if (date < DateTime.Today)
            {
                return BadRequest(new ApiResponse("Date cannot be in the past."));
            }

            var bookedSlotsResult = await _bookingService.GetAsync(b => b.StudioId == id && b.Date.Date == date.Date);
            var possibleSlots = GeneratePossibleTimeSlots();

            var bookedSlot = bookedSlotsResult.Match(
                r => r?.TimeSlot,
                ex => null
            );

            var availableSlots = bookedSlot is null
                ? possibleSlots
                : possibleSlots.Except(new[] { bookedSlot }).ToList();

            return Ok(new ApiResponse
            {
                Message = "Available time slots retrieved successfully.",
                Data = availableSlots
            });
        }

        private List<string> GeneratePossibleTimeSlots()
        {
            var slots = new List<string>();
            for (int hour = 9; hour <= 18; hour++) // 9:00 AM to 6:00 PM
            {
                string startTime = hour.ToString("D2") + ":00";
                string endTime = hour.ToString("D2") + ":59";
                slots.Add($"{startTime}-{endTime}");
            }
            return slots;
        }
    }
}
