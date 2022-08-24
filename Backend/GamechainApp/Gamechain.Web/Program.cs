using FluentValidation;
using FluentValidation.AspNetCore;
using Gamechain.Application.AppServices.Auth;
using Gamechain.Application.AppServices.Auth.Validators;
using Gamechain.Application.Contracts.Interfaces.AppServices;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Application.Contracts.Requests.Auth;
using Gamechain.Domain.Entities.Aggregates.User;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;
using Gamechain.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtAuth:SecretKey"]))
    };
});

builder.Services.AddCors();

builder.Services.AddDbContext<GamechainDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(GamechainDbContext)));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<GamechainDbContext>();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();

builder.Services.AddTransient<IAuthAppService, AuthAppService>();

builder.Services.AddTransient<IAuthRepository, AuthRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
