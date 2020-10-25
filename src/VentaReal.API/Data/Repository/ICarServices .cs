using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VentaReal.API.Entities;

namespace VentaReal.API.Data.Services
{
    public interface ICarServices
    {
        Task AddCar(Car car);

        Task<Car> GetCar(int Id);

        Task<IEnumerable<Car>> GetAllCar();

        Task DeleteCar(int id);

        Task UpdateCar(Car car);

        Task<int> SaveAsyncChange();
    }
}
