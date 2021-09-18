using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Service.HotelServices.Contracts;
using CoreModel.Entities.Settings;
using HotelBooking.Dtos.Command;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private IMapper _mapper;
        private ISettingService _settingService;
        public SettingController(IMapper mapper, ISettingService settingService)
        {
            _settingService = settingService;
            _mapper = mapper;
        }

        // GET api/<SettingController>/5
        [HttpGet]
        public async Task<IActionResult> GetSetting()
        {
            var result = _settingService.GetAllAsQueryable().FirstOrDefault();
            return Ok(result);
        }

        // POST api/<SettingController>
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateSettings([FromBody] SettingCommand settingCommand)
        {
            var setting = _mapper.Map<BookingSetting>(settingCommand);
            BookingSetting entity = null;
            if(setting.Id == 0)
            {
                entity = _settingService.GetAllAsQueryable().FirstOrDefault();
            }
            BookingSetting result = null;
            if(entity == null && setting.Id == 0)
            {
               result = await _settingService.CreateAsync(setting);
            }
            else if(setting.Id != 0)
            {
                result = await _settingService.UpdateAsync(setting);
            }
            else
            {
                entity.Discount = setting.Discount;
                entity.TaxPercentage = setting.TaxPercentage;
                result = await _settingService.UpdateAsync(entity);
            }

            return Ok(result);
        }

        // PUT api/<SettingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SettingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
