using RestSharp;
using Serilog;
using Serilog.Events;
using Services.Abstraction;
using Services.Abstraction.Infrastructure;
using Services.Implementation;
using Services.Implementation.Infrastructure;
using WebAPI.Infrastructure.Implementation;
using IRestClient = RestSharp.IRestClient;

IConfigurationRoot GetConfiguration()
{
    var configurationRoot = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environments.Development}.json", optional: true, reloadOnChange: true)
        .Build();
    return configurationRoot;
}

var builder = WebApplication.CreateBuilder(args);
var configuration = GetConfiguration();

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.AddSerilog(logger);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IRestClient, RestClient>();
builder.Services.AddTransient<IApiCaller, ApiCaller>();
builder.Services.AddTransient<IFileWriter, FileWriter>();
builder.Services.AddTransient<ICustomLogger, CustomLogger>();
builder.Services.AddTransient<IConfigurationFactory, ConfigurationFactory>();
builder.Services.AddSingleton(configuration);

builder.Services.AddOptions();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();