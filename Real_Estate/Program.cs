using Microsoft.EntityFrameworkCore;
using Real_Estate.ViewModels.Data;
using Real_Estate.ViewModels.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<AgencijaRepository>();
builder.Services.AddScoped<KorisnikRepository>();
builder.Services.AddScoped<NekretnineRepository>();
builder.Services.AddScoped<GradoviRepository>();
builder.Services.AddScoped<OpstinaRepository>();
builder.Services.AddScoped<MikrolokacijaRepository>();
builder.Services.AddScoped<UlicaRepository>();
builder.Services.AddSession();

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Entity}/{action=LogIn}/{id?}");

app.Run();
