using System;
using System.Text;
using Book_Libirary_Api.AutoMapper;
using Book_Libirary_Api.Configuration;
using Book_Libirary_Api.Core.Repositories;
using Book_Libirary_Api.Data;
using Book_Libirary_Api.Data.Implimentations;
using Book_Libirary_Api.DTO;
using Book_Libirary_Api.Entities;
using Book_Libirary_Api.Interfaces;
using Book_Libirary_Api.Services;
using Book_Libirary_Api.Validator.UserValidator;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Book_Libirary_Api
{
	public static class ServiceRegistration
	{
		public static void Registration(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddControllers()
				.AddFluentValidation(d => d.RegisterValidatorsFromAssemblyContaining<LoginValidator>());

			services.AddCors(option =>
			{
				option.AddDefaultPolicy(policy =>
				{
					policy.AllowAnyHeader()
					.AllowCredentials()
					.AllowAnyMethod()
					.SetIsOriginAllowed(o => true)
					.WithOrigins("http://localhost:8080");
				});
			});
			services.AddSignalR();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddDbContext<DataContext>(context =>
			{
				context.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            });

            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;
                option.SignIn.RequireConfirmedPhoneNumber = false;
                option.SignIn.RequireConfirmedAccount = true;
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            }).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

            services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(jwt =>
			{
				jwt.TokenValidationParameters = new TokenValidationParameters
				{
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
			});
            services.AddAuthorization();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Book-Libirary-Api", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
            services.AddHttpContextAccessor();
            services.Configure<DataProtectionTokenProviderOptions>(option =>
            {
                option.TokenLifespan = TimeSpan.FromMinutes(10);

            });
			services.AddAutoMapper(typeof(SliderProfile).Assembly);
            services.AddHttpContextAccessor();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IFileService, FileService>();
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
	}
}

