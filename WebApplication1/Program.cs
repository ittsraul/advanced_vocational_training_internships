using Microsoft.EntityFrameworkCore;
using WebApplication1.infraestructure.persistence;
using System.Data.Common;
using WebApplication1.Application.Services;
using WebApplication1.Domain.persistence;
using WebApplication1.Application.Mapper;
using WebApplication1.infraestructure.Rest;
using WebApplication1.infraestructure.Specs;
using static WebApplication1.infraestructure.Specs.SpecificationParser;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped(typeof(ISpecificationParser<>), typeof(SpecificationParser<>));
builder.Services.AddAutoMapper(typeof(CategoryMapperProfile));
builder.Services.AddAutoMapper(typeof(ItemMapperProfile));
builder.Services.AddAutoMapper(typeof(ItemMapperProfile));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection";

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<StoreContext>(options =>
        options.UseInMemoryDatabase(connectionString)
    );
}

var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    DevelopmentDataLoader dataLoader = new(context);
    dataLoader.LoadData();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
