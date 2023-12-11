using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<TobetoCourseAcademyContext>(options => options.UseInMemoryDatabase("nArchitecture"));
            services.AddDbContext<TobetoCourseAcademyContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoCourseAcademy")));
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICourseDal, EfCourseDal>();
            services.AddScoped<IInstructorDal, EfInstructorDal>();
            return services;
        }
    }
}
