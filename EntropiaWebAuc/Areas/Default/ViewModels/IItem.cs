﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntropiaWebAuc.Areas.Default.ViewModels
{
   public interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
