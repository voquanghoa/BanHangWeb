using BanHang.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Communication.Response
{
	[DataContract]
	public class ResponseUser
	{
		[DataMember(Name = "user")]
		public UserDto User { get; set; }
	}
}