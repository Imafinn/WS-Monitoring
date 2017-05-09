using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webclient.Helper;

namespace Webclient.Binding
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceRepo>().To<ServiceRepo>();
        }
    }
}