using Distraction_Logger_PWA;
using Distraction_Logger_PWA.Data.LogsData;
using Distraction_Logger_PWA.Data.Tags;
using Magic.IndexedDb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DistractionTagRepository>();
builder.Services.AddScoped<DistractionLogRepository>();
builder.Services.AddMudServices();
builder.Services.AddMagicBlazorDB(BlazorInteropMode.WASM, builder.HostEnvironment.IsDevelopment());

await builder.Build().RunAsync();
