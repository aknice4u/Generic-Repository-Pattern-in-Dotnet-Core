using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetCoreApp.Models;

namespace dotnetCoreApp.Repositorys
{
	public interface IProductRepository
	{
		List<Products> GetAll();
		Products GetById(int id);
		void Insert(ProductViewmodel model);
		void Update(Products model);
		void Delete(Products model);
		string UploadedFile(ProductViewmodel model);
		Products SearchProducts(DateTime Date);
	}
}
