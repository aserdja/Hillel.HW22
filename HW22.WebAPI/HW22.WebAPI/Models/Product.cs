using System.ComponentModel.DataAnnotations;

namespace HW22.WebAPI.Models
{
	public class Product
	{

		public int Id { get; set; }

		[Required(ErrorMessage = "The \"Name\" field cannot be empty!")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "The name cannot be shorter than 3 and more than 50 characters")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "The \"Price\" field cannot be empty!")]
		[Range(0, double.MaxValue, ErrorMessage = $"The price cannot be lower than 0")]
		public double Price { get; set; }

		[Required(ErrorMessage = "The \"Stock\" field cannot be empty")]
		[Range(0, int.MaxValue, ErrorMessage = "The price cannot be lower than 0")]
		public int Stock { get; set; }
	}
}
