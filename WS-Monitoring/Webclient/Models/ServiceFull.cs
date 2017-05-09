using System.ServiceProcess;

namespace Webclient.Models
{
    /// <summary>
    /// Information from the ServiceController class about a service to be monitored.
    /// </summary>
    public class ServiceFull
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ServiceFull()
        {
        }

        /// <summary>
        /// This constructor parses the ServiceController into the necessary data for this class.
        /// </summary>
        /// <param name="service">ServiceController with valid data.</param>
        public ServiceFull(ServiceController service)
        {
            Name = service.DisplayName;
            Status = service.Status.ToString().ToLower();
            Description = $"Machinename: {service.MachineName} \n" +
                          $"Servicetype: {service.ServiceType.ToString()} \n" +
                          $"Can pause and continue: {service.CanPauseAndContinue}";
        }

        /// <summary>
        /// Id property.
        /// </summary>
        /// <value>The id of the service to be monitored.</value>
        public int Id { get; set; }
        /// <summary>
        /// Name property.
        /// </summary>
        /// <value>The name of the service to be monitored.</value>
        public string Name { get; set; }
        /// <summary>
        /// Status property.
        /// </summary>
        /// <value>The status of the service to be monitored.</value>
        public string Status { get; set; }
        /// <summary>
        /// Description property.
        /// </summary>
        /// <value>The description of the service to be monitored.</value>
        public string Description { get; set; }
        /// <summary>
        /// An explicit identification property.
        /// </summary>
        /// <value>The Identification is the Id and the Name concatenated and every blank is replaced by an '_'</value>
        public string Identification
        {
            get
            {
                return Id + "_" + Name.Replace(' ', '_');
            }
        }
    }
}