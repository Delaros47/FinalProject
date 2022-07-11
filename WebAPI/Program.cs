using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.AutoFac;
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
//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();
#region Comment
/*
 * Here we declared our IOC for dependency injection since we want to manage our project from Business Layer so
 * we don't to declare for each UI different dependency inject IOC
 */
#endregion
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
    options.RegisterModule(new AutoFacBusinessModule())
));

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
