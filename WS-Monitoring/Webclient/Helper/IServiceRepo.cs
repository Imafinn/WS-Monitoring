using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webclient.Models;

namespace Webclient.Helper
{
    interface IServiceRepo
    {
        List<ServiceExtended> GetAll();
        ServiceExtended Start(int id);
        ServiceExtended Stop(int id);
        ServiceExtended Restart(int id);
    }
}
