using Exam.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Repostories
{
    public interface IGenericRepostory<TEntity> where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table { get; }
        void DeleteAsync(TEntity entity);
        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression = null, params string[]? include);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? include);
        Task<int> CommitAsync();
    }
}
