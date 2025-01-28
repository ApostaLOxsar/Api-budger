using Api_budger;
using Api_budger.Infrastructure;
using Api_budger.Infrastructure.Interface;
using Api_budger.Infrastructure.models;
using Api_budger.Mapper;
using Api_budger.Repositories.Abstractions;
using Api_budger.Repositories.BudgerRepository;
using Api_budger.Repositories.ClientRepositoty;
using Api_budger.Services;
using Api_budger.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBudgerRepository, BudgerRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IBudgerService, BudgerService>();
builder.Services.AddScoped<IPasswordHashService, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
