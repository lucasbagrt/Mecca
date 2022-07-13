using AutoMapper;
using Mecca.API.Authorization;
using Mecca.API.Config;
using Mecca.API.Helpers;
using Mecca.API.Model.Context;
using Mecca.API.Repository;
using Mecca.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration["MySQLConnection:MySQlConnectionString"];

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(connection,
    new MySqlServerVersion(new Version(8, 0, 29))));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
services.AddSingleton(mapper);
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddControllers();
services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IJwtUtils, JwtUtils>();

services.AddCors();
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mecca.API v1", Version = "v1" });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
            In = ParameterLocation.Header
        },
        new List<string>()
       }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mecca.API v1"));
}
app.UseCors(x => x
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();