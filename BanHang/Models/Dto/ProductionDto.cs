using BanHang.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Dto
{
	[DataContract]
	public class ProductionDto : BaseDto
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "retail_price")]
		public int RetailPrice { get; set; }

		[DataMember(Name = "wholesale_price")]
		public int WholesalePrice { get; set; }

		[DataMember(Name = "origin_price")]
		public int OriginPrice { get; set; }

		[DataMember(Name = "vip_price")]
		public int VipPrice { get; set; }

		[DataMember(Name = "image_url")]
		public string ImageUrl { get; set; }

		[DataMember(Name = "category_id")]
		public int CategoryId { get; set; }

		[DataMember(Name = "brand_id")]
		public int BrandId { get; set; }

		[DataMember(Name = "quantity")]
		public int Quantity { get; set; }
	}
}