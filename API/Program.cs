using API.Entities;
using API.Infra;
using API.Mappers;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using AutoMapper;
using static API.Infra.DatabaseSettings;

var builder = WebApplication.CreateBuilder(args);

// ** Configuração de Serviços **

// Configuração do banco de dados
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

// Configuração de Injeção de Dependência (DI)
builder.Services.AddScoped<IMongoRepository<News>, MongoRepository<News>>();
builder.Services.AddScoped<NewsService>();

// Adicionando AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToViewModelMapping), typeof(ViewModelToEntityMapping));

// Adicionando Controllers
builder.Services.AddControllers();

// Adicionando Swagger para documentação da API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

var app = builder.Build();

// ** Configuração do Pipeline de Requisição HTTP **
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Rodar a aplicação
app.Run();
