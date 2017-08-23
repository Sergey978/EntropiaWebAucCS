﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using EntropiaWebAuc.Domain.Concrete;
using EntropiaWebAuc.Domain.Abstract;
using EntropiaWebAuc.Domain.Entities;
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
            ninjectKernel.Bind<IStadartItemCategoryRepo>().To<EFStandartItemCategoryRepo>();
            ninjectKernel.Bind<ICustomItemRepository>().To<EfCustomItemRepository>();
            ninjectKernel.Bind<ISelectedStandartItemRepo>().To<EFSelectedStandartItemRepo>();
        }
    }
}