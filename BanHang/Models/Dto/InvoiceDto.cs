using BanHang.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Dto
{
	[DataContract]
	public class InvoiceDto : BaseDto
	{
		[DataMember(Name = "customer_id")]
		public int CustomerId { get; set; }

		[DataMember(Name = "Employee_id")]
		public int EmployeeId { get; set; }

		[DataMember(Name = "production_id")]
		public int ProductionId { get; set; }

		public int DiscountPercent { get; set; }

		public int Price { get; set; }

		public int RetailPrice { get; set; }

		public string Description { get; set; }

		public int Quantity { get; set; }
	}
}