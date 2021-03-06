﻿using BanHang.Controllers.Base;
using BanHang.Converter;
using BanHang.Models.Communication.Request;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace BanHang.Controllers
{
	public class BrandController : BaseController<Brand, NameDto>
	{
		public BrandController():base()
		{
			this.Converter = new NameConverter();
		}

		public IHttpActionResult Get(int id, Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseGet(id, authentication)));
		}

		public IHttpActionResult Get(Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseGetAll(authentication, x => !x.IsDeleted)));
		}

		[ResponseType(typeof(Brand))]
		public IHttpActionResult Post([FromBody]BrandRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePost(request.Data, request.Authentication)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]BrandRequest request)
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