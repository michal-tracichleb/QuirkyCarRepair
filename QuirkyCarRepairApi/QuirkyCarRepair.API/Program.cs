using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuirkyCarRepair.BLL.ServicesRegistration;
using QuirkyCarRepair.DAL;
using QuirkyCarRepair.DAL.RepositoriesRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QuirkyCarRepairContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuirkyCarRepair"));
    options.EnableSensitiveDataLogging(false);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(ServicesRegistration));

var app = builder.Build();

app.Services.GetRequiredService<IMapper>().ConfigurationProvider.AssertConfigurationIsValid();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();