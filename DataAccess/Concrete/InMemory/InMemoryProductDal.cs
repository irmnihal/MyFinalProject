using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory

{
    //  bellekteki ürünlerle ilgili veri erişim kodlarının yazılıcak yeri
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="bardak", UnitInStock=15, UnitPrice=15},
                 new Product{ProductId=2, CategoryId=1, ProductName="kamera", UnitInStock=500, UnitPrice=3},
                   new Product{ProductId=3, CategoryId=2, ProductName="telefon", UnitInStock=1500, UnitPrice=2},
                new Product{ProductId=4, CategoryId=2, ProductName="klavye", UnitInStock=150, UnitPrice=65},
               new Product{ProductId=5, CategoryId=2, ProductName="fare", UnitInStock=85, UnitPrice=1}




            };    
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
        // Lİnq kullan. 
        public void Delete(Product product)
        {
             Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            // foreach görevi gördü. silmeyi yapar.
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); // linq ile veri erişim de bitti
        }

        public void Update(Product product)
        {
            // gönderdiğim ürün ıd sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitInStock = product.UnitInStock;  
            productToUpdate.UnitPrice = product.UnitPrice;  
        }
    }
}

