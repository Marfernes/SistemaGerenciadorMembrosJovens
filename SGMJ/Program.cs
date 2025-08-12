using Microsoft.EntityFrameworkCore;
using Sgmj.Modelos.Models;
using SGMJ.API.EndPoints;
using SGMJ.API.Services.Implementations;
using SGMJ.API.Services.Interfaces;
using SGMJ.Dados.Banco.Context;
using SGMJ.Dados.Banco.DAL;
using SGMJ.Dados.Models;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Connection string: " + builder.Configuration["ConnectionStrings:ScreenSoundV0"]);

// Add services to the container.
builder.Services.AddDbContext<SgmjContext>((options) =>
{
    options
    .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundV0"])
    .UseLazyLoadingProxies();
});

builder.Services
    .AddIdentityApiEndpoints<PessoaComAcesso>()
    .AddEntityFrameworkStores<SgmjContext>();

builder.Services.AddTransient<DAL<Jovem>>();
builder.Services.AddTransient<DAL<Setor>>();
builder.Services.AddTransient<DAL<Congregacao>>();

builder.Services.AddScoped<IJovemService, JovemService>();
builder.Services.AddScoped<ICongregacaoService, CongregacaoService>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.MaxDepth = 64; 
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

// Configure the HTTP request pipeline.
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
