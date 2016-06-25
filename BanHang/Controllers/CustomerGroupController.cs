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
	public class CustomerGroupController : BaseController<CustomerGroup, CustomerGroupDto>
	{
		public CustomerGroupController():base()
		{
			this.Converter = new CustomerGroupConverter();
		}

		public IHttpActionResult Get(Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseGetAll(authentication, x => !x.IsDeleted)));
		}

		[ResponseType(typeof(CustomerGroupDto))]
		public IHttpActionResult Get(int id, Guid authentication)
		{
			return ExecuteAction(() => Ok(base.BaseGet(id, authentication)));
		}

		[ResponseType(typeof(CustomerGroupDto))]
		public IHttpActionResult Post([FromBody]CustomerGroupRequest request)
		{
			return ExecuteAction(() => Ok(base.BasePost(request.Data, request.Authentication)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]CustomerGroupRequest request)
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