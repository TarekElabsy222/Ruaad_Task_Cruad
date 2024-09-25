using Microsoft.EntityFrameworkCore;

namespace Ruaad_Task__Cruad.Models
{
	public class ApplicationDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-S6Q0D90\\TAREKELABSY;Database=InStockDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
		}
		public DbSet<Product> Products { get; set; }
	}
}
