using FluentValidation;
using FluentValidation.AspNetCore;
using Gamechain.Application;
using Gamechain.Application.AppServices.Auth;
using Gamechain.Application.AppServices.Auth.Validators;
using Gamechain.Application.AppServices.Publishers.Validators;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Application.Contracts.Requests.Auth;
using Gamechain.Application.Contracts.Requests.Publishers;
using Gamechain.Domain.Entities.Aggregates.User;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;
using Gamechain.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    options.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtAuth:SecretKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddCors();

builder.Services.AddDbContext<GamechainDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(GamechainDbContext)));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<GamechainDbContext>();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApplication();

builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IPublisherRepository, PublisherRepository>();

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
