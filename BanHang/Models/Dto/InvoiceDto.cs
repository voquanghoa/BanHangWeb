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

		[DataMember(Name = "discount_percent")]
		public int DiscountPercent { get; set; }

		[DataMember(Name = "price")]
		public int Price { get; set; }

		[DataMember(Name = "retail_price")]
		public int RetailPrice { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "quantity")]
		public int Quantity { get; set; }
	}
}