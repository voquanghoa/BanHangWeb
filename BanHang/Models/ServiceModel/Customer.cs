using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	public class Customer : ContactModel
	{
		public virtual CustomerGroup Group { get; set; }
	}
}