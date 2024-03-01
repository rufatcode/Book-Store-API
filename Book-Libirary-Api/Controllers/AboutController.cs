using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book_Libirary_Api.DTO;
using Book_Libirary_Api.DTO.AboutDto;
using Book_Libirary_Api.Entities;
using Book_Libirary_Api.Interfaces;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Libirary_Api.Controllers
{
    [Route("api/[controller]")]
    public class AboutController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IPhotoAccessor _photoAccessor;
        public AboutController(DataContext dataContext,IMapper mapper,IFileService fileService,IPhotoAccessor photoAccessor)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _fileService = fileService;
            _photoAccessor = photoAccessor;
        }
        [HttpPost]
        public async Task<IActionResult>Post(CreateAboutDto createAboutDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                else if (await _dataContext.Abouts.AnyAsync(a => a.Name.ToLower().Trim() == createAboutDto.Name.ToLower().Trim())) return BadRequest("has exist");
                else if (!_fileService.IsImage(createAboutDto.MainImage) || !_fileService.IsImage(createAboutDto.SubImage)) return BadRequest("not valid");
                else if (!_fileService.LengthIsSuitable(createAboutDto.MainImage, 1000) || !_fileService.LengthIsSuitable(createAboutDto.SubImage, 1000)) return BadRequest("not valid");
                About about = _mapper.Map<About>(createAboutDto);
                ImageUploadResult mainResoult =await _photoAccessor.AddPhoto(createAboutDto.MainImage);
                about.MainImageUrl = mainResoult.SecureUrl.ToString();
                about.MainPublicId = mainResoult.PublicId;
                ImageUploadResult subResoult = await _photoAccessor.AddPhoto(createAboutDto.SubImage);
                about.SubImageUrl = subResoult.SecureUrl.ToString();
                about.SubPublicId = subResoult.PublicId;
                await _dataContext.Abouts.AddAsync(about);
                await _dataContext.SaveChangesAsync();
                return Ok($"{createAboutDto.Name} successfully created");
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
                else if (!await _dataContext.Abouts.AnyAsync(a => a.Id == id && !a.IsDeleted)) return BadRequest("is exist");
                About about = await _dataContext.Abouts.FirstOrDefaultAsync(a => a.Id == id);
                about.IsDeleted = true;
                about.DeletedAt = DateTime.UtcNow.AddHours(4);
                await _dataContext.SaveChangesAsync();
                return Ok($"{about.Name} successfully deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

