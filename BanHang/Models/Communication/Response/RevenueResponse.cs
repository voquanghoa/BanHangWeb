using BanHang.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Communication.Response
{
	[DataContract]
	public class RevenueResponse
	{
		[DataMember(Name ="total")]
		public int Total { get; set; }

		[DataMember(Name = "invoices")]
		public List<RevenueDto> Invoice { get; set; }
	}
}