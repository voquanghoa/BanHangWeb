using BanHang.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Dto
{
	[DataContract]
	public class CustomerGroupDto : NameDto
	{
		[DataMember(Name ="note")]
		public string Note { get; set; }

		[DataMember(Name = "discount")]
		public int DiscountPercent { get; set; }
	}
}