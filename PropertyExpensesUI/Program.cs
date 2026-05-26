using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using PropertyExpensesUI;
using MudBlazor.Services;
using PropertyExpensesUI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//// Add HttpClient for making external web API calls to the Backend server API
builder.Services.AddHttpClient("ApiHttpClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5184/api/");
});

//// For prerendering purposes, register a named HttpClient for the app's
//// named client component example.
//builder.Services.AddHttpClient("WebAPI", client =>
//    client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5001"));

//// For prerendering purposes, register the client app's typed HttpClient
//// for the app's typed client component example.
//builder.Services.AddHttpClient<TodoHttpClient>(client => client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5002"));

//builder.Services.AddHttpClient("ExternalApi", client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5209");
//})
//.AddHttpMessageHandler<AuthenticationStateHandler>()
//.AddApplicationScopeHandler();

builder.Services.AddScoped<IPropertyService, PropertyService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

var app = builder.Build();

await app.RunAsync();
