using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuirkyCarRepair.BLL;
using QuirkyCarRepair.BLL.ServicesRegistration;
using QuirkyCarRepair.DAL;
using QuirkyCarRepair.DAL.Areas.Identity.Models;
using QuirkyCarRepair.DAL.RepositoriesRegistration;
using QuirkyCarRepair.DAL.Seeder;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QuirkyCarRepairContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuirkyCarRepair"));
    options.EnableSensitiveDataLogging(false);
});

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(ServicesRegistration));

builder.Services.AddCors();

var app = builder.Build();

app.Services.GetRequiredService<IMapper>().ConfigurationProvider.AssertConfigurationIsValid();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<QuirkyCarRepairContext>();
    var passwordHasher = serviceScope.ServiceProvider.GetRequiredService<IPasswordHasher<User>>();
    var seeder = new DataSeeder(context, passwordHasher);
    seeder.SeedDatabase();
}

app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.Run();