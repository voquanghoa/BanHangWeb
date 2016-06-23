using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Dto
{
	[DataContract]
	public class UserDto : BaseDto
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "login_name")]
		public string LoginName { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }

		[DataMember(Name = "job_title")]
		public string JobTitle { get; set; }

		[DataMember(Name = "role")]
		public Role Role { get; set; }

		[DataMember(Name = "gender")]
		public Gender Gender { get; set; }

		[DataMember(Name = "address")]
		public string Address { get; set; }

		[DataMember(Name = "phone_number")]
		public string PhoneNumber { get; set; }

		[DataMember(Name = "email")]
		public string Email { get; set; }

		[DataMember(Name = "note")]
		public string Note { get; set; }
	}
}