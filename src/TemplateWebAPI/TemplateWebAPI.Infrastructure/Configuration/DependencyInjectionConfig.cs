using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using TemplateWebAPI.Application.Commands;
using TemplateWebAPI.Domain.Communication.Mediator;
using TemplateWebAPI.Domain.Repositories;
using $safeprojectname$.Data.Contexts;
using $safeprojectname$.Data.Repositories;
using $safeprojectname$.Settings;
using $safeprojectname$.Mapper;
using $safeprojectname$.Options;
using Microsoft.EntityFrameworkCore;
using TemplateWebAPI.Application.Events;
using $safeprojectname$.Extensions;

namespace $safeprojectname$.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            //MongoDB
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            services.AddScoped(typeof(MongoDbContext<>));
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            MongoSettings.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            MongoSettings.DatabaseName = configuration.GetSection("MongoConnection:Database").Value;
            MongoSettings.IsSSL = Convert.ToBoolean(configuration.GetSection("MongoConnection:IsSSL").Value);

            services.AddScoped<IProdutoRepository, PedidoRepository>();

            services.AddScoped<INotificationHandler<ProdutoAdiconadoEvent>, ProdutoEventHandler>();
            services.AddScoped<IRequestHandler<AdicionarProdutoCommand, bool>, ProdutoCommandHandler>();

            services.AddAutoMapper(typeof(MappingProfile));


            var assembly = AppDomain.CurrentDomain.Load("TemplateWebAPI.Application");
            services.AddMediatR(assembly);
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddHealthChecks()
                .AddSelfCheck("Self")
                .AddApplicationInsightsPublisher();

            services.AddDbContext<CompraContext>
            (
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    p => p.
                    EnableRetryOnFailure
                    (
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                     )
                    .MigrationsHistoryTable("Migracoes")
                    )


            );
            return services;
        }

    }
}
