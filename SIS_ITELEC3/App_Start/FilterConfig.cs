﻿using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}