using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using VehicleManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication()
                .AddGoogle(google_options => { google_options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? throw new InvalidCastException("Authentication failed");
                                                          google_options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? throw new InvalidCastException("Authentication failed");
                });

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddTransient<ICar, CarRepository>();
builder.Services.AddTransient<ICustomer, CustomerRepository>();
builder.Services.AddTransient<IRental, RentalRepository>();
builder.Services.AddTransient<IVehicleCategory, VehicleCategoryRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpContextAccessor();

//builder.Services.AddHttpClient();
builder.Services.AddScoped(c =>
{
    var client = new HttpClient { BaseAddress = new Uri("https://localhost:7286") };
    client.DefaultRequestHeaders.Clear();
    var token = builder.Configuration.GetValue<string>("ApiConfig:Token");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    return client;
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

app.MapControllerRoute(name: "index2",
                pattern: "/Book/{carId}/{pickupDate}/{returnDate}",
                defaults: new { controller = "Rentals", action = "Create" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
