using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.HotelServices.Contracts;
using AutoMapper;
using HotelBooking.Dtos.Command;
using CoreModel.Entities.Bookings;
using CoreModel.Entities.Guests;
using Service.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IGuestService _guestService;
        private readonly IMapper _mapper;
        public RoomController(
            IRoomService roomService,
            IGuestService guestService,
            IMapper mapper)
        {
            _roomService = roomService;
            _guestService = guestService;
            _mapper = mapper;
        }
        // GET: api/<RoomController>
        [HttpGet("{index}/{size}")]
        public async Task<IActionResult> GetAllRoomPaginated(int index, int size)
        {
            var result = await _roomService.GetAllAsQueryable().ToPagedListAsync(index, size, (a => a.Capacity));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var result = await _roomService.GetRoomDataList();
            return Ok(result);
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomCreate roomCreate)
        {
            var room = _mapper.Map<Room>(roomCreate);
            var isExist = _roomService.GetAllAsQueryable().Any(a => a.RoomNumber == roomCreate.RoomNumber);
            if (!isExist)
            {
                var result = await _roomService.CreateAsync(room);
                return Ok(result);
            }
            return BadRequest("Invalid operation");
        }

        [HttpPost("guest")]
        public async Task<IActionResult> CreateGuest([FromBody] CreateGuest createGuest)
        {
            var guest = _mapper.Map<Guest>(createGuest);
            var result = await _guestService.CreateAsync(guest);
            return Ok(result);
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRoom(long id, [FromBody] RoomCreate roomUpdate)
        {
            var room = await _roomService.GetASync(id);

            room.RoomNumber = roomUpdate.RoomNumber;
            room.Rent = roomUpdate.Rent;
            room.Capacity = roomUpdate.Capacity;

            var result = await _roomService.UpdateAsync(room);
            return Ok(result);
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _roomService.DeleteAsycn(id);
        }
    }
}
