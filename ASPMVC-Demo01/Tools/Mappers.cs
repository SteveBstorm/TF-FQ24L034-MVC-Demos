using asp = ASPMVC_Demo01.Models;
using dal = DAL.Entities;

namespace ASPMVC_Demo01.Tools
{
    public static class Mappers
    {
        public static dal.Product ToDal(this asp.ProductForm productForm) {
            return new dal.Product
            {
                Name = productForm.Name,
                Price = productForm.Price,
                Quantity = productForm.Quantity
            };
        }

        public static asp.Product ToASP(this dal.Product product)
        {
            return new asp.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        public static dal.Product ToDal(this asp.Product product)
        {
            return new dal.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }
    }
}
