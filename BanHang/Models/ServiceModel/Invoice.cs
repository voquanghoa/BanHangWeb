using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	public class Invoice : StoreModel
	{
		[Column("Customer_Id")]
		public int? CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		[Column("Employee_Id")]
		public int? EmployeeId { get; set; }
		public virtual Employee Employee { get; set; }

		[Column("Production_Id")]
		public int? ProductionId { get; set; }
		public virtual Production Production { get; set; }

		public int DiscountPercent { get; set; }

		public int Price { get; set; }

		public int RetailPrice { get; set; }

		public string Description { get; set; }

		public int Quantity { get; set; }

	}
}