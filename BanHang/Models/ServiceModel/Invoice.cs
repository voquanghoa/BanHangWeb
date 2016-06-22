using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	public class Invoice : StoreModel
	{
		public virtual Customer Customer { get; set; }

		public virtual Employee Employee { get; set; }

		public virtual Production Production { get; set; }

		public int DiscountPercent { get; set; }

		public int Price { get; set; }

		public int RetailPrice { get; set; }

		public string Description { get; set; }

	}
}