using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	public class Order : StoreModel
	{
		public virtual Customer Customer { get; set; }

		public virtual Employee Employee { get; set; }

		public virtual Production Production { get; set; }

		public int Quantity { get; set; }
	}
}