using BanHang.Models.Communication.Request.Base;
using BanHang.Models.Dto;
using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Communication.Request
{
	[DataContract]
	public class RequestUser : BaseRequest
	{
		[DataMember(Name ="user")]
		public UserDto User { get; set; }

		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}