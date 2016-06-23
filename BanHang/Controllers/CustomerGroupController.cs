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
	public class CustomerGroupController : BaseController<CustomerGroup, CustomerGroupDto>
	{
		public CustomerGroupController():base()
		{
			this.Converter = new CustomerGroupConverter();
		}

		public IHttpActionResult Get()
		{
			return ExecuteAction(() => Ok(base.BaseGetAll()));
		}

		[ResponseType(typeof(CustomerGroupDto))]
		public IHttpActionResult Get(int id)
		{
			return ExecuteAction(() => Ok(base.BaseGet(id)));
		}

		[ResponseType(typeof(CustomerGroupDto))]
		public IHttpActionResult Post([FromBody]CustomerGroupRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePost(request.Data)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]CustomerGroupRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePut(request.Id, request.Data)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Delete([FromBody]CustomerGroupRequest request)
		{
			return ExecuteAction(() => Ok(base.BaseDelete(request.Id)));
		}
	}
}