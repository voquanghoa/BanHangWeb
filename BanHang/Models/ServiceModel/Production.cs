using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	public class Production : StoreModel
	{
		public int RetailPrice { get; set; }

		public int WholesalePrice { get; set; }

		public int OriginPrice { get; set; }

		public int VipPrice { get; set; }

		public string ImageUrl { get; set; }

		public virtual CategoryProduct Category { get; set; }

		public virtual Brand Brand { get; set; }

		public int Quantity { get; set; }
	}
}