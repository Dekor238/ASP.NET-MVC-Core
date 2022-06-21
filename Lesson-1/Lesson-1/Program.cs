using Lesson_1.DAL.Interfaces;
using Lesson_1.DAL.Repository;
using Lesson_1.Emails;
using Lesson_1.Models;
using Lesson_1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICatalog, Catalog>();
builder.Services.AddSingleton<ICategory, CategoryRepository>();
builder.Services.AddSingleton<IProduct, ProductsRepository>();
builder.Services.AddScoped<IProductAddEmail, ProductAddEmail>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();