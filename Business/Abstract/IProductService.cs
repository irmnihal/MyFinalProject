using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    // iş katmanında kullanılcak servis elemanları
    public interface IProductService
    {
        List<Product> GetAll();
       List<Product> GetAllByCategoryId( int categoryId);
        List<Product> GetByUnitPrice(decimal min, decimal max);

    }
}
