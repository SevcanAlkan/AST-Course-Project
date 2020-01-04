﻿using MovieStore.UI.Enums;
using MovieStore.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UI.Helper
{
    public static class FilterHelper
    {
        public static ToolbarFilter New(string name, int orderNum, FilterTypeEnum type, string labelText = "", List<FilterOption> items = null)
        {
            ToolbarFilter filter = new ToolbarFilter();

            filter.Name = name;
            filter.OrderNum = orderNum;
            filter.Type = type;
            filter.LabelText = labelText;
            filter.Items = items;

            return filter;
        }
    }
}
