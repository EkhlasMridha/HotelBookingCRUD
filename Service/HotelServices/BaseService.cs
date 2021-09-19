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

        public async Task<T> CreateAsync(T type)
        {
            await _unitOfWork.Repository<T>().InsertAsync(type);
            await _unitOfWork.SaveChangesAsync();
            return type;  
        }

        public async Task<T> GetASync(long id)
        {
            var result = await _unitOfWork.Repository<T>().GetByIdAsync(id);
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _unitOfWork.Repository<T>().GetAllAsync();
            return result;
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _unitOfWork.Repository<T>().AsQueryable();
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

        public async Task<T> UpdateAsync(T type)
        {
            await Task.Run(() => _unitOfWork.Repository<T>().Update(type));
            await _unitOfWork.SaveChangesAsync();
            return type;
        }

        public async Task<T> DeleteAsycn(long id)
        {
            var data = await GetASync(id);
            _unitOfWork.Repository<T>().Delete(data);
            await _unitOfWork.SaveChangesAsync();
            return data;
        }
        #endregion
    }
}
