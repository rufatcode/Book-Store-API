using System;
using AutoMapper;
using Book_Libirary_Api.DTO.AboutDto;
using Book_Libirary_Api.Entities;

namespace Book_Libirary_Api.AutoMapper
{
	public class AboutProfile:Profile
	{
		public AboutProfile()
		{
			CreateMap<About, CreateAboutDto>().ReverseMap();
			CreateMap<About, UpdateAboutDto>().ReverseMap();
			CreateMap<About, GetAboutByAdminDto>().ReverseMap();
			CreateMap<About, GetAboutDto>().ReverseMap();
        }
	}
}

