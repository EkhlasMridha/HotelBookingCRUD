using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contracts
{
    public interface IUnitOfWork
    {
        public void BeginTransaction();
        public Task BeginTransactionAsync();

        public Task SaveChangesAsync();

        public Task CommitAsync();

        public void Commit();

        public void Rollback();

        public Task RollbackASync();

        public DbContext GetContext();

        public void Dispose();

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
