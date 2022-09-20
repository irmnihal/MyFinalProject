using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // ınterface operasyonları database de yapılcak. 
    public  interface IProductDal: IEntityRepository<Product> // yanni bu IProductDal sen bir IEntityRepository sin ve çalışma tipin product 
        // sen IEntityRepository yi product için yapılandırdın. categorydal içinde yapabilriz
    {
     
    }
}
// code refatoring 