using BanHang.Controllers.Base;
using BanHang.Converter;
using BanHang.Models.Communication.Request;
using BanHang.Models.Communication.Response;
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
	public class UserController : BaseController<Employee, UserDto>
	{
		public UserController():base()
		{
			Converter = new UserConverter();
		}

		public IHttpActionResult Get()
		{
			return ExecuteAction(() => Ok(base.GetAll()));
		}

		[ResponseType(typeof(UserDto))]
		public IHttpActionResult Post([FromBody]RequestUser request)
		{
			return ExecuteAction(() => Ok(base.Post(request.User)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]RequestUser request)
		{
			return ExecuteAction(() => Ok(base.Put(request.Id, request.User)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Delete([FromBody]RequestUser request)
		{
			return ExecuteAction(() => Ok(base.Delete(request.Id)));
		}
	}
}