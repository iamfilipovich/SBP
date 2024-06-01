using Hotel.Models;
using Hotel.Repositories;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddTransient<IServicesRepository, ServicesRepository>();
builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddTransient<IGuestsRepository, GuestsRepository>();
builder.Services.AddTransient<IReservationsRepository, ReservationsRepository>();
builder.Services.AddTransient<IRoomsRepository, RoomsRepository>();

// Configure app settings
builder.Configuration.AddJsonFile("appsettings.json");

// Configure MongoDB settings
builder.Services.Configure<Settings>(
    options =>
    {
        options.ConnectionStrings = builder.Configuration.GetSection("MongoDB:ConnectionStrings").Value;
        options.Database = builder.Configuration.GetSection("MongoDB:Database").Value;
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
