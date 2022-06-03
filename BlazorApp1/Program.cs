using BlazorApp1;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7150") });
builder.Services.AddScoped<ITripProvider, TripProvider>();
builder.Services.AddScoped<ICountryProvider, CountryProvider>();
builder.Services.AddScoped<ICustomerProvider, CustomerProvider>();
builder.Services.AddScoped<IHotelProvider, HotelProvider>();
builder.Services.AddScoped<IAir_FlightProvider, Air_FlightProvider>();

await builder.Build().RunAsync();
