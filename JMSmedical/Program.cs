using Microsoft.EntityFrameworkCore; // using जोड़ें
using JMSmedical.Data; // using जोड़ें

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database Context Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); // UseSqlServer यहाँ कॉन्फ़िगर करें

builder.Services.AddControllersWithViews();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services); // सीडिंग मेथड को कॉल करें
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
        // इसे प्रोडक्शन में अधिक मजबूती से हैंडल करें
    }
}

// ... (rest of the Program.cs code)

// Add services to the container.


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();