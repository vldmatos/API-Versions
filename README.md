# API-Versions
*An elegant way to version API*


## Using
- .Net 5
- Web API
- Microsoft.AspNetCore.Mvc.Versioning  


### How to use

> - Run API as Kestrel  
> - dotnet run  
> - Application open port 5000  
> - Use Postman to see informations of API   

### Informations
> - **Versions**
>   - 1.0 - Deprecated
>   - 2.0 - Supported  
>   
> - **Headers Version** 
>   - version
>   - api-version
>   - x-version
>   


## Different version on the same controller
It is possible to apply versions in the same file,  
Not necessary to create multiple folders with the same controller.  

```c#
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
```

### Result on Postman:

![result](/Assets/print.png)