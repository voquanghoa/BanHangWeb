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
	public class CategoryProductController: BaseController<CategoryProduct, CategoryProductDto>
	{
		public CategoryProductController()
		{
			this.Converter = new CategoryProductConverter();
		}

		public IHttpActionResult Get()
		{
			return ExecuteAction(() => Ok(base.GetAll()));
		}

		[ResponseType(typeof(Brand))]
		public IHttpActionResult Post([FromBody]CategoryProductRequest request)
		{
			return ExecuteAction(() => Ok(base.Post(request.CategoryProduct)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]CategoryProductRequest request)
		{
			return ExecuteAction(() => Ok(base.Put(request.Id, request.CategoryProduct)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Delete([FromBody]BrandRequest request)
		{
			return ExecuteAction(() => Ok(base.Delete(request.Id)));
		}
	}
}