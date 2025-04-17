using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace Order_Management_System.dao
{
    public interface IGetAllProductsDao
    {
        List<Product> GetAllProducts();
    }
}
