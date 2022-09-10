using LibrarySystem.Infrastructure.Core;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

AppConfiguration.Config(builder.Services, builder.Configuration.GetConnectionString("LibraryContext"));

#region CORS

builder.Services.AddCors(options =>
{  
    options.AddPolicy("EnableCORS", config =>
    {
        config.AllowAnyOrigin()
            .AllowAnyHeader()
            .WithMethods("GET", "POST", "PUT", "DELETE")
            .Build();
    });
});


#endregion


#region Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(string.Format(@"{0}\LibraryApi.xml",
        System.AppDomain.CurrentDomain.BaseDirectory));
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "LibraryApi",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",

        In = ParameterLocation.Header,

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});


#endregion


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
