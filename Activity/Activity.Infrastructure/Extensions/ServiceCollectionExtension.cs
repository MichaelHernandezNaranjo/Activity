using Activity.Core.Entities;
using Activity.Core.Interfaces;
using Activity.Core.Services;
using Activity.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, authRepository>();
            services.AddScoped<IAuthService, authService>();

            services.AddScoped<IRepository<companyRequest, companyResponse>, companyRepository>();
            services.AddScoped<IService<companyRequest,companyResponse>,companyService>();

            services.AddScoped<IRepository2<projectRequest, projectResponse>, projectRepository>();
            services.AddScoped<IService2<projectRequest, projectResponse>, projectService>();

            services.AddScoped<IRepository2<userRequest, userResponse>, userRepository>();
            services.AddScoped<IService2<userRequest, userResponse>, userService>();

            services.AddScoped<IRepository3<sprintRequest, sprintResponse>, sprintRepository>();
            services.AddScoped<IService3<sprintRequest, sprintResponse>, sprintService>();

            services.AddScoped<IRepository3<taskRequest, taskResponse>, taskRepository>();
            services.AddScoped<IService3<taskRequest, taskResponse>, taskService>();

            services.AddScoped<IRepository3<taskStatusRequest, taskStatusResponse>, taskStatusRepository>();
            services.AddScoped<IService3<taskStatusRequest, taskStatusResponse>, taskStatusService>();

            return services;
        }
    }
}
