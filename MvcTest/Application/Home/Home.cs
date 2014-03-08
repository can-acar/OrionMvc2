using System;
using System.Collections.Generic;
using System.Linq;
using OrionMvc.Web;

namespace MvcTest.Application.Home
{
    public class Home : Controller
    {
        public void Index()
        {


            ViewBag.Content = "TestHome";
            ViewBag["deneme"] = "dfgdfg";
            ViewBag["Body"] = "body içeriği";

            this["Title"] = " Bu bir Title";
            //this["LabelBody"] = View("Home");
            ViewBag.testgibi = " test gibi";
            ViewBag.HomeDeneme = "Çalıştı mı ?";
            //ViewBag.DenemGibi = new ViewData();
            //ViewBag.DenemGibi.TestTitle = "test title";
            // ViewBag.LabelBody = View("Home");
			
        }
    }
}
