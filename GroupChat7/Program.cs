using GroupChat7.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PusherServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GroupChatContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GroupChatContext")
        ?? throw new InvalidOperationException("Connection string 'GroupChatContext' not found."));

    // Ensure the database is created when the application starts
    options.UseSqlServer().EnableServiceProviderCaching(false);
});


AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(builder.Environment.ContentRootPath, "App_Data"));
// Add services to the container.
builder.Services.AddControllersWithViews();


// pusher configuration
var pusherOptions = new PusherOptions
{
    Cluster = builder.Configuration["Pusher:Cluster"],
    Encrypted = true
};
builder.Services.AddSingleton(new Pusher(
    builder.Configuration["Pusher:AppId"],
    builder.Configuration["Pusher:Key"],
    builder.Configuration["Pusher:Secret"],
    pusherOptions));


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=GroupChat}/{action=RegisterEvent}/{id?}");

app.Run();
