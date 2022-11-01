using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Refit;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json;
using terra_test_template.Repositories.V1.GithubServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddRefitClient<IGithubRepository>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("GithubBaseUrl"));
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Api Test Terra",
        Version = "v1",
        Description = "Api construida para Lista Repositórios, webhook no Github",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Guilherme de Almeida dos Santos",
            Email = "guilhermealmeida48@gmail.com",
            Url = new Uri("http://guilhermealmeidateste.com.br")
        }
    });

    c.AddSecurityDefinition("token", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por Favor, utilize token do github <TOKEN>",
        Name = "token",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "token"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Terra.Test V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
