using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountSolution.SqliteClassLibrary;
//using AccountSolution.FromAccountClassLibrary.Entities;

namespace AccountSolution.WebApplication.Controllers
{
    public class PriceController : Controller
    {
        SqlitePriceProvider db = new SqlitePriceProvider("web");

        // GET: Price
        public ActionResult Index()
        {
            //db.ConnectionString = "D:\\VS\\VS2017\\AccountSolution\\AccountSolution.WebApplication\\App_Data\\FromAccount.db";
            //db.ConnectionString = "~\\App_Data\\FromAccount.db";
            db.ConnectionString = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\FromAccount.db";
            //db.ConnectionString = HttpContext.Server.MapPath("~/App_Data/FromAccount.db");
            return View(db.GetPrice().Where(p => p.StockPriceGroupeID != 0).OrderBy(p => p.Stock).Take(15));
        }

        // GET: Price/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Price/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Price/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Price/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Price/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Price/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Price/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
