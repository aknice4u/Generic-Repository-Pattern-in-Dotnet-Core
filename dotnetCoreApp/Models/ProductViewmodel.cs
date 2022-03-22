using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetCoreApp.Models
{
	public class ProductViewmodel
	{
		[Display(Name = "Product Name")]
		public string ProductName { get; set; }
		//[Required(ErrorMessage = "Please, Enter Your Email Address")]
		[Display(Name = "Price")]
		//[DataType(DataType.EmailAddress)]
		public string Price { get; set; }
		[Display(Name = "Quantity")]
		public int Quantity { get; set; }
		//public string productNamePath { get; set; }
		public IFormFile productNamePath { get; set; }

		
	}
}
