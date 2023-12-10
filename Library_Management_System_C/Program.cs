using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Library_Management_System_C.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Library_Management_System_CContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Library_Management_System_CContext") ?? throw new InvalidOperationException("Connection string 'Library_Management_System_CContext' not found.")));

//Session setup
builder.Services.AddDistributedMemoryCache();

//add CONTEXT (4)
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options=> {
    options.Cookie.Name = ".GayoCanalesLibrary.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;

});
// Add services to the container.
builder.Services.AddControllersWithViews();

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


//use session
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Borrowers}/{action=Index}/{id?}");

app.Run();
