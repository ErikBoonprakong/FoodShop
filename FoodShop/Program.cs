using FoodShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<IPieRepository , PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FoodShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:FoodShopDbContextConnection"]);
});

var app = builder.Build();

// app.MapGet("/", () => "Helloooooo World!");

app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// app.MapDefaultControllerRoute(); // "{controller=Home}/{action=Index}/{id?}"
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
DbInitializer.Seed(app);
app.Run();
