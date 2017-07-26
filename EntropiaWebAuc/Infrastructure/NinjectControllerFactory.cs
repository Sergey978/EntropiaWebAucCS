using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using EntropiaWebAuc.Concrete;
using EntropiaWebAuc.Abstract;
using EntropiaWebAuc.Entities;
using System.Collections.Generic;
using System.Linq;

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
            ninjectKernel.Bind<IStandartItemRepository>().To<EfStandartItemRepository>();
        }
    }
}