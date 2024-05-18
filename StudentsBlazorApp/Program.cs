using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using StudentsBlazorApp.Data;
using StudentsBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

/*builder.Services.AddHttpClient<StudentService>(client =>
{

    client.BaseAddress = new Uri("https://localhost:7123/"); //our api base address
});*/

builder.Services.AddScoped(client => new HttpClient { BaseAddress = new Uri("https://localhost:7123/") });


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
