using HospitalProyect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HospitalProyect.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
		{
		}

		public DbSet<StaffModel> StaffModel { get; set; }
		public DbSet<StaffCategoryModel> StaffCategoryModel { get;set; }
		public DbSet<SpecialtyModel> SpecialtyModel { get; set; }

		public DbSet<UserModel> UserModel { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<StaffModel>()
			.HasOne(s => s.Specialty)
			.WithMany(sp => sp.StaffMembers)
			.HasForeignKey(s => s.SpecialtyId)
			.OnDelete(DeleteBehavior.SetNull);
		}
	}
}
