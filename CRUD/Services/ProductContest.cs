using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Domain.Entity;
using Domain.Enums;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Services
{
    public class ProductContext: DbContext
    {
        public ProductContext():base("connectionString")
        {

        }

        public DbSet<Product> Prodcuts { get; set; }
    
    }
}
