using dotnetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetCoreApp.Repositorys
{
	public interface IGenericRepository<T> where T : class
	{

		List<T> GetAll();
		T GetById(int id);
		void Insert(T model);
		void Update(T model);
		void Delete(T model);
		void Save();
	}
}
