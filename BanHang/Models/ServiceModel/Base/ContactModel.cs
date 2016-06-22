using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models.ServiceModel.Base
{
	public class ContactModel : StoreModel
	{
		public Gener Gender { get; set; }

		public string Address { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }

		public string Note { get; set; }
	}
}