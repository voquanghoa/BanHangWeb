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
			return ExecuteAction(() => Ok(base.BaseGetAll()));
		}

		[ResponseType(typeof(CategoryProductDto))]
		public IHttpActionResult Get(int id)
		{
			return ExecuteAction(() => Ok(base.BaseGet(id)));
		}

		[ResponseType(typeof(Brand))]
		public IHttpActionResult Post([FromBody]CategoryProductRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePost(request.Data, request.Authentication)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]CategoryProductRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePut(request.Id, request.Data, request.Authentication)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Delete([FromBody]BrandRequest request)
		{
			return ExecuteAction(() => Ok(base.BaseDelete(request.Id, request.Authentication)));
		}
	}
}