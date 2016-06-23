using BanHang.Business;
using BanHang.Controllers.Base;
using BanHang.Models.Communication.Request;
using BanHang.Models.Communication.Response;
using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel;
using System.Web.Http;
using System.Web.Http.Description;

namespace BanHang.Controllers
{
	public class AuthenticationController: BaseController<Authentication, BaseDto>
	{
		private AuthenticationBusiness authenticationBussiness;

		public AuthenticationController():base()
		{
			authenticationBussiness = new AuthenticationBusiness(UnitOfWork);
		}

		[ResponseType(typeof(LoginResponse))]
		public IHttpActionResult Post([FromBody]LoginForm request)
		{
			return ExecuteAction(() => Ok(authenticationBussiness.Authenticate(request)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Delete([FromBody]LoginForm request)
		{
			return ExecuteAction(() => Ok(authenticationBussiness.Logout(request.Authentication)));
		}
	}
}