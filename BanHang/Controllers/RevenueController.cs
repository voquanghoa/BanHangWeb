using BanHang.Controllers.Base;
using BanHang.Converter;
using BanHang.Models.Communication.Response;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BanHang.Controllers
{
	public class RevenueController : BaseController<Invoice, RevenueDto>
	{
		public RevenueController()
		{
			this.Converter = new RevenueConverter();
		}

		public IHttpActionResult Get(Guid authentication)
		{
			return ExecuteAction(() => Ok(GetRevenueResponse(authentication)));
		}

		protected override string[] GetIncludes()
		{
			return new string[]
			{
				"Customer",
				"Employee",
				"Production"
			};
		}

		private RevenueResponse GetRevenueResponse(Guid authentication)
		{
			DateTime startDateTime = DateTime.Today; //Today at 00:00:00
			DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59

			var invoices = base.BaseGetAll(authentication,
				x => !x.IsDeleted && x.CreatedDate>=startDateTime && x.CreatedDate<=endDateTime);

			var total = invoices.Sum(x => x.Total);

			return new RevenueResponse()
			{
				Invoice = invoices,
				Total = total
			};

		}
	}
}