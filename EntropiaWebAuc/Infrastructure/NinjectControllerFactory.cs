using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using EntropiaWebAuc.Domain;
using System.Configuration;

namespace EntropiaWebAuc.Infrastructure
{
    // реализация пользовательской фабрики контроллеров,  
    // наследуясь от фабрики используемой по умолчанию 
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера 
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext,
    Type controllerType)
        {
            // получение объекта контроллера из контейнера  
            // используя его тип 
            return controllerType == null
              ? null
              : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // конфигурирование контейнера 
            ninjectKernel.Bind<EntropiaDBDataContext>().ToMethod(c => new EntropiaDBDataContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            ninjectKernel.Bind<IRepository>().To<SqlRepository>();
        }
    }
}