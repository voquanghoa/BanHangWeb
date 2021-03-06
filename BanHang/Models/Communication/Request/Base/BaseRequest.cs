﻿using BanHang.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BanHang.Models.Communication.Request.Base
{
	[DataContract]
	public class BaseRequest
	{
		[DataMember(Name = "authentication")]
		public Guid? Authentication { get; set; }
	}
}