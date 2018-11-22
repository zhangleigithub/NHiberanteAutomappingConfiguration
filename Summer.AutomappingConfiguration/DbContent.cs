using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Summer.AutomappingConfiguration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Collections;
using System.IO;
using NHibernate.Cfg;

namespace Summer.AutomappingConfiguration
{
    /// <summary>
    /// DbContent
    /// </summary>
    public class DbContent
    {
        /// <summary>
        /// Mysql
        /// </summary>
        /// <param name="connectionString">connectionString</param>
        /// <param name="assemblies">assemblies</param>
        /// <param name="ignoredBaseTypes">ignoredBaseTypes</param>
        /// <param name="includeBaseTypes">includeBaseTypes</param>
        /// <returns>ISessionFactory</returns>
        public static ISessionFactory CreateMysqlSessionFactory(string connectionString, string[] assemblies)
        {
            PersistenceModelGenerator generator = new PersistenceModelGenerator();

            string exportDir = "AppData\\Automapping";

            if (!Directory.Exists(exportDir))
            {
                Directory.CreateDirectory(exportDir);
            }

            var configuration = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(m => m.AutoMappings.Add(generator.Generate(assemblies.Select(Assembly.LoadFrom).ToArray())).ExportTo(exportDir))
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            return configuration.BuildSessionFactory();
        }

        /// <summary>
        /// configFile
        /// </summary>
        /// <param name="configFile">configFile</param>
        /// <param name="assemblies">assemblies</param>
        /// <param name="ignoredBaseTypes">ignoredBaseTypes</param>
        /// <param name="includeBaseTypes">includeBaseTypes</param>
        /// <returns>ISessionFactory</returns>
        public static ISessionFactory CreateSessionFactory(string configFile, string[] assemblies)
        {
            PersistenceModelGenerator generator = new PersistenceModelGenerator();

            string exportDir = "AppData\\Automapping";

            if (!Directory.Exists(exportDir))
            {
                Directory.CreateDirectory(exportDir);
            }

            try
            {
                var configuration = Fluently.Configure(new Configuration().Configure(configFile))
                .Mappings(m => m.AutoMappings.Add(generator.Generate(assemblies.Select(Assembly.LoadFrom).ToArray())).ExportTo(exportDir))
                .BuildConfiguration();

                var exporter = new SchemaExport(configuration);
                exporter.Execute(true, true, false);

                return configuration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
