﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntropiaWebAuc.Domain.Entities;

namespace EntropiaWebAuc.Domain.Abstract
{
   public interface ISelectedStandartItemRepo
    {
        IQueryable<SelectedStandartItem> SelectedStandartItems { get; }
        void SaveSelectedStandartItem(SelectedStandartItem standartItem);
        SelectedStandartItem DeleteSelectedStandartItem(SelectedStandartItem standartItem);
    }
}