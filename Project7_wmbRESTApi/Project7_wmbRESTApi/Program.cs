using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project7_wmbRESTApi.Application.ConfigProfiles;
using Project7_wmbRESTApi.Application.DefaultServices.BillDetailService;
using Project7_wmbRESTApi.Application.DefaultServices.BillService;
using Project7_wmbRESTApi.Application.DefaultServices.CustomerService;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService;
using Project7_wmbRESTApi.Application.DefaultServices.TableService;
using Project7_wmbRESTApi.Database.DataBases;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Create DBContext Service
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<WarungContext>(option => option.UseNpgsql(connectionString));

//Add JWT Token Service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// AutoMapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ConfigurationProfile());
});
var mapper = config.CreateMapper();

// Add services to the container.
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddTransient<IMenuAppService, MenuAppService>();
builder.Services.AddTransient<IBillAppService, BillAppService>();
builder.Services.AddTransient<IBillDetailAppService, BillDetailAppService>();
builder.Services.AddTransient<ITableAppService, TableAppService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WARUNG MAKAN BAHARI",
        Version = "v1"
    });
    cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer Scheme. \r\n\r\n Enter 'Bearer' [Space] and then your token to the text input \r\n\r\n" +
                "Example: \"Bearer ey1blablabla\""
    });
    cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{ }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection()

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
