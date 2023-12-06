using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1.controllers;
using WebApplication1.data.models;
using WebApplication1.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<MarketService>();
builder.Services.AddScoped<MarketController>();
   
builder.Services.AddScoped<EmailService>();


builder.Services.AddDbContext<StockDbContext>(options =>
{

    options.UseSqlServer(
            "Server=DESKTOP-G3BRAJE\\SQLEXPRESS;Database=Stock_db;Trusted_Connection=True;TrustServerCertificate=True")
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information);
});

// builder.Services.AddDbContext<StockDbContext>(options    =>
// {
//     var connectionString = "server=localhost;user=root;password=Oluwatomiwa2020;database=stockdb";
//     var serverVersion = new MySqlServerVersion(new Version(8, 0, 22));
//
//     options.UseMySql(connectionString, serverVersion);
// });

var app = builder.Build();
// var port = 5000;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints => 
    endpoints.MapControllers()
);

app.Run();
   