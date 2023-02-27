using MedicineManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using MedicineManagerAPI;
using FluentValidation.AspNetCore;
using MedicineManagerAPI.Service;
using MedicineManagerAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using MedicineManagerAPI.Middleware;
using MedicineManagerAPI.Models.Validators;
using MedicineManagerAPI.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MedicineManagerDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MedicineManagerDbConnection")));
builder.Services.AddScoped<MMSeeder>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
builder.Services.AddScoped<IValidator<MedicineCabinetQuery>, MedicineCabinetQueryValidator>();

builder.Services.AddScoped<IMedicineCabinetService, MedicineCabinetService>();
builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler >();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddHttpContextAccessor();
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});




var app = builder.Build();

// Configure the HTTP request pipeline.
var scoop = app.Services.CreateScope();
var seeder = scoop.ServiceProvider.GetService<MMSeeder>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseResponseCaching();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
seeder.Seed();
app.Run();
