using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using truYum1.Models;
using truYum1.Views.truYumContext;
using System.Data.Entity;

namespace truYum1.Controllers
{
    public class truYumController : Controller
    {
        truYumContext t = new truYumContext();
        // GET: truYum
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(menu m)
        {
            t.menus.Add(m);
            t.SaveChanges();

            return View();
        }

        public ActionResult MenuItemsAdmins()
        {

            return View(t.menus.ToList());
        }
        public ActionResult Edit(String name)
        {
            menu r = null;

            foreach (var i in t.menus)
            {
                if (name == i.name)
                {
                    r = i;
                    break;
                }
            }
            if (r == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(r);
            }
        }
        [HttpPost]
        public ActionResult Edit(menu r)
        {

            if (ModelState.IsValid)
            {
                t.Entry(r).State = EntityState.Modified;
                t.SaveChanges();
                ViewBag.msg = "Details Saved Successfully";
                return View();
            }
            return View(r);
        }
        public ActionResult MenuItems()
        {
            List<menu> x = t.menus.ToList();
            List<menu> y = new List<menu>();
            int p = x.Count;
            foreach (var i in x)
            {
                if (i.active == true)
                {
                    y.Add(i);
                }
            }
            return View(y);
        }
        public ActionResult AddToCart(String name)
        {
            menu r = null;
            cart c = new cart();
            foreach (var i in t.menus)
            {
                if (name == i.name)
                {
                    r = i;
                    break;
                }
            }
            if (r == null)
            {
                return HttpNotFound();
            }
            else
            {
                c.name = r.name;
                c.free = r.free;
                c.price = r.price;
                t.carts.Add(c);
                t.SaveChanges();
                return RedirectToAction("Cart");
            }
        }
        public ActionResult Cart()
        {
            List<cart> x = t.carts.ToList();
            int p = x.Count;
            int sum = 0;
            for (int i = 0; i < p; i++)
            {
                sum = sum + x[i].price;
            }
            if (p == 0)
            {
                return RedirectToAction("Empty");
            }
            else
            {
                ViewBag.sum = sum;
                return View(x);
            }
        }
        public ActionResult Empty()
        {
            return View();
        }
        public ActionResult Delete(String name)
        {
            cart r = null;
            foreach (var i in t.carts)
            {
                if (name == i.name)
                {
                    r = i;
                    break;
                }
            }

            t.carts.Remove(r);
            t.SaveChanges();
            return RedirectToAction("Cart");

        }

    }
}