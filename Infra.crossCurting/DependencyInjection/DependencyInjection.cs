﻿using Application.CQRS.Validations;
using Domain.CQRS.Interfaces;
using FluentValidation;
using Infra.Data.CQRS.Contexto;
using Infra.Data.CQRS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InfraCrossCutting.CQRS.DependencyInjection
{
    public static class DependencyInjection
    {



        public static IServiceCollection AddInfrastructure(
                this IServiceCollection services,
                IConfiguration configuration)
        {
            var mySqlConnection = configuration
                                  .GetConnectionString("DefaultConnection");

            services.AddDbContext<ContextoDB>(options =>
                             options.UseMySql(mySqlConnection,
                             ServerVersion.AutoDetect(mySqlConnection)));

            // Registrar IDbConnection como uma instância única
            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new MySqlConnection(mySqlConnection);
                connection.Open();
                return connection;
            });




            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();


            //services.AddScoped<IMemberRepository, MemberRepository>();

            //services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

            var myhandlers = AppDomain.CurrentDomain.Load("Application.CQRS");
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(myhandlers);
                 cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.Load("Application.CQRS"));

            return services;
        }
    }
}