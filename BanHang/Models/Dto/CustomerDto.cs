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
	public class CustomerDto : BaseDto
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "group_id")]
		public int GroupId { get; set; }

		[DataMember(Name = "gender")]
		public Gender Gender { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }


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