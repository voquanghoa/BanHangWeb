namespace BanHang
{
	using Models.ServiceModel;
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class BanHangDataContext : DbContext
	{
		public BanHangDataContext()
			: base("name=DefaultConnection")
		{
		}

		public virtual DbSet<Brand> Brands { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Invoice> Invoices { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Production> Productions { get; set; }
	}
}