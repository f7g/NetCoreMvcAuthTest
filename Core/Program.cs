using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Core.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddMicrosoftAccount(options => {
    var tenantId = builder.Configuration["Authentication:Microsoft:TenantId"] ?? throw new InvalidOperationException("ClientId string not found.");
    options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"] ?? throw new InvalidOperationException("ClientId string not found."); 
    options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"] ?? throw new InvalidOperationException("ClientSecret string not found.");
    options.AuthorizationEndpoint = $"https://login.microsoftonline.com/{tenantId}/oauth2/authorize";
    options.TokenEndpoint = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token";});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())  {
    app.UseMigrationsEndPoint();
}
else  {
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
app.MapRazorPages();

app.Run();
