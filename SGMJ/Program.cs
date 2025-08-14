using Microsoft.EntityFrameworkCore;
using Sgmj.Modelos.Models;
using SGMJ.API.EndPoints;
using SGMJ.API.Mappings; 
using SGMJ.API.Services.Implementations;
using SGMJ.API.Services.Interfaces;
using SGMJ.Dados.Banco.Context;
using SGMJ.Dados.Banco.DAL;
using SGMJ.Dados.Models;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SGMJ.API.Dtos;
using SGMJ.Dados.Repository;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Connection string: " + builder.Configuration["ConnectionStrings:ScreenSoundV0"]);

// ===== Database =====
builder.Services.AddDbContext<SgmjContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundV0"])
           .UseLazyLoadingProxies();
});

// ===== Identity =====
builder.Services
    .AddIdentityApiEndpoints<PessoaComAcesso>()
    .AddEntityFrameworkStores<SgmjContext>();

// ===== DAL =====
builder.Services.AddTransient<DAL<Jovem>>();
builder.Services.AddTransient<DAL<Setor>>();
builder.Services.AddTransient<DAL<Congregacao>>();

// ===== Services =====
builder.Services.AddScoped<IJovemService, JovemService>();
builder.Services.AddScoped<ICongregacaoService, CongregacaoService>();
builder.Services.AddScoped<IJovemRepository, JovemRepository>();


// ===== AutoMapper =====
builder.Services.AddAutoMapper(typeof(MappingsProfile));

// Registra todos os Profiles da pasta Mappings

// ===== Controllers =====
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.MaxDepth = 64;
});

// ===== Swagger =====
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ===== CORS =====
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

// ===== Pipeline =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseStaticFiles();

app.AddEndPointsJovens();
app.AddEndPointsCongregacoes();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
