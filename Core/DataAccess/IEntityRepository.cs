
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class,IEntity,new()// generic repository design pattern
    {
        // bir uygulamada detaya gitmek anlamında.
        List<T> GetAll(Expression<Func<T,bool>> filter = null);//getall hepsini sırala // fitre de verebiliriz linq ile filtreleme özelliği
        T Get(Expression<Func< T, bool >> filter); // T döndüren get operasyonu  
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
           // categoryıd ye göre listele
    }
}
