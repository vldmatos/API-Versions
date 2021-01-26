using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0", Deprecated = true)]
	[ApiVersion("2.0")]
	public class Catalog : ControllerBase
	{
		[HttpGet]
		[Route("Products")]
		[MapToApiVersion("1.0")]
		public IEnumerable<Product> GetProductsFullPrice()
		{
			var random = new Random();
			var price = random.NextDouble();

			return Enumerable.Range(1, 3).Select(index =>
			new Product
			{
				Name = Product.Types[random.Next(Product.Types.Length)],
				FullPrice = price
			})
			.ToArray();
		}


		[HttpGet]
		[Route("Products")]
		[MapToApiVersion("2.0")]
		public IEnumerable<Product> GetProductsReducedPrice()
		{
			var random = new Random();
			var price = random.NextDouble();

			return Enumerable.Range(1, 3).Select(index =>
			new Product
			{
				Name = Product.Types[random.Next(Product.Types.Length)],
				FullPrice = price,
				ReducedPrice = price * 0.1

			})
			.ToArray();
		}
	}
}
