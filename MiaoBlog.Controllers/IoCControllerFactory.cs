using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiaoBlog.Controllers
{
    public class IoCControllerFactory:DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {

            return ObjectFactory.GetInstance(controllerType) as IController;
            //return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}
