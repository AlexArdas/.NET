using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Notifications.BL.Services;
using Notifications.BL.Validation;
using Notifications.Data.Configurations;
using Notifications.Data.Repositories;
using Notifications.Domain.Models.Email;
using Notifications.Domain.Repositories;
using Notifications.Domain.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Notifications
{
    /// <summary>
    /// Конфигурация зависимостей (DI) для приложения Notifications.
    /// </summary>
    public static class DIConfig
    {

        /// <summary>
        /// Добавляет Swagger в сервисы приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns>Коллекция сервисов с добавленным Swagger.</returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notifications", Version = "v1" }); 
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Notifications.WebAPI.xml"));
            });

            return services;
        }

        /// <summary>
        /// Добавляет DbContext в сервисы приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        /// <returns>Коллекция сервисов с добавленным DbContext.</returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NotificationsContext>(opt =>
            {
                opt.UseMySql(connectionString, ServerVersion.Parse("8.0.26"),
                    mysqlOptions =>
                    {
                        mysqlOptions.EnableStringComparisonTranslations();
                        mysqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                    });
            });

            return services;
        }

        /// <summary>
        /// Добавляет репозитории в сервисы приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns>Коллекция сервисов с добавленными репозиториями.</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmailLogRepository, EmailLogRepository>();

            return services;
        }

        /// <summary>
        /// Добавляет сервисы в сервисы приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns>Коллекция сервисов с добавленными сервисами.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSenderService, EmailSenderService>();

            return services;
        }

        /// <summary>
        /// Добавляет настройки в сервисы приложения.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация приложения.</param>
        /// <returns>Коллекция сервисов с добавленными настройками.</returns>
        public static IServiceCollection AddSettings(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var emailConfiguration = new EmailSettings();

            configuration.GetSection("Email").Bind(emailConfiguration);

            serviceCollection.AddSingleton(emailConfiguration);

            return serviceCollection;
        }

        /// <summary>
        /// Добавляет валидаторы в сервисы приложения.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        /// <returns>Коллекция сервисов с добавленными валидаторами.</returns>
        public static IServiceCollection AddValidators(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddValidatorsFromAssemblyContaining<SendEmailsCommandValidator>();
            return serviceCollection;
        }
    }
}
