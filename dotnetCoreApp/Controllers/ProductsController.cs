using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnetCoreApp.Models;
using dotnetCoreApp.Repositorys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Data;

namespace dotnetCoreApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _prodrepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductsController(IProductRepository prodrepo,IMapper maper, IWebHostEnvironment hostEnvironment)
        {
            _prodrepo = prodrepo;
            _mapper = maper;
            webHostEnvironment = hostEnvironment;
        }


        // GET: Products
        public ActionResult Index()
        {
            var products = _prodrepo.GetAll().ToList();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewmodel model, Products st)
        {
            try
            {

                string uniqueFileName = null;
                string filename = null;

                if (model.productNamePath != null)
                {
                     
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "ProductImages");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.productNamePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    //FileStream filestream = System.IO.File.Create(uploadsFolder);
                    using (FileStream filestream = System.IO.File.Create(filePath))
                    {
                        model.productNamePath.CopyTo(filestream);
                        //model.productNamePath.CopyTo(fileStream);

                    }
                }

                if (ModelState.IsValid)
                {

                    _prodrepo.Insert(model);

                    /*var su = _mapper.Map<Products, ProductViewmodel>(st);
                    _prodrepo.Insert(su);
                    */
                }

                //insert using automapper
                /*
                 * var su = _mapper.Map<ProductViewmodel, Products>(prod);
                 * 
                _prodrepo.Insert(su);
                */
                //End using insert as automapper

                // TODO: Add insert logic here
                // _prodrepo.Insert(prod);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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