using System;
using Book_Libirary_Api.Core.Repositories;
using Book_Libirary_Api.Data.Implimentations;
using Book_Libirary_Api.DTO;

namespace Book_Libirary_Api.Data
{
	public class UnitOfWork:IUnitOfWork
	{
        private readonly DataContext _dataContext;
		public UnitOfWork(DataContext dataContext)
		{
            _dataContext = dataContext;
            SliderRepository = new SliderRepository(dataContext);
		}

        public ISliderRepository SliderRepository { get; }



        public async Task<int> Complate()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _dataContext.DisposeAsync();
        }
    }
}

