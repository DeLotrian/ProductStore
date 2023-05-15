using ProductStore.Core;
using ProductStore.Core.DbClients;
using ProductStore.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.Configure<ProductStoreDbConfig>(builder.Configuration);
builder.Services.AddSingleton<IDbClient, DbClient>();
builder.Services.AddTransient<IProductStoreServices, ProductStoreServices>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
