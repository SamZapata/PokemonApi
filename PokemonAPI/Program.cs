using PokemonAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokemonAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PokemonAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PokemonAPIContext") ?? throw new InvalidOperationException("Connection string 'PokemonAPIContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IResultApi, ApiService>();
builder.Services.AddScoped<IPokeapiService, PokeapiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
