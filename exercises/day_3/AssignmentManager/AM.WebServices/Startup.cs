using AM.Repositories.Implementations;
using AM.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.Data.DbContexts;
using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Implementations;

namespace AM.WebServices
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(oprtions =>
            {
                oprtions.AddPolicy(MyAllowSpecificOrigins,
                    builder => {
                        builder.WithOrigins("https://localhost:44336")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                });          
            });

            services.AddDbContext<AssignmentManagerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MainDB"))
            );
            services.AddControllers();
            services.AddScoped<DbContext, AssignmentManagerDbContext>();
            services.AddTransient<IAssignmentRepository, AssignmentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAssignmentService, AssignmentService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
