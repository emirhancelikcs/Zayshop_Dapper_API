using ZayShop_Dapper_Api.Models.DapperContext;
using ZayShop_Dapper_Api.Repositories.CartRepository;
using ZayShop_Dapper_Api.Repositories.CategoryOfTheMonthRepository;
using ZayShop_Dapper_Api.Repositories.CategoryRepository;
using ZayShop_Dapper_Api.Repositories.FooterCenterRepository;
using ZayShop_Dapper_Api.Repositories.FooterLeftRepository;
using ZayShop_Dapper_Api.Repositories.FooterRightRepository;
using ZayShop_Dapper_Api.Repositories.IndexCarouselRepository;
using ZayShop_Dapper_Api.Repositories.InfosRepository;
using ZayShop_Dapper_Api.Repositories.NavbarLinkRepository;
using ZayShop_Dapper_Api.Repositories.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IIndexCarouselRepository, IndexCarouselRepository>();
builder.Services.AddTransient<ICategoryOfTheMonthRepository, CategoryOfTheMonthRepository>();
builder.Services.AddTransient<IInfosRepository, InfosRepository>();
builder.Services.AddTransient<INavbarLinkRepository, NavbarLinkRepository>();
builder.Services.AddTransient<IFooterLeftRepository, FooterLeftRepository>();
builder.Services.AddTransient<IFooterCenterRepository, FooterCenterRepository>();
builder.Services.AddTransient<IFooterRightRepository, FooterRightRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
