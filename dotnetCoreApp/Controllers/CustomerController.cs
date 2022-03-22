using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace dotnetCoreApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDBContext dbc;
        public CustomerController(AppDBContext db)
        {
            dbc = db;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var display = dbc.customersTable.ToList();
            return View(display);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var display = dbc.customersTable.Find(id);
            return View(display);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(customer cus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbc.Add(cus);
                    dbc.SaveChanges();
                   
                }
                
                return RedirectToAction("index");

                // return RedirectToAction(nameof(Index));
            }
            catch
            {
                //return View(cus);
                return RedirectToAction("index");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var display = dbc.customersTable.Find(id);
            return View(display);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(customer cust)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    dbc.Update(cust);
                    dbc.SaveChanges();
                }

                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}