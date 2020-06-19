using api.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace api
{
    public static class Extensions
    {
        public static void AddNHibernate(
            this IServiceCollection services, string connectionString,
            IWebHostEnvironment env)
        {
            var config = new Configuration().DataBaseIntegration(db =>
            {
                db.Dialect<PostgreSQL83Dialect>();
                db.ConnectionString = connectionString;
                db.BatchSize = 100;

                if (env.IsDevelopment())
                {
                    db.LogSqlInConsole = true;
                    db.LogFormattedSql = true;
                }
            });

            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(Entity).Assembly.ExportedTypes);
            var domainModel = mapper.CompileMappingForAllExplicitlyAddedEntities();
            config.AddMapping(domainModel);

            var sessionFactory = config.BuildSessionFactory();
            services.AddSingleton(sessionFactory);

            if (env.IsDevelopment())
            {
                new SchemaExport(config)
                    .SetOutputFile("db.sql")
                    .Execute(false, false, false);

                NHibernateLogger.SetLoggersFactory(
                    new NHibernate.Logging.Serilog.SerilogLoggerFactory());
            }
        }
    }
}