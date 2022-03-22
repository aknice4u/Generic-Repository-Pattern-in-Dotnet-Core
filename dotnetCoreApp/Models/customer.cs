using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace dotnetCoreApp.Models
{
	public class customer
	{
		[Key]
		public int customerId { get; set; }
		//[Required(ErrorMessage="Please, Enter Your Full NAme")]
		[Display(Name="Customer Name")]
		public string Name { get; set; }
		//[Required(ErrorMessage = "Please, Enter Your Email Address")]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public string Phone { get; set; }
		public int Status { get; set; }
	}
}
