using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Communication.Response
{
	[DataContract]
	public class LoginResponse
	{
		[DataMember(Name = "role")]
		public Role Role { get; set; }

		[DataMember(Name = "authentication")]
		public Guid Authentication { get; set; }
	}
}