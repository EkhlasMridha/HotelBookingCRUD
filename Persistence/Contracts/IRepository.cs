using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistence.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public void Insert(TEntity entity);
        public Task InsertAsync(TEntity entity);
        public void InsertRange(IEnumerable<TEntity> entities);
        public Task InsertRangeAsync(IEnumerable<TEntity> entities);
        public void Update(TEntity entity);
        public void UpdateRange(IEnumerable<TEntity> entities);
        public void Delete(TEntity entity);
        public void DeleteRange(IEnumerable<TEntity> entity);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public TEntity GetById(long Id);
        public Task<TEntity> GetByIdAsync(long Id);

        public IQueryable<TEntity> AsQueryable();

        public Task<DataTable> ExecuteSqlDataReader(string name, List<SqlParameter> sqlParameters);
    }
}
