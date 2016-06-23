using BanHang.Models.Communication.Request.Base;
using BanHang.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Communication.Request
{
	[DataContract]
	public class CustomerRequest : BaseRequest
	{
		[DataMember(Name ="id")]
		public int Id { get; set; }

		[DataMember(Name = "data")]
		public CustomerDto Data { get; set; }
	}
}