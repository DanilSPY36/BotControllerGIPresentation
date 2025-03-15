global using Microsoft.AspNetCore.Components.Authorization;
using Blazor.SubtleCrypto;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BotControllerGIPresentation;
using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices;
using BotControllerGIPresentation.IServices.ISpotsDimServices;
using BotControllerGIPresentation.IServices.IUserServices;
using BotControllerGIPresentation.Services;
using BotControllerGIPresentation.Services.SpotsDimServices;
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

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredSessionStorage(config => config.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddSingleton<SelectedSpotStateService>();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<NotificationMessage>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddSubtleCrypto();


builder.Services.AddHttpClient<IUserSpotsService, UsersSpotService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<ISpotsDimService, SpotsDimService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});


builder.Services.AddHttpClient<IHotcoffeeService, HotcoffeeService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
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
builder.Services.AddScoped(typeof(ISessionStorageGenericService<>), typeof(SessionStorageGenericService<>));

builder.Services.AddHttpClient<ISessionStorageGenericService<Ttk>, SessionStorageGenericService<Ttk>>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IUploadService, UploadService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

#endregion


await builder.Build().RunAsync();
