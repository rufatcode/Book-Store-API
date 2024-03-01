using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book_Libirary_Api.DTO;
using Book_Libirary_Api.DTO.SettingDto;
using Book_Libirary_Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Libirary_Api.Controllers
{
    [Route("api/[controller]")]
    public class SettingController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public SettingController(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateSettingDto createSettingDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Setting setting = _mapper.Map<Setting>(createSettingDto);
                await _dataContext.Settings.AddAsync(setting);
                await _dataContext.SaveChangesAsync();
                return Ok($"{createSettingDto.Key} successfully created");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                if (id == null) return BadRequest();
                else if (!await _dataContext.Settings.AnyAsync(s => s.Id == id && !s.IsDeleted)) return NotFound("setting is not exist");
                Setting setting =await _dataContext.Settings.FirstOrDefaultAsync(s => s.Id == id);
                setting.IsDeleted = true;
                setting.DeletedAt = DateTime.UtcNow.AddHours(4);
                await _dataContext.SaveChangesAsync();
                return Ok($"{setting.Key} successfully deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Setting> settings = await _dataContext.Settings.Where(s => !s.IsDeleted).ToListAsync();
                if (settings.Count == 0) return NotFound("empty list");
                return Ok(_mapper.Map<List<GetSettingDto>>(settings));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetByAdmin")]
        public async Task<IActionResult> GetByAdmin()
        {
            try
            {
                List<Setting> settings = await _dataContext.Settings.ToListAsync();
                if (settings.Count == 0) return NotFound("empty list");
                return Ok(_mapper.Map<List<GetSettingDtoByAdmin>>(settings));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            try
            {
                if (id == null) return BadRequest();
                else if (!await _dataContext.Settings.AnyAsync(s => s.Id == id && !s.IsDeleted)) return NotFound("not exist");
                Setting setting = await _dataContext.Settings.FirstOrDefaultAsync(s => s.Id == id);
                return Ok(_mapper.Map<GetSettingDto>(setting));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetByAdmin/{id}")]
        public async Task<IActionResult> GetByAdmin(int id)
        {
            try
            {
                if (id == null) return BadRequest();
                else if (!await _dataContext.Settings.AnyAsync(s => s.Id == id)) return NotFound("not exist");
                Setting setting = await _dataContext.Settings.FirstOrDefaultAsync(s => s.Id == id);
                return Ok(_mapper.Map<GetSettingDtoByAdmin>(setting));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id,UpdateSettingDto updateSettingDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                else if (id == null) return BadRequest();

                Setting setting =await _dataContext.Settings.FirstOrDefaultAsync(s => s.Id == id);
                _mapper.Map(updateSettingDto, setting);
                if (updateSettingDto.IsDeleted)
                {
                    setting.DeletedAt = DateTime.UtcNow.AddHours(4);
                }
                else
                {
                    setting.DeletedAt = null;
                }
                await _dataContext.SaveChangesAsync();
                return Ok($"{setting.Key} successfully updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

