using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel
{
	[Table("Employees")]
	public class Employee : ContactModel
	{
		public string LoginName { get; set; }

		public string Password { get; set; }

		public string JobTitle { get; set; }
	}
}