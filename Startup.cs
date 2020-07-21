using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikacjaASPNET.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AplikacjaASPNET
{ 
    public class DatabaseSettings
    
{
    public string DatabaseType { get; set; }
    
}

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
            
            services.AddMvc();
            services.AddRazorPages();
            services.AddScoped<IStudentRepository, SQLStudentRepository>();
            services.AddScoped<ICompetitionRepository, SQLKonkursRepository>();

            var databaseSection = Configuration.GetSection("Database");
            var databaseSettings = databaseSection.Get<DatabaseSettings>();
            services.Configure<DatabaseSettings>(Configuration.GetSection("Database"));
            

            if (databaseSettings.DatabaseType == "SQLServer")
            {
                services.AddDbContext<AppDbContext, AppDbContextSQLServer>(ConfigureSQLServer);
            }
            else
            {
                services.AddDbContext<AppDbContext, AppDbContextPostGresSQL>(ConfigurePostgresSQL);
            }
        }
        private void ConfigurePostgresSQL(DbContextOptionsBuilder options)
        {
            string postgresSqlConnectionString = "Server = 127.0.0.1; Port = 5432; Database = ASPNETdatabase; User Id = postgres; Password = admin; ";

            options.UseNpgsql(postgresSqlConnectionString);
            options.EnableSensitiveDataLogging();
        }

        private void ConfigureSQLServer(DbContextOptionsBuilder options)
        {
            string sqlServerConnectionString = "server=(localdb)\\MSSQLLocalDB;database=ASPNETdatabase;Trusted_connection=true";

            options.UseSqlServer(sqlServerConnectionString);
            options.EnableSensitiveDataLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
