using BanHang.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Dto
{
	[DataContract]
	public class RevenueDto : BaseDto
	{
		[DataMember(Name = "production")]
		public string Production { get; set; }

		[DataMember(Name = "quantity")]
		public int Quantity { get; set; }

		[DataMember(Name = "employee")]
		public string Employee { get; set; }

		[DataMember(Name = "price")]
		public int Price { get; set; }

		[DataMember(Name = "price_type")]
		public int PriceType { get; set; }

		[DataMember(Name = "customer")]
		public string Customer { get; set; }

		[DataMember(Name = "discount")]
		public int Discount { get; set; }

		[DataMember(Name = "total")]
		public int Total
		{
			get
			{
				return (100 - Discount) * Price * Quantity / 100;
			}
		}
	}
}