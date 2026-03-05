using EcoTech.ERP.Web.Client.Services.Common;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7275/api/")
});

builder.Services.AddAllServices();

await builder.Build().RunAsync();
