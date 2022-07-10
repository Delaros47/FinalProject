using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;












ProductManager productManager = new ProductManager(new EfProductDal());
var result = productManager.GetAll();
if (result.Success)
{
    foreach (var product in productManager.GetAll().Data)
    {
        Console.WriteLine($"{product.ProductName,-35} {product.UnitPrice,20}");
    }
}
else
{
    Console.WriteLine(result.Message);
}


//CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
//foreach (var category in categoryManager.GetAll())
//{
//    Console.WriteLine(category.CategoryName);
//}

//ProductManager productManager = new ProductManager(new EfProductDal());
//foreach (var product in productManager.GetByUnitPrice(40,100))
//{
//    Console.WriteLine($"{product.ProductName,-35} {product.UnitPrice,20}");
//}

//ProductManager productManager = new ProductManager(new EfProductDal());
//foreach (var product in productManager.GetAllByCategoryId(5))
//{
//    Console.WriteLine($"{product.ProductName,-35} {product.UnitPrice,20}");
//}

//ProductManager productManager = new ProductManager(new EfProductDal());
//foreach (var product in productManager.GetAll())
//{
//    Console.WriteLine($"{product.ProductName,-35} {product.UnitPrice,20}");
//}

//ProductManager productManager = new ProductManager(new InMemoryProductDal());
//foreach (var product in productManager.GetAll())
//{
//    Console.WriteLine($"{product.ProductName,-10} {product.UnitPrice,10}");
//}








Console.ReadLine();