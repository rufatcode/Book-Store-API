using System;
using AutoMapper;
using Book_Libirary_Api.DTO.SliderDto;
using Book_Libirary_Api.Entities;

namespace Book_Libirary_Api.AutoMapper
{
	public class SliderProfile:Profile
	{
		public SliderProfile()
		{
			CreateMap<Slider, CreateSliderDto>().ReverseMap() ;
			CreateMap<Slider, UpdateSliderDto>().ReverseMap();
			CreateMap<Slider, GetSliderDto>().ReverseMap();
        }
	}
}

