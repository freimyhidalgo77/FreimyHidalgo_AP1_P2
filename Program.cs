using FreimyHidalgo_AP1_P2.Components;
using Microsoft.EntityFrameworkCore;
using FreimyHidalgo_AP1_P2.DAL;
using FreimyHidalgo_AP1_P2.Models;
using FreimyHidalgo_AP1_P2.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContextFactory<Context>(r => r.UseSqlServer("Name=SqlConStr"));

builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<ComboService>();
builder.Services.AddScoped<ComboDetalleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); 
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
