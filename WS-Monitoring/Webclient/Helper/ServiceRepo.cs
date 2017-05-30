using System.Collections.Generic;
using System.ServiceProcess;
using System.Linq;
using System.Diagnostics;
using System;
using Axa.iWARP.Database.DTO.Interface;
using Axa.iWARP.Database.DTO.Domain.Xiwarp;
using Axa.iWARP.Database.DTO;
using System.IO;
using NHibernate.Linq;
using Webclient.Properties;
using NHibernate;
using NHibernate.Criterion;

namespace Webclient.Helper
{
    public enum ChangeStatusTo
    {
        Start,
        Restart,
        Stop
    }

    /// <summary>
    /// ServiceRepo executes the different actions with services.
    /// </summary>
    public class ServiceRepo : IServiceRepo
    {
        /// <summary>
        /// Speichert das FactoryRepository für die Tabelle EVENT_MSG
        /// </summary>
        private readonly IDbFactory<Service> _tbService;
        private NHibernateFactory dbConnection;

        /// <summary>
        /// In the Constructor the servicelists get initalized.
        /// </summary>
        public ServiceRepo()
        {
            dbConnection = new NHibernateFactory(GetDbConfigPath(), Settings.Default.stage);
            _tbService = dbConnection.GetRepository<Service>();
        }

        private string GetDbConfigPath()
        {
            // Pfad zur Datenbankkonfiguration definieren
            string dbConfigurationPath = Environment.GetEnvironmentVariable("IWARP_DB_CONFIG");

            // Pfad zur Datenbankkonfiguration für die Datenbank zusammenstellen
            return String.Concat(dbConfigurationPath, Path.DirectorySeparatorChar,
                Settings.Default.dbConfigFileName);
        }

        public List<Service> GetAll()
        {
            if (dbConnection != null)
            {
                using (ISession session = dbConnection.GetSession())
                {
                    ICriteria criteria = session.CreateCriteria<Service>()
                                .Add(Restrictions.IsNotNull("Status"));

                    return criteria.List<Service>().ToList();
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        public void ChangeStatus(int id, Enum changeStatusTo)
        {
            
        }
    }
}