using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace dotnetCoreApp.Models
{
	public class AppDBContext:DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}
		public DbSet<customer> customersTable { get; set; }
		public DbSet<Products> Products { get; set; }
	}
}
