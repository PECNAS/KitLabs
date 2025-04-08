using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
	public class MobileContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Segment> Segments { get; set; }
		public DbSet<Member> Members { get; set; }
		public MobileContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
