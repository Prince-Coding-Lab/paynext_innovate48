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
	}
}
