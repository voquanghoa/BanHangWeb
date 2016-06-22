using BanHang.Business;
using BanHang.Controllers.Base;
using BanHang.Models.Communication.Request;
using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel;
using System.Web.Http;
using System.Web.Http.Description;

namespace BanHang.Controllers
{
	public class AuthenticationController: BaseController<LoginForm, Authentication, BaseDto>
	{
		private AuthenticationBusiness authenticationBussiness;

		public AuthenticationController():base()
		{
			authenticationBussiness = new AuthenticationBusiness(UnitOfWork);
		}

		public override IHttpActionResult Get()
		{
			return BadRequest();
		}

		public override IHttpActionResult Get(int id)
		{
			return BadRequest();
		}

		[ResponseType(typeof(int))]
		public override IHttpActionResult Post([FromBody]LoginForm request)
		{
			return ExecuteAction(()=>Ok(authenticationBussiness.Authenticate(request)));
		}

		[ResponseType(typeof(int))]
		public override IHttpActionResult Delete([FromBody]LoginForm request)
		{
			return ExecuteAction(()=>Ok(authenticationBussiness.Logout()));
		}

		public override IHttpActionResult Put([FromBody]LoginForm request)
		{
			return BadRequest();
		}
	}
}