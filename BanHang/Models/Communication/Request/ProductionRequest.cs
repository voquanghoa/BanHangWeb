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
	public class ProductionRequest : BaseRequest
	{
		[DataMember(Name = "data")]
		public ProductionDto Data { get; set; }

		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}