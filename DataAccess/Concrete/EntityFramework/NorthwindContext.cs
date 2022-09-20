using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // context : Db tabloları ile proje classslarını bağlamak
    public class NorthwindContext : DbContext
    {
        // bu method benim projem hangi veritabanı ile ilşkiliyse onu belirteceğimiz yerdir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDb;DataBase=Northwind;Trusted_Connection=true)"); // sql server a bağlanacağımızı belirttik
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> categories { get; set; } 
        public DbSet<Customer> customers { get; set; }  // ne nereye bağlanıcak tek tek yazıyoruz. artık entityframwork ü kullanarak kodlaramızı yazzabiliriz.
    }
}
