﻿using Abp.AspNetCore.Mvc.Authorization;
using BoilerPlate.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BoilerPlateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
