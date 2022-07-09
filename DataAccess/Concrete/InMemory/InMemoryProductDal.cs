using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory 
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> 
            {
                new Product{ProductId=1,CategoryId=1,ProductName="RAM",UnitPrice=1300,UnitsInStock=482},
                new Product{ProductId=2,CategoryId=1,ProductName="CPU",UnitPrice=1850,UnitsInStock=250},
                new Product{ProductId=3,CategoryId=1,ProductName="Monitor",UnitPrice=2500,UnitsInStock=150},
                new Product{ProductId=4,CategoryId=2,ProductName="Pencil",UnitPrice=12,UnitsInStock=11840},
                new Product{ProductId=5,CategoryId=3,ProductName="Bag",UnitPrice=350,UnitsInStock=469},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete=_products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);          
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetailDto()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
