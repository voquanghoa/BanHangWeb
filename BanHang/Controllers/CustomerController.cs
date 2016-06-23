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
	public class CustomerController : BaseController<Customer, CustomerDto>
	{
		public CustomerController()
		{
			this.Converter = new CustomerConverter();
		}

		public IHttpActionResult Get()
		{
			return ExecuteAction(() => Ok(base.BaseGetAll()));
		}

		[ResponseType(typeof(CustomerDto))]
		public IHttpActionResult Post([FromBody]CustomerRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePost(request.Data)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]CustomerRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePut(request.Id, request.Data)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Delete([FromBody]CustomerRequest request)
		{
			return ExecuteAction(() => Ok(base.BaseDelete(request.Id)));
		}
	}
}