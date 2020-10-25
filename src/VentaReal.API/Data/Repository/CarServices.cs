using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VentaReal.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace VentaReal.API.Data.Services
{
    public class Carservices : ICarServices
    {
        private VentaRealContext _dbcontext;

        public Carservices(VentaRealContext ventaRealContext)
        {
            _dbcontext = ventaRealContext;
        }

        public async Task AddCar(Car car)  {

             _dbcontext.Cars.Add(car);

            await SaveAsyncChange();

        }

        public async Task DeleteCar(int Id)
        {

            var car = await GetCar(Id);

            _dbcontext.Cars.Remove(car);

            _dbcontext.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            await SaveAsyncChange();

         }

        public async Task<IEnumerable<Car>> GetAllCar()
        {
            return await _dbcontext.Cars.ToListAsync();
        }

        public async Task<Car> GetCar(int Id)
        {
            return  await _dbcontext.Cars.FindAsync( Id );
        }

        public async Task<int> SaveAsyncChange() {

            return await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateCar(Car car) {
            _dbcontext.Cars.Update(car);

            _dbcontext.Entry(car).State = EntityState.Modified;

            await SaveAsyncChange();
        }
    }
}
