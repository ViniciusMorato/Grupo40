using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Adapter.Jwt;
using Adapter.Api.Util;
using Adapter.PostgreSQL;
using Core.Business;
using Core.Interfaces.Authentication;
using Core.Interfaces.Services;
using System;
using Core.Interfaces.Repositories;
using Adapter.PostgreSQL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Newtonsoft;
using System.Text.Json.Serialization;
using Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Registro dos Service
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddTransient<IOrderService, PedidoBusiness>();
builder.Services.AddTransient<IOrderItensService, PedidoItemBusiness>();
builder.Services.AddTransient<IOrderCredCardService, PedidoCartaoCreditoBusiness>();
builder.Services.AddTransient<IOrderPixService, PedidoPixBusiness>();
builder.Services.AddTransient<IUserService, UsuarioBusiness>();
builder.Services.AddTransient<ICredCardService, CartaoCreditoBusiness>();
builder.Services.AddTransient<IUserAddressService, UsuarioEnderecoBusiness>();
builder.Services.AddTransient<IProductService, ProdutoBusiness>();

// Registro dos repositórios
builder.Services.AddTransient<IUserRepository, UsuarioDal>();
builder.Services.AddTransient<IUserAddressRepository, UsuarioEnderecoDal>();
builder.Services.AddTransient<ICredCardRepository, CartaoCreditoDal>();
builder.Services.AddTransient<IOrderRepository, PedidoDal>();
builder.Services.AddTransient<IOrderItensRepository, PedidoItemDal>();
builder.Services.AddTransient<IOrderCredCardrepository, PedidoCartaoCreditoDal>();
builder.Services.AddTransient<IOrderPixRepository, PedidoPixDal>();
builder.Services.AddTransient<IProductRepository, ProdutoDal>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOptions();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


// Registrar a implementação Jwt para a interface IAuthentication
builder.Services.AddSingleton<IAuthentication, ImplJwt>();


builder.Services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
});
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });

    // Exibir os valores e nomes dos enums
    c.UseInlineDefinitionsForEnums(); // Exibe os enums como strings
    c.UseAllOfToExtendReferenceSchemas(); // Para detalhar os valores
});

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value.ToString())),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
