using WebVisorofStackTraceC_.Services;
using WebVisorofStackTraceC_.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISolicitudService, SolicitudService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

builder.Services.AddLogging(logging => {
    logging.AddConsole();
    logging.AddDebug();
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
