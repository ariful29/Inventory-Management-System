using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managementEntities1 db = new Inventory_managementEntities1();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x=>x.ID).ToList();
            return View(list);

        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product pro)
            {
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("DisplayProduct");
            }
        [HttpGet]
        public ActionResult UpdateProduct(int ID)
        {
            Product pr = db.Products.Where(x => x.ID ==ID).SingleOrDefault();
            return View();

        }
        [HttpPost]
        public ActionResult UpdateProduct(int ID, Product pro)
        {
            Product pr = db.Products.Where(x => x.ID == ID).SingleOrDefault();
            pr.Product_name = pro.Product_name;
            pr.Product_qnty = pro.Product_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult ProductDetail(int ID)
        {
            Product pro = db.Products.Where(x => x.ID == ID).SingleOrDefault();
            return View(pro);
            db.SaveChanges();

        }
        [HttpGet]
        public ActionResult DeleteProduct(int ID)
        {
            Product pro = db.Products.Where(x => x.ID == ID).SingleOrDefault();
            return View(pro);

        }
        [HttpPost]
        public ActionResult DeleteProduct(int ID, Product pro)
        {
            db.Products.Remove(db.Products.Where(x => x.ID == ID).SingleOrDefault());
            db.SaveChanges();
            return View("DisplayProduct");

        }
    }
}