using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models.Sys;

namespace App.Admin.Controllers
{
    public class AccountController : Controller
    {
        AccountModel account = new AccountModel();
      
        //
        // GET: /Account/

        public ActionResult Index()
        {
            account.Id = "admin";
            account.TrueName = "admin";
            Session["Account"] = account;
            return View();
        }

    }
}
