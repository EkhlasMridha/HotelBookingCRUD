using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HotelServices.Contracts
{
    public interface IBaseService<T> where T:class
    {
        public Task<T> CreateAsync(T type);
        public Task<T> UpdateAsync(T type);
        public Task<T> GetASync(long id);
        public Task<T> DeleteAsycn(long id);
        public Task<IEnumerable<T>> GetAllAsync();

        public IQueryable<T> GetAllAsQueryable();
    }
}
