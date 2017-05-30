using Axa.iWARP.Database.DTO.Domain.Xiwarp;
using System;
using System.Collections.Generic;
using System.ServiceProcess;

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
        List<Service> GetAll();
        /// <summary>
        /// Starts the service with the given id.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <param name="name">Name of the associated service.</param>
        /// <returns>The updated service.</returns>
        void ChangeStatus(int id, Enum changeStatusTo);
    }
}
