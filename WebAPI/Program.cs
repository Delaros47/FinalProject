using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Comment
/* This is dependency injection by Microsoft but later we will use AutoFac for IoC Container here Singleton if 1 million
Request Product it will only one instance on memory and give all one million people the same instance of Product */
#endregion
builder.Services.AddSingleton<IProductService,ProductManager>();
builder.Services.AddSingleton<IProductDal, EfProductDal>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
