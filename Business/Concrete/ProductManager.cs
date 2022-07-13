using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal.CrossCuttingConcerns.Validation;
using Universal.Utilities.Aspects.Autofac.Validation;
using Universal.Utilities.Business;
using Universal.Utilities.Results.Abstract;
using Universal.Utilities.Results.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> Get(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 14)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDto()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDto());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductCountOfCategoryLimitExeceeded(product.CategoryId), 
                CheckIfTheSameProductNameExists(product.ProductName),
                CheckIfCategoryLimitExeceeded());

            if (result!=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        #region Comment
        /*
         * These are our Business codes so they should be private and BusinessRules.Run our Business Rules engine it 
         * check it all then returns us the result of it
         */
        #endregion
        private IResult CheckIfProductCountOfCategoryLimitExeceeded(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryLimitExeceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfTheSameProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.TheSameProductNameExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExeceeded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExeceeded);
            }
            return new SuccessResult();
        }

    }
}
