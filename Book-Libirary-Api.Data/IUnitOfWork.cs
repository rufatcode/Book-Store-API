using System;
using Book_Libirary_Api.Core.Repositories;

namespace Book_Libirary_Api.Data
{
	public interface IUnitOfWork:IDisposable
	{
		ISliderRepository SliderRepository { get; }

		Task<int> Complate();

	}
}

