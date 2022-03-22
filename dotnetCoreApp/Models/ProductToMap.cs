using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetCoreApp.Models
{
	public class ProductToMap:Profile
	{
		public ProductToMap()
		{
			CreateMap<ProductViewmodel,Products>().ReverseMap();
		}

		
	}
}
