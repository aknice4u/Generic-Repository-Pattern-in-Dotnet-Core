using dotnetCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace dotnetCoreApp.Repositorys
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{

		private AppDBContext _context;
		private DbSet<T> table;

		public GenericRepository(AppDBContext context)
		{
			this._context = context;
			table = _context.Set<T>();
		}
		public void Delete(T model)
		{
			T exists = table.Find(model);
			table.Remove(exists);
		}

		public List<T> GetAll()
		{
			return table.ToList();
		}

		public T GetById(int id)
		{
			return table.Find(id);
		}

		public void Insert(T model)
		{
			table.Add(model);
			

		}
		public void Save()
		{
			
			_context.SaveChanges();
		}

		public void Update(T model)
		{
			//table.Attach(model);
			//_context.Entry(model).State = EntityState.Modified;
			_context.Update(model);
		}
	}

	
}
