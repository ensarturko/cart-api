using System.Reflection;
using cart_api.Infrastructure;
using cart_api.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace cart_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DatabaseServer"] ?? "";
            var port = Configuration["DatabasePort"] ?? "";
            var user = Configuration["DatabaseUser"] ?? "";
            var password = Configuration["DatabasePassword"] ?? "";
            var databaseName = Configuration["DatabaseName"] ?? "";

            var connectionString =
                $"Server={server}, {port}; Initial Catalog={databaseName}; User ID= {user}; Password= {password}; MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true";

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "cart_api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DatabaseManagementService.MigrationInitialization(app);
            
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cart Api v2"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
