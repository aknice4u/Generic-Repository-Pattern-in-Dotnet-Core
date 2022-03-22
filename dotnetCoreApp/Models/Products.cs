using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetCoreApp.Models
{
	public class Products
	{
		[Key]
		public int productId { get; set; }
		[Display(Name = "Product Name")]
		public string ProductName { get; set; }
		//[Required(ErrorMessage = "Please, Enter Your Email Address")]
		[Display(Name = "Price")]
		//[DataType(DataType.EmailAddress)]
		public string Price { get; set; }
		[Display(Name = "Quantity")]
		public int Quantity { get; set; }
		public string productNamePath { get; set; }
		
	}
}
