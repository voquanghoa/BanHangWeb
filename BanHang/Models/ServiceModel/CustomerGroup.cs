using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	public class CustomerGroup : StoreModel
	{ 
		public string Note { get; set; }

		public int DiscountPercent { get; set; }
	}
}