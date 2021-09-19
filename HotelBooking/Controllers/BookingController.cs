using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Dtos.Command;
using AutoMapper;
using CoreModel.Entities.Bookings;
using Service.HotelServices.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        private IMapper _mapper;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingService.GetAllBookings();
            return Ok(result);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBooking createBooking)
        {
            var booking = _mapper.Map<BookingDetails>(createBooking);
            var result = await _bookingService.CreateBookingDataAsync(booking, createBooking.RoomId);
            return Ok(result);
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(long id, [FromBody] CreateBooking createBooking)
        {

            var booking = _mapper.Map<BookingViewModel>(createBooking);
            await _bookingService.UpdateBookingAsync(booking, id);
            return Ok(booking);
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _bookingService.DeleteAsycn(id);
        }
    }
}
