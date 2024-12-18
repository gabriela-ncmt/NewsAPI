using NewsAPI.Entities;
using NewsAPI.Infra;
using NewsAPI.Mappers;
using NewsAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using AutoMapper;
using static NewsAPI.Infra.DatabaseSettings;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// ** Configura��o de Servi�os **

#region [Database]
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
#endregion

#region [DI]
// Configura��o de Inje��o de Depend�ncia (DI)
builder.Services.AddScoped<IMongoRepository<News>, MongoRepository<News>>();
builder.Services.AddScoped<NewsService>();
#endregion

#region [AutoMapper]
// Adicionando AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToViewModelMapping), typeof(ViewModelToEntityMapping));
#endregion

#region [Cors]
builder.Services.AddCors();
#endregion

// Adicionando Controllers
builder.Services.AddControllers();

// Adicionando Swagger para documenta��o da API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewsAPI", Version = "v1" });
});

var app = builder.Build();

// ** Configura��o do Pipeline de Requisi��o HTTP **
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

app.UseHttpsRedirection();
#region [Cors]
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
#endregion

#region [StaticFiles]
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/imgs"
});
#endregion
app.UseAuthorization();

app.MapControllers();

// Rodar a aplica��o
app.Run();
