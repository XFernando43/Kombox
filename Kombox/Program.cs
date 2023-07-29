using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository;
using Kombox.DataAccess.Repository.IRepository;
using Kombox.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
     builder.Configuration.GetConnectionString("DafultConnection")
    ));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>                      // en caso quieran colocar la ruta de acceso a administrador les pedira un logeo primero y no los dejara �:3
{                                                                           // en caso quieran colocar la ruta de acceso a administrador les pedira un logeo primero y no los dejara �:3
    options.LoginPath = $"/Identity/Account/Login";                         // en caso quieran colocar la ruta de acceso a administrador les pedira un logeo primero y no los dejara �:3
    options.LogoutPath = $"/Identity/Account/Logout";                       // en caso quieran colocar la ruta de acceso a administrador les pedira un logeo primero y no los dejara �:3
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";           // en caso quieran colocar la ruta de acceso a administrador les pedira un logeo primero y no los dejara �:3
});                                                                         // en caso quieran colocar la ruta de acceso a administrador les pedira un logeo primero y no los dejara �:3


builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages(); // Mapear paginas de razor

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
