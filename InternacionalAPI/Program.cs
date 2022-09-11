var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

//1. LOCALIZATION
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//2. SUPPORTED LANGUAGE
var supportedLanguages = new[] { "en-US", "es-ES", "fr-FR" }; // USA's English, spain's spanish, France's french 
var localizationOption = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedLanguages[0]) // English by default
    .AddSupportedCultures(supportedLanguages) //Add all suported cultures
    .AddSupportedUICultures(supportedLanguages); // Add supported cultuers to UI;

//3. ADD LOCALIZATION TO App


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
