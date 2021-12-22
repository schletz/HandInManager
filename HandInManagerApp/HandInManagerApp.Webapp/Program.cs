using HandInManagerApp.Application.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Seeden der Datenbank
var opt = new DbContextOptionsBuilder()
    .UseSqlite("Data Source=HandIn.db")  // builder.Configuration["ConnectionString"]
    .Options;
using (var db = new HandInContext(opt))
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    db.Seed();
}  // Dispose() wird aufgerufen


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<HandInContext>(opt =>
{
    // Alternativ: In appsettings.json einen Key ConnectionString anlegen
    // und builder.Configuration["ConnectionString"] verwenden.
    opt.UseSqlite("Data Source=HandIn.db");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
