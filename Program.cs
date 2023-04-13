using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using mummy.Data;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;
using mummy.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Database for Passwords and such
var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//string postgresConnectionString;
//var request = new GetParameterRequest()
//{
//    Name = "mummiesDb"
//};
//using (var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.GetBySystemName("us-east-1")))
//{
//    var response = client.GetParameterAsync(request).GetAwaiter().GetResult();
//    postgresConnectionString = response.Parameter.Value;
//}

//Database for Mummies Info
var postgresConnectionString = Environment.GetEnvironmentVariable("MummyConnection");
//var postgresConnectionString = builder.Configuration.GetConnectionString("MummyConnection");
builder.Services.AddDbContext<intex2Context>(opt =>
        opt.UseNpgsql(postgresConnectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();


//Makes stronger passwords
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 12;
    options.Password.RequiredUniqueChars = 1;
});

//Old Users
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
