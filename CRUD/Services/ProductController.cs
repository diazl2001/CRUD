using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Services;
using Domain.Entity;
using Domain.Enums;
using System.Data;


namespace Services
{
    public class ProductController : IProductController
    {
        public void DeleteProduct(int ProductId)
        {
            using (var thisProductContext = new ProductContext())
            {
               
                var foundProduct =  thisProductContext.Prodcuts.Where(q => q.ID == ProductId);
                Product ProductToDelete = foundProduct.FirstOrDefault();

                if (ProductToDelete != null)
                {
                    thisProductContext.Prodcuts.Remove(ProductToDelete);
                    thisProductContext.SaveChanges();
                }
                
               
            }

        }

        public List<Product> GetAllProducts()
        {
            using (var thisProductContext = new ProductContext())
            {
                var productList = thisProductContext.Prodcuts;
                return productList.ToList();
            }
        }

        public void InsertarProduct( Product thisProduct)
        {
            using (var thisProductContext = new ProductContext())
            {
          
                var insertQuery = thisProductContext.Prodcuts.Add(thisProduct);
                thisProductContext.SaveChanges();
          
            }
        }

        public void UpdateProduct(Product thisProduct)
        {
            using (var thisProductContext = new ProductContext())
            {

                var originalProduct = thisProductContext.Prodcuts.Find(thisProduct.ID);

                if (originalProduct != null)
                {
                    thisProductContext.Entry(originalProduct).CurrentValues.SetValues(thisProduct);
                    thisProductContext.SaveChanges();
                }

            }
        }
    }
}
