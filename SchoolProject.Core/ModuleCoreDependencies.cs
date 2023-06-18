﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //Configuration Of Mediator
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly()));

            //Configuration Of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());



            return services;
        }


    }
}
