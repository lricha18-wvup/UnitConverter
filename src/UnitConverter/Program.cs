using Serilog;
using Serilog.Formatting.Compact;
using UnitConverter.Services;

var builder = WebApplication.CreateBuilder(args);


string logPath = Path.Combine(
    builder.Environment.ContentRootPath,
    "Logs",
    "unitconverter-.json");


builder.Host.UseSerilog((context, services, configuration) => configuration
    .WriteTo.Console()
    .WriteTo.File(
        new RenderedCompactJsonFormatter(),
        logPath,
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 14));


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IConversionService, UnitOfConversionService>();
builder.Services.AddSingleton<ILogReader, JsonLogReader>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();


/// <summary>
/// This is provided to support the WebApplicationFactory used in testing.
/// </summary>
public partial class Program
{
}
