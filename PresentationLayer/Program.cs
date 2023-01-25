using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration["ConexaoSqlite:SqliteConnectionString"];
builder.Services.AddDbContext<UsuarioContexto>(options => options.UseSqlite(connection));

// Configuração Mapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new BusinessLayer.Mapper.Usuario.UsuarioProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

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
