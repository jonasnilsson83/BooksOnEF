using BooksOnEF.Data;
using BooksOnEF.Data.Repositories;
using BooksOnEF.Services.Interfaces;
using BooksOnEF.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BooksOnEF.Services
{
   public static  class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<BooksOnEFDbContext>(opt => 
                opt.UseSqlServer(connectionString));


        public static void AddServices(this IServiceCollection services)
        {

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();

        }

        //public static List<Type> GetTypesAssignableFrom<T>(this Assembly assembly)
        //{
        //    return assembly.GetTypesAssignableFrom(typeof(T));
        //}
        //public static List<Type> GetTypesAssignableFrom(this Assembly assembly, Type compareType)
        //{
        //    List<Type> ret = new List<Type>();
        //    foreach (var type in assembly.DefinedTypes)
        //    {
        //        if (compareType.IsAssignableFrom(type) && compareType != type)
        //        {
        //            ret.Add(type);
        //        }
        //    }
        //    return ret;
        //}

    }
}
