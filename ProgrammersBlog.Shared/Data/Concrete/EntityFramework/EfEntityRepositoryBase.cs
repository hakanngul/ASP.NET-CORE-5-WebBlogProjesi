using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity:class, IEntity,new()
    {
        private readonly DbContext _context;
        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
            // remove bir async olmadığından 
            // async şekline çevirerek Task.Run ile işlem yapıyoruz.

        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate !=null) // predicate => product ın null olma durumunu kontrol ediyoruz
            {
                query = query.Where(predicate); // bildiğimiz Sorgu şekli olan IQueryable dan nesnesini context e abone ediyoruz .Set ile
            }
            if (includeProperties.Any()) // dizi içerisinde herhangi bir değer olup olmadığını Any methodu ile kontrol edeceğiz
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty); // sorgu içerisinde Include ile olup olmadığına bakıyor ve includeProp ile query içerisine atıyoruz.
                }
            }
            return await query.ToListAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.SingleOrDefaultAsync(); // bir ürün almak istediğimiz için liste değilde Single Object döndürüyoruz.
        }

        public async Task UpdateAsync(TEntity entity)
        {
            // Delete ile aynı sistem olduğundan bir async yaratıyoruz.
            await Task.Run(() =>  _context.Set<TEntity>().Update(entity)); // anonim method oluşturarak Task.Run oluşturarak async e çeviriyoruz.
        }
    }
}
