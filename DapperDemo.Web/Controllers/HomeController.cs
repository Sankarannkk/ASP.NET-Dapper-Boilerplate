using DapperDemo.Business.Interfaces;
using DapperDemo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IDapperRepository _repository;
        public HomeController(IDapperRepository Repository)
        {
            this._repository = Repository;
        }
        public ActionResult Index()
        {
           var Model= _repository.GetAll<Project>();

            return View(Model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}