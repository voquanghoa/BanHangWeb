using BanHang.Models.Communication.Request.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Communication.Request
{
	[DataContract]
	public class LoginForm : BaseRequest
	{
		[DataMember(Name = "user_name")]
		public string UserName { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }
	}
}