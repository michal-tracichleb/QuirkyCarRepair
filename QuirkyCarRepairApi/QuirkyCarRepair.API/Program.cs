using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuirkyCarRepair.BLL.ServicesRegistration;
using QuirkyCarRepair.DAL;
using QuirkyCarRepair.DAL.Areas.Identity;
using QuirkyCarRepair.DAL.RepositoriesRegistration;
using QuirkyCarRepair.DAL.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QuirkyCarRepairContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuirkyCarRepair"));
    options.EnableSensitiveDataLogging(false);
});

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<QuirkyCarRepairContext>()
    .AddApiEndpoints();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

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

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var context = services.GetRequiredService<QuirkyCarRepairContext>();

    context.Database.Migrate();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

    var seeder = new DataSeeder(context, roleManager, userManager);
    await seeder.SeedUsers();
    seeder.SeedDatabase();
}

app.MapIdentityApi<User>();

app.Run();