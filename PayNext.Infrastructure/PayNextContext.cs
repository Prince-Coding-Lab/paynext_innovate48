using Microsoft.EntityFrameworkCore;
using PayNext.Core.Entities;
using System;

namespace PayNext.Infrastructure
{
	public class PayNextContext : DbContext
	{
		public PayNextContext(DbContextOptions<PayNextContext> options) : base(options)
		{
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<Bill> Bills { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Card>().HasData(
				 new Card { Id = 1, CardNumber = "5421765209285822", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 2, CardNumber = "5383249064902017", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 3, CardNumber = "5547240944242164", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 4, CardNumber = "5537555179872381", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 5, CardNumber = "5447906631230792", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 6, CardNumber = "4064087200235085", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 7, CardNumber = "4556610932416767", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 8, CardNumber = "4024007173812818", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 9, CardNumber = "4024007180147869", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now },
				 new Card { Id = 10, CardNumber = "4024007199373613", IssueDate = DateTime.Now, ValidDate = DateTime.Now.AddYears(3), IsActive = true, IsActiveAtApp = false, CreatedDate = DateTime.Now });
		}
	}
}
