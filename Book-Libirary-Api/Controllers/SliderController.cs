using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book_Libirary_Api.DTO;
using Book_Libirary_Api.DTO.SliderDto;
using Book_Libirary_Api.Entities;
using Book_Libirary_Api.Interfaces;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Libirary_Api.Controllers
{
    [Route("api/[controller]")]
    public class SliderController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IFileService _fileService;

        public SliderController(DataContext dataContext,IMapper mapper,IPhotoAccessor photoAccessor,IFileService fileService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _photoAccessor = photoAccessor;
            _fileService = fileService;
        }
        [HttpPost]
        public async Task<IActionResult>Post(CreateSliderDto createSliderDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                else if (!_fileService.IsImage(createSliderDto.Img)) return BadRequest("please enter image");
                else if (!_fileService.LengthIsSuitable(createSliderDto.Img, 1000)) return BadRequest("image length is greater than 1 kb");
                else if (await _dataContext.Sliders.AnyAsync(s => s.Title.ToLower().Trim() == createSliderDto.Title.ToLower().Trim())) return BadRequest("this slider is exist");
                Slider slider =_mapper.Map<Slider>(createSliderDto);
                ImageUploadResult imageResoult = await _photoAccessor.AddPhoto(createSliderDto.Img);
                slider.PublicId = imageResoult.PublicId;
                slider.ImgUrl = imageResoult.SecureUrl.ToString();

                await _dataContext.Sliders.AddAsync(slider);
                await _dataContext.SaveChangesAsync();
                return Ok($"{createSliderDto.Title} successfully created");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Slider> sliders = await _dataContext.Sliders.Where(s => !s.IsDeleted).ToListAsync();
            if (sliders.Count == 0) return NotFound("empty slider list");
            return Ok(_mapper.Map<List<GetSliderDto>>(sliders));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            try
            {
                if (id == null) return BadRequest("something went wrong");
                else if (!await _dataContext.Sliders.AnyAsync(s => s.Id == id && !s.IsDeleted)) return NotFound("this slider is not exist");
                Slider slider = await _dataContext.Sliders.FirstOrDefaultAsync(s => s.Id == id);
                return Ok(_mapper.Map<GetSliderDto>(slider));
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
                List<Slider> sliders = await _dataContext.Sliders.ToListAsync();
                if (sliders.Count == 0) return NotFound("empty slider list");
                return Ok(_mapper.Map<List<GetSliderDto>>(sliders));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetByAdmin/{id}")]
        public async Task<IActionResult>GetByAdmin(int id)
        {
            try
            {
                if (id == null) return BadRequest("something went wrong");
                else if (!await _dataContext.Sliders.AnyAsync(s => s.Id == id)) return NotFound("slider is not exist");
                Slider slider = await _dataContext.Sliders.FirstOrDefaultAsync(s => s.Id == id);
                return Ok(_mapper.Map<GetSliderDto>(slider));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}

