using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IProductRepository
    {
        void Create(Product product);
        IEnumerable<Product> GetAll();
        Product GetById(int id);

    }
}
