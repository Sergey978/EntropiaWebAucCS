using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Abstract;
using EntropiaWebAuc.Entities;

namespace EntropiaWebAuc.Controllers
{
    public class StandartItemController : Controller
    { 
        private IStandartItemRepository repository;
        // GET: StandartItem
        public StandartItemController( IStandartItemRepository repository)
        {

            this.repository = repository;
        }

        public ViewResult List()
        {
            return View(repository.StandartItems);
        }
    }
}