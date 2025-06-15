using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Secomez.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    //options.Conventions.AuthorizePage("/Products", );

    //options.Conventions.AuthorizePage("/addProduct");
    options.Conventions.AuthorizePage("/Privacy");
}

);



builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));



//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDataContext>();

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); // Lockout duration
    options.Lockout.MaxFailedAccessAttempts = 3; // Number of allowed failed attempts before lockout
    options.Lockout.AllowedForNewUsers = true; // Lockout enabled for new users
})
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<AppDataContext>();
    

//Register Cart as a singleton
builder.Services.AddSingleton<Cart>();

//Adding a Session
builder.Services.AddSession(options =>
{
    // Set session timeout
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add session middleware
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
