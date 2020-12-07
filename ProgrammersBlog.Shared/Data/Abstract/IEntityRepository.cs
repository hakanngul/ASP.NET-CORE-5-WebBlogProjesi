using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        // burasının bir Interface olduğunu unutma sadece arayüz tasarlanıyor burada.
        // async => Task ==> Flutterdaki Future Kavramı
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); 
        // params => 1 veya 1 den fazla veri verebilirim  veya alabilirimi ifade etmektedir.
        // predicte ve include Properties => bildiğimiz response 
        // var kullanici = repository.GetAsync(k=> k.Id == 15) expr
        // Expression ==> Lambda Expression ı ifade etmektedir.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] includeProperties);
        // Task<IList<T> bu Ilist kavramı birden çok durumda yani 1 den çok makaleleri çekmek için list kullanıyoruz.
        // predicate =null olması ise hepsini veya 1 tanesini çekmek için null kullanıyoruz.
        Task AddAsync(T entity);
        // Task AddAsync bu bildiğimiz listeye eklemek için kullanılan yöntem
        Task UpdateAsync(T entity);
        // Task AddAsync ile aynı şekilde çalışmaktadır.
        Task DeleteAsync(T entity);
        // Add ve update ile aynı şekilde çalışıyor.
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        // burasının farklı olmasının sebebi verinin olup olmama durumunu kontrol etmek için
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);


    }
}
