using dotnetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace dotnetCoreApp.Repositorys
{
	public class ProductRepository : IProductRepository
	{
		private AppDBContext _pr;
		private readonly IWebHostEnvironment webHostEnvironment;
		public ProductRepository(AppDBContext pr)
		{
			_pr = pr;
		}


		///Previous Interface Implementation
		///
		/***************************************/
		public void Delete(Products model)
		{
			_pr.Remove(model);
		}

		public List<Products> GetAll()
		{
			return _pr.Products.ToList();
		}

		public Products GetById(int id)
		{
			if (id == 0)
				return null;
			return _pr.Products.Find(id);
		}

		public void Insert(ProductViewmodel model)
		{
			string filename = UploadedFile(model);
			try
			{
				var productsView = new Products()
				{
					ProductName = model.ProductName,
					Price = model.Price,
					Quantity = model.Quantity,
					productNamePath = filename,
				};

				_pr.Products.Add(productsView);
				_pr.SaveChanges();
				/*_pr.Add(model);
				_pr.SaveChanges();
				*/


			}
			catch
			{

			}
		}
		public void Update(Products model)
		{
			throw new NotImplementedException();
		}

		public string UploadedFile(ProductViewmodel model)
		{
			string uniqueFileName = null;

			if (model.productNamePath != null)
			{
				uniqueFileName = Guid.NewGuid().ToString() + "_" + model.productNamePath.FileName;
				/*string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
				
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					model.productNamePath.CopyTo(fileStream);
				}
				*/
			}
			return uniqueFileName;
		}

		public Products SearchProducts(DateTime Date)
		{
			throw new NotImplementedException();
		}
		/*************************************/
		////End Previous Interface Implementation


	}


}
