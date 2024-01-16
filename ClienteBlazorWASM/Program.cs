using ClienteBlazorWASM;
using ClienteBlazorWASM.Servicios;
using ClienteBlazorWASM.Servicios.IServicio;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//Agregamos servicios aca
builder.Services.AddScoped<IPostServicio, PostServicio>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
