using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.HotelServices.Contracts;
using Service.HotelServices;
using Persistence.Contracts;

namespace Service.HotelServices
{
    class BaseService<T> : IBaseService<T> where T:class
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Type> CreateAsync(Type type)
        {
            await _unitOfWork.Repository<Type>().InsertAsync(type);
            await _unitOfWork.SaveChangesAsync();
            return type;
        }

        public async Task<Type> GetASync(long id)
        {
            var result = await _unitOfWork.Repository<Type>().GetByIdAsync(id);
            return result;
        }

        public async Task<IEnumerable<Type>> GetAllAsync()
        {
            var result = await _unitOfWork.Repository<Type>().GetAllAsync();
            return result;
        }

        public IQueryable<Type> GetAllAsQueryable()
        {
            return _unitOfWork.Repository<Type>().AsQueryable();
        }

        #region dispose
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDispose)
        {
            if (isDispose)
            {
                _unitOfWork?.Dispose();
            }
        }
    }
}
