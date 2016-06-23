using BanHang.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Dto
{
	[DataContract]
	public class NameDto : BaseDto
	{
		[DataMember(Name="id", IsRequired =true)]
		public int Id { get; set; }


		[DataMember(Name="name", IsRequired =true)]
		public string Name { get; set; }
	}
}