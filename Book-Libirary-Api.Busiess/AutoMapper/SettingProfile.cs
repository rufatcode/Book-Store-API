using System;
using AutoMapper;
using Book_Libirary_Api.DTO.SettingDto;
using Book_Libirary_Api.Entities;

namespace Book_Libirary_Api.AutoMapper
{
	public class SettingProfile:Profile
	{
		public SettingProfile()
		{
			CreateMap<Setting, CreateSettingDto>().ReverseMap();
			CreateMap<Setting, UpdateSettingDto>().ReverseMap();
			CreateMap<Setting, GetSettingDto>().ReverseMap();
			CreateMap<Setting, GetSettingDtoByAdmin>().ReverseMap();
        }
	}
}

