using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public EntropiaDBDataContext Db { get; set; }
    }
}