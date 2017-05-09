using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webclient.Models;

namespace Webclient.Helper
{
    /// <summary>
    /// Interface for the ServiceRepository.
    /// </summary>
    interface IServiceRepo
    {
        /// <summary>
        /// This Method returns the extended services, received by the ServiceController.
        /// </summary>
        /// <returns>List of services with extended informations.</returns>
        List<ServiceExtended> GetAll();
        /// <summary>
        /// Starts the service with the given id.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <returns>The updated service.</returns>
        ServiceExtended Start(int id);
        /// <summary>
        /// Stops the service with the given id.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <returns>The updated service.</returns>
        ServiceExtended Stop(int id);
        /// <summary>
        /// Restarts the service with the given id.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <returns>The updated service.</returns>
        ServiceExtended Restart(int id);
    }
}
