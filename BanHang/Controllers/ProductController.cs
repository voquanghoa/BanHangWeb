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
	public class ProductController : BaseController<Production, ProductionDto>
	{
		public ProductController()
		{
			Converter = new ProductionConverter();
		}

		public IHttpActionResult Get(Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseGetAll(authentication)));
		}

		protected override string[] GetIncludes()
		{
			return new string[] { "Category", "Brand" };
		}

		[ResponseType(typeof(ProductionDto))]
		public IHttpActionResult Get(int id, Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseGet(id, authentication)));
		}

		[ResponseType(typeof(ProductionDto))]
		public IHttpActionResult Post([FromBody]ProductionRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePost(request.Data, request.Authentication)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]ProductionRequest request)
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