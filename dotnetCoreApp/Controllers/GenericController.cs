using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetCoreApp.Models;
using dotnetCoreApp.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetCoreApp.Controllers
{
    public class GenericController : Controller
    {
        private readonly IGenericRepository<Products> _prodrepo;
        public GenericController(IGenericRepository<Products> prodrepo)
        {
            _prodrepo = prodrepo;
        }
        // GET: Generic
        public ActionResult Index()
        {
            var products = _prodrepo.GetAll().ToList();
            return View(products);
        }

        // GET: Generic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Generic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Generic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products prod)
        {
            try
            {
                _prodrepo.Insert(prod);
                _prodrepo.Save();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
               
                return View(e.Message);
            }
        }

        // GET: Generic/Edit/5
        public ActionResult Edit(int id)
        {
            var display = _prodrepo.GetById(id);
            return View(display);
        }

        // POST: Generic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products prod)
        {
            try
            {
                // TODO: Add update logic here
                _prodrepo.Update(prod);
                _prodrepo.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Generic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Generic/Delete/5
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