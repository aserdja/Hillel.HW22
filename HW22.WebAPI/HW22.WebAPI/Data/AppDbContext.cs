using HW22.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HW22.WebAPI.Data
{
	public class AppDbContext : DbContext
	{
		public virtual DbSet<Product> Products => Set<Product>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.HasKey(p => p.Id);
		}
	}
}
