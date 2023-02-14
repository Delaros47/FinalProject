using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            //foreach (var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryName);
            //}

            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine($"{product.ProductName,-30}{product.CategoryName,25}");
            }


            Console.ReadLine();
        }
    }
}