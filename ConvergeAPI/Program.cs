using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Service;
using BusinessObjectsLayer.Entities;
using ConvergeAPI.HUBS;
using DataAccess.DbContext;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Configure JWT settings
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("Jwt").Bind(jwtSettings);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
Console.WriteLine("Issuer: " + jwtSettings.Issuer);
Console.WriteLine("Audience: " + jwtSettings.Audience);
Console.WriteLine("SecretKey: " + jwtSettings.SecretKey);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
    };
});

 
//Service registrations
builder.Services.AddHttpContextAccessor();
 

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IUsptoRankingService, UsptoRankingService>(); 
builder.Services.AddScoped<IUsptoRankingRepository, UsptoRankingRepository>();

builder.Services.AddSingleton<HttpContextAccessor>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Uspto Sale Ranking API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});
var app = builder.Build();
app.UseCors("AllowAllOrigins");  
app.UseAuthentication();         
app.UseAuthorization();          
app.UseStaticFiles();            
app.MapControllers();
app.MapHub<RankingHub>("/rankingHub");
app.UseSwagger();
app.UseSwaggerUI(); /*Local*/


/*Live*/
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = string.Empty; // Swagger UI available at root (e.g., http://217.76.53.78:9118/)
});
app.Run();  
