using GameZone.DeviceRepository;
using GameZone.Repository.CategoryRepository;
using GameZone.Repository.Game_Repository;
using GameZone.Repository.Generic;
using GameZone.Services;
using GameZone.Services.GamesService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("connStr")
    ?? throw new InvalidOperationException("connection string wasn't provided");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// register services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IDeviceSelectListItemService, DevicesSelectListItemService>();
builder.Services.AddScoped<ICategorySelectListItemService, CategorySelectListItemService>();
builder.Services.AddScoped<IGamesService, GamesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios,
    // see https://aka.ms/aspnetcore-hsts.
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
