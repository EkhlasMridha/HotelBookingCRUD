using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HotelServices.Contracts
{
    public interface IBaseService<T> where T:class
    {
        public Task<Type> CreateAsync(Type type);
        public Task<Type> GetASync(long id);
        public Task<IEnumerable<Type>> GetAllAsync();

        public IQueryable<Type> GetAllAsQueryable();
    }
}
