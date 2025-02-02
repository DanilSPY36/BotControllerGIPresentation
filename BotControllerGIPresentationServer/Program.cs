using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories;
using BotControllerGIPresentationServer.IRepositories.UserIRepository;
using BotControllerGIPresentationServer.Repositories;
using BotControllerGIPresentationServer.Repositories.UserRepos;
using Microsoft.EntityFrameworkCore;
using Radzen;
using SharedLibrary.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllersWithViews(); 
builder.Services.AddRazorComponents();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddOpenApi();

#region Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICategoriesDimRepository, CategoriesDimRepository>();
builder.Services.AddScoped<ITtkRepository, TtkRepository>();
builder.Services.AddScoped<IContainerDimRepository, ContainerDimRepository>();
builder.Services.AddScoped<IVolumesDimRepository, VolumesDimRepository>();
builder.Services.AddScoped<IKbjuTtkRepository, KbjuTtkRepository>();

builder.Services.AddScoped<IGenericRepository<KbjuTtk>, GenericRepository<KbjuTtk>>();
builder.Services.AddScoped<IGenericRepository<Ttk>, GenericRepository<Ttk>>();
builder.Services.AddScoped<IGenericRepository<CategoriesDim>, GenericRepository<CategoriesDim>>();
builder.Services.AddScoped<IGenericRepository<ContainersDim>, GenericRepository<ContainersDim>>();
builder.Services.AddScoped<IGenericRepository<VolumesDim>, GenericRepository<VolumesDim>>();

#endregion

#region Storages Uploaders  Repositories
builder.Services.AddScoped<IUploadRepository, UploadRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");   
app.Run();
