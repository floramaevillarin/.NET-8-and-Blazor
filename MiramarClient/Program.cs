using Microsoft.EntityFrameworkCore;
using Miramar.Application.Interfaces;
using Miramar.Infrastructure.Context;
using Miramar.Infrastructure.Repositories;
using MiramarClient.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<MiramarDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiramarConnection"));
});

builder.Services.AddScoped<ITimesheetRepository, TimesheetRepository>();

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
