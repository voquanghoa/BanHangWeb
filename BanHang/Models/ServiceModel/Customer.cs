using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace BanHang.Models.ServiceModel
{
	public class Customer : ContactModel
	{
		[Column("Group_Id")]
		public int? GroupId { get; set; }

		public virtual CustomerGroup Group { get; set; }
	}
}