using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	[Table("Employee")]
	public class Employee : StoreModel
	{ 
		public string JobTitle { get; set; }
	}
}