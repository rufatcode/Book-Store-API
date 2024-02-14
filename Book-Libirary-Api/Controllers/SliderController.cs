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
        private readonly IFileService _fileService;
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IMapper _mapper;  //map ucun isdifate edilecek
        public SliderController(DataContext dataContext,IFileService fileService,IPhotoAccessor photoAccessor,IMapper mapper)
        {
            _dataContext = dataContext;
            _fileService = fileService;
            _photoAccessor = photoAccessor;
            _mapper = mapper;

        }
        // GET: api/value
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Slider> sliders = await _dataContext.Sliders.AsNoTracking().Where(s => !s.IsDeleted).ToListAsync();
            if (sliders.Count == 0) return NotFound("Empty slider list");
            return Ok(_mapper.Map<List<GetSliderDto>>(sliders));
        }
        [HttpGet("GetByAdmin")]
        public async Task<IActionResult> GetByAdmin()
        {
            List<Slider> sliders = await _dataContext.Sliders.AsNoTracking().ToListAsync();
            if (sliders.Count == 0) return NotFound("Empty slider list");
            return Ok(_mapper.Map<List<GetSliderDto>>(sliders));
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null) return BadRequest("something went wrong");
            else if (!await _dataContext.Sliders.AnyAsync(s => s.Id == id && !s.IsDeleted)) return NotFound("Slider is not exist");
            Slider slider = await _dataContext.Sliders.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            return Ok(_mapper.Map<GetSliderDto>(slider));
        }
        [HttpGet("GetByAdmin/{id}")]
        public async Task<IActionResult> GetByAdmin(int id)
        {
            if (id == null) return BadRequest("something went wrong");
            else if (!await _dataContext.Sliders.AnyAsync(s => s.Id == id)) return NotFound("Slider is not exist");
            Slider slider = await _dataContext.Sliders.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            return Ok(_mapper.Map<GetSliderDto>(slider));
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult>  Post(CreateSliderDto createSliderDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            else if (!_fileService.IsImage(createSliderDto.Img)) return BadRequest("Please Enter Image");
            else if (!_fileService.LengthIsSuitable(createSliderDto.Img, 1000)) return BadRequest("Image size must be smaller than 1kb");
            else if (await _dataContext.Sliders.AnyAsync(s => s.Title.ToLower() == createSliderDto.Title.ToLower())) return BadRequest("this slider is exist");
            Slider slider = _mapper.Map<Slider>(createSliderDto);
            ImageUploadResult imageUploadResult = await _photoAccessor.AddPhoto(createSliderDto.Img);
            slider.PublicId = imageUploadResult.PublicId;
            slider.ImgUrl = imageUploadResult.SecureUrl.ToString();
            await _dataContext.Sliders.AddAsync(slider);
            await _dataContext.SaveChangesAsync();
            return Ok($"{createSliderDto.Title} successfully created");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSliderDto updateSliderDto)
        {
            if (id == null) return BadRequest("Something went wrong");
            else if (!await _dataContext.Sliders.AnyAsync(s => s.Id == id)) return NotFound("Slider Is Not exist");
            if (updateSliderDto.Img!=null)
            {
                if (!_fileService.IsImage(updateSliderDto.Img)) return BadRequest("please enter image");
                else if (!_fileService.LengthIsSuitable(updateSliderDto.Img, 1000)) return BadRequest("Image size must be smaller than 1kb");

            }
            Slider slider = await _dataContext.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            _mapper.Map(updateSliderDto, slider);
            string oldPublicId = slider.PublicId;
            slider.UpdatedAt = DateTime.UtcNow.AddHours(4);
            if (updateSliderDto.IsDeleted)
            {
                slider.DeletedAt = DateTime.UtcNow.AddHours(4);
            }
            else
            {
                slider.DeletedAt = null;
            }

            if (updateSliderDto.Img!=null)
            {
                ImageUploadResult imageUploadResult = await _photoAccessor.AddPhoto(updateSliderDto.Img);
                slider.ImgUrl = imageUploadResult.SecureUrl.ToString();
                slider.PublicId = imageUploadResult.PublicId;
            }
            
            await _dataContext.SaveChangesAsync();
            if (oldPublicId!=slider.PublicId)
            {
                await _photoAccessor.DeletePhoto(oldPublicId);
            }
            return Ok($"{slider.Title} successfully updated");
            
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return BadRequest("Someghing went wrong");
            else if (!await _dataContext.Sliders.AnyAsync(s => s.Id == id && !s.IsDeleted)) return BadRequest("Slider is not exist");
            Slider slider = await _dataContext.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            slider.IsDeleted = true;
            slider.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _dataContext.SaveChangesAsync();

            return Ok($"{slider.Title} successfully deleted");
        }
    }
}

