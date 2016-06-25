using BanHang.Business.Logic.Common;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Business.Logic
{
	public class AuthenticationRepository : TemporareRepository<Authentication>
	{
		public AuthenticationRepository(UnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}