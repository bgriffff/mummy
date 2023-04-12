using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using mummy.Data;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;
using mummy.Models;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
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

var postgresConnectionString = builder.Configuration.GetConnectionString("MummyConnection");
builder.Services.AddDbContext<intex2Context>(opt =>
        opt.UseNpgsql(postgresConnectionString));



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
//builder.Services.AddRazorPages(options =>
//{
//    options.Conventions.AddFolderApplicationModelConvention("/Areas/Identity/Pages/Account", model => {
//        model.RootDirectory = "/CustomPages";
//    });
//});

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
