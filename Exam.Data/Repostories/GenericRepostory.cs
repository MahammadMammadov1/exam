using Exam.Core.Models;
using Exam.Core.Repostories;
using Exam.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Repostories
{

   
    public class GenericRepostory<TEntity> : IGenericRepostory<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _appDb;

        public GenericRepostory(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public DbSet<TEntity> Table => _appDb.Set<TEntity>();

        public  async Task<int> CommitAsync()
        {
           return  await _appDb.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
             await _appDb.AddAsync(entity);
        }

        public void DeleteAsync(TEntity entity)
        {
            _appDb.Remove(entity);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression = null, params string[]? include)
        {
            var query = Table.AsQueryable();
            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            if (expression!= null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? include)
        {
            var query = Table.AsQueryable();
            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }
            return await query.FirstOrDefaultAsync();

        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
