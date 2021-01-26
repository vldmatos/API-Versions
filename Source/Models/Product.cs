namespace API.Models
{
	public class Product
	{
		public static readonly string[] Types = new[]
		{
			"Book", "Pen", "Ink", "Paper", "Pencil", "Clips", "Ruler", "Glue", "Eraser"
		};

		public string Name { get; init; }

		public double FullPrice { get; init; }

		public double ReducedPrice { get; init; }
	}
}
