using NotasApp.BLL.Interfaces.Repository;
using NotasApp.BLL.Interfaces.Services;
using NotasApp.BLL.Services;
using NotasApp.DAL.Context;
using NotasApp.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddTransient<DBContext, DBContext>();
builder.Services.AddTransient<INotasRepository, NotasRepository>();
builder.Services.AddTransient<INotasServices, NotasServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


    //.WithOpenApi();

app.Run();