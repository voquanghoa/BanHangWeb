using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel.Base
{
	/// <summary>
	/// The base model for every model
	/// </summary>
	public class BaseModel
	{
		[Key]
		public Guid Id
		{
			get; set;
		}

		public string Name { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime LastUpdatedDate { get; set; }

		public int CreatedBy { get; set; }
		public int LastUpdatedBy { get; set; }
	}
}