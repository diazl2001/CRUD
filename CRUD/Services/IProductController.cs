using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Services
{
    interface IProductController
    {

        void InsertarProduct(Product newProduct);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(int Id );
        List<Product> GetAllProducts();

    }
}
