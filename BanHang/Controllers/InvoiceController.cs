﻿using BanHang.Controllers.Base;
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
		public InvoiceController()
		{
			this.Converter = new InvoiceConverter();
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
			return ExecuteAction(() => Ok(base.BasePost(request.Data, request.Authentication)));
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