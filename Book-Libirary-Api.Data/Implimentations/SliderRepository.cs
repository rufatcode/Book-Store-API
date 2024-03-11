using System;
using Book_Libirary_Api.Core.Repositories;
using Book_Libirary_Api.DTO;
using Book_Libirary_Api.Entities;

namespace Book_Libirary_Api.Data.Implimentations
{
	public class SliderRepository:Repository<Slider>,ISliderRepository
	{

		public SliderRepository(DataContext dataContext):base(dataContext)
		{
		}
	}
}

