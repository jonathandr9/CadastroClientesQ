using CadastroClientQ.Application;
using CadastroClientQ.DBSqlAdapter;
using CadastroClientQ.DBSqlAdapter.Configuration;
using CadastroClientQ.Domain.Repositories;
using CadastroClientQ.Domain.Services;
using CadastroClientQ.WebApp;
using IBGEServicoDados.ApiAdapter.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBContextCadastroClient>(opt => 
    opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"))
);
builder.Services.AddAutoMapper(typeof(IBGEApiProfileMapper));
builder.Services.AddAutoMapper(typeof(WebMapperProfile));
builder.Services.AddIBGEApi(builder.Configuration.GetSection("IBGEApiConfiguration").Get<IBGEApiConfiguration>());
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Client/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();
