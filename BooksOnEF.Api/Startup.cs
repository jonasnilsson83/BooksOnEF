using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksOnEF.Data.Repositories;
using BooksOnEF.Services;
using BooksOnEF.Services.Interfaces;
using BooksOnEF.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BooksOnEF.Api
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            //Forsätt här. 
            //Tveksam på att jag vill ha en hård referens ner i datalagret...
            //Kolla solution Clean.Architecture många contributers https://github.com/ardalis/CleanArchitecture

            // Följer mall från https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368
            // https://github.com/alopes2/Medium-MyMusic
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //var conn = System.IO.Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            //solved it by calling Services, that in it's turn calls Data

            //https://stackoverflow.com/questions/9501604/ioc-di-why-do-i-have-to-reference-all-layers-assemblies-in-applications-entry 

            //services.AddDbContext(connectionString);
            services.AddServices();

            services.AddDbContext<Data.BooksOnEFDbContext>(opt =>
                opt.UseLazyLoadingProxies().
                     UseSqlServer(connectionString));

            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<IAuthorRepository, AuthorRepository>();
            //services.AddTransient<IBookRepository, BookRepository>();
            //services.AddTransient<IAuthorService, AuthorService>();
            //services.AddTransient<IBookService, BookService>();


            //services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        );
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
