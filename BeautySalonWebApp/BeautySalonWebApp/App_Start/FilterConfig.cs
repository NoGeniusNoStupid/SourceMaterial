﻿using BeautySalonWebApp.Public;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionAttribute());
        }
    }
}