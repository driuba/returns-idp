using App.Utils;
using OrchardCore.Users.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOrchardCms();

builder.Services.AddScoped<IUserClaimsProvider, UserClaimsProvider>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseOrchardCore();

app.Run();
