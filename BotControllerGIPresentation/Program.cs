global using Microsoft.AspNetCore.Components.Authorization;
using BotControllerGIPresentation;
using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices;
using BotControllerGIPresentation.IServices.IUserServices;
using BotControllerGIPresentation.Services;
using BotControllerGIPresentation.Services.UserServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SharedLibrary.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<NotificationMessage>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();


builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient<ICategoriesDimService, CategoriesDimService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<ITtkService, TtkService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IContainersDimService, ContainersDimService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IVolumesDimService, VolumesDimService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IKbjuTtkService, KbjuTtkService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});


builder.Services.AddHttpClient<IGenericService<Ttk>, GenericService<Ttk>>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IGenericService<CategoriesDim>, GenericService<CategoriesDim>>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IGenericService<ContainersDim>, GenericService<ContainersDim>>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IGenericService<VolumesDim>, GenericService<VolumesDim>>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IGenericService<KbjuTtk>, GenericService<KbjuTtk>>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});



#region Storages Uploads services

builder.Services.AddHttpClient<IUploadService, UploadService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

#endregion


await builder.Build().RunAsync();
