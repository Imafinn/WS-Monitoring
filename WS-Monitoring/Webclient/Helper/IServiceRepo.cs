using System.Collections.Generic;
using System.ServiceProcess;
using Webclient.Models;

namespace Webclient.Helper
{
    /// <summary>
    /// Interface for the ServiceRepository.
    /// </summary>
    public interface IServiceRepo
    {
        /// <summary>
        /// This Method returns the extended services, received by the ServiceController.
        /// </summary>
        /// <returns>List of services with extended informations.</returns>
        List<ServiceFull> GetAll();
        ServiceFull GetServiceById(int id);
        /// <summary>
        /// Starts the service with the given id.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <param name="name">Name of the associated service.</param>
        /// <returns>The updated service.</returns>
        ServiceControllerStatus Start(int id, string name);
        /// <summary>
        /// Stops the service with the given id.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <param name="name">Name of the associated service.</param>
        /// <returns>The updated service.</returns>
        ServiceControllerStatus Stop(int id, string name);
        /// <summary>
        /// Restarts the service with the given id.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <param name="name">Name of the associated service.</param>
        /// <returns>The updated service.</returns>
        void Restart(int id, string name);
    }
}
