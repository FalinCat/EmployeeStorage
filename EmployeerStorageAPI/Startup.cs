using AutoMapper;
using BLL;
using BLL.Services.Classes;
using BLL.Services.Interfaces;
using DAL;
using EmployeerStorageAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace EmployeerStorageAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddControllers();

            services.AddDbContext<EmploeeContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
                    .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });

                //.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
            });

            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProjectService, ProjectService>();
            

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            var mappingConfig = new MapperConfiguration(mappingConfig => mappingConfig.AddProfile(new MappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<AuthMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
