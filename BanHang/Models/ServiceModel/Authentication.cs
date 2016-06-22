using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	public class Authentication : BaseModel
	{
		public virtual Employee Employee { get; set; }

		public Guid SessionCode { get; set; }
	}
}