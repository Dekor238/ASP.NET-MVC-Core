using Lesson_1.Config;
using Lesson_1.DAL;
using Lesson_1.DAL.Interfaces;
using Lesson_1.DAL.Repository;
using Lesson_1.Emails;
using Lesson_1.Models;
using Lesson_1.Services;
using Serilog;

// For Lesson-7

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting Up application");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    //DI container
    builder.Services.AddSingleton<ICatalog, Catalog>();
    builder.Services.AddSingleton<ICategory, CategoryRepository>();
    builder.Services.AddSingleton<IProduct, ProductsRepository>();
    builder.Services.AddScoped<IProductAddEmail, ProductAddEmail>();

    // SMTP json file config
    builder.Services.Configure<SmtpConfiguration>(builder.Configuration.GetSection("SmtpConfigurations"));
    builder.Services.AddScoped<IEmailService, EmailService>();

    //Serilog
    builder.Host.UseSerilog((_, conf) =>
    {
        conf.MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
    });

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

    app.UseSerilogRequestLogging();
    
    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Fatal exception");
}
finally
{
    Log.Information("Shut down application");
    Log.CloseAndFlush();
}