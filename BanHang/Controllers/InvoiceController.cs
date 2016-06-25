using BanHang.Business.Logic.Common;
using BanHang.Controllers.Base;
using BanHang.Converter;
using BanHang.Models.Communication.Request;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace BanHang.Controllers
{
	public class InvoiceController : BaseController<Invoice, InvoiceDto>
	{
		private BaseRepository<Production> productionRepo;
		public InvoiceController()
		{
			this.Converter = new InvoiceConverter();
			this.productionRepo = new BaseRepository<Production>(UnitOfWork);
		}

		public IHttpActionResult Get(Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseGetAll(authentication, x=>!x.IsDeleted)));
		}

		[ResponseType(typeof(InvoiceDto))]
		public IHttpActionResult Get(int id, Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseGet(id, authentication)));
		}

		[ResponseType(typeof(InvoiceDto))]
		public IHttpActionResult Post([FromBody]InvoiceRequest request)
		{
			return ExecuteAction(() => Ok(PostInvoice(request.Data, request.Authentication)));
		}

		private InvoiceDto PostInvoice(InvoiceDto form, Guid? authentication)
		{
			var result = base.BasePost(form, authentication);
			var product = productionRepo.FindOne(x => x.Id == form.ProductionId);
			if (product != null)
			{
				product.Quantity -= form.Quantity;
				productionRepo.Update(product);
			}
			return result;

		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]InvoiceRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePut(request.Id, request.Data, request.Authentication)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Delete(int id, Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseDelete(id, authentication)));
		}
	}
}