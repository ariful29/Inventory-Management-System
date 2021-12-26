using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managementEntities1 db = new Inventory_managementEntities1();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.ID)
                                      .ToList();
            return View();
        }
        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale S)
        {
            db.Sales.Add(pur);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");

        }
        [HttpPost]
        public ActionResult Delete(int ID, Purchase per)
        {
            Purchase p = db.Sales.Where(x => x.ID == ID).SingleOrDefault();
            db.Purchases.Remove(p);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Sale p = db.Sales.Where(x => x.ID == ID).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int ID, Purchase pur)
        {
            Purchase p = db.Purchases.Where(x => x.ID == ID).SingleOrDefault();
            p.Purchase_date = pur.Purchase_date;
            p.Purchase_prod = pur.Purchase_prod;
            p.Purchase_qnty = pur.Purchase_qnty;
            return RedirectToAction("DisplayPurchase");

        }
    }
}