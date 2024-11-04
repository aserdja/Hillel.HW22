using HW22.WebAPI.Data;
using HW22.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW22.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController(AppDbContext context) : Controller
	{
		private readonly AppDbContext _context = context;

		[HttpPost]
		public async Task<IActionResult> AddAsync([FromForm] Product product)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_context.Products.Add(product);
					await _context.SaveChangesAsync();

					return Ok();
				}

				return BadRequest();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error message: {ex.Message}");
			}
		}


		[HttpGet]
		[ResponseCache(Duration = 30)]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				return Ok(await _context.Products.ToListAsync());
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error message: {ex.Message}");
			}
		}


		[HttpDelete]
		public async Task<IActionResult> DeleteByIdAsync(int id)
		{
			try
			{
				var productToRemove = _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
				
				_context.Products.Remove(await productToRemove);
				await _context.SaveChangesAsync();

				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error message: {ex.Message}");
			}
		}


		[HttpPut]
		public async Task<IActionResult> UpdateByIdAsync(int id, [FromBody] Product product)
		{
			try
			{
				var productToUpdate = _context.Products.FirstOrDefault(p => p.Id.Equals(id));

				if (productToUpdate != null)
				{
					productToUpdate.Name = product.Name;
					productToUpdate.Price = product.Price;
					productToUpdate.Stock = product.Stock;

					if (ModelState.IsValid)
					{
						_context.Products.Update(productToUpdate);
						await _context.SaveChangesAsync();

						return Ok();
					}
				}

				return BadRequest();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"{ex.Message}");
			}
		}
	}
}
