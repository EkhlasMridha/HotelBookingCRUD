using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using CoreModel.Entities;

namespace Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable();
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public TEntity GetById(long Id)
        {
            return _entities.AsQueryable().FirstOrDefault(e => (e as BaseEntity).Id == Id);
        }

        public async Task<TEntity> GetByIdAsync(long Id)
        {
            return await _entities.AsQueryable().FirstOrDefaultAsync(e => (e as BaseEntity).Id == Id);
        }

        public void Insert(TEntity entity)
        {
            (entity as BaseEntity).CreatedAt = DateTime.Now;
            _entities.Add(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            try
            {
                (entity as BaseEntity).CreatedAt = DateTime.Now;
                await _entities.AddAsync(entity);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            var e = (entity as BaseEntity);
            if (e.Id == 0)
                throw new Exception("Can't update entity without a Id value");
            e.UpdatedAt = DateTime.Now;
            _entities.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if ((entity as BaseEntity).Id == 0)
                    throw new Exception("Can't update entoty without a Id value");

                (entity as BaseEntity).UpdatedAt = DateTime.Now;
            }
            _entities.UpdateRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await AsQueryable().ToListAsync();
            return entities;
        }

        public async Task<DataTable> ExecuteSqlDataReader(string name, List<SqlParameter> sqlParameters)
        {
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;

                if(sqlParameters.Count != 0)
                {
                    var spParam = command.CreateParameter();

                    foreach (var param in sqlParameters)
                    {
                        spParam.ParameterName = param.ParameterName;
                        spParam.Value = param.Value;
                    }
                    command.Parameters.Add(spParam);
                }
                

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var ent in entities)
            {
                (ent as BaseEntity).CreatedAt = DateTime.Now;
            }
            _entities.AddRange(entities);
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var ent in entities)
            {
                (ent as BaseEntity).CreatedAt = DateTime.Now;
            }
            await _entities.AddRangeAsync(entities);
        }
    }
}
