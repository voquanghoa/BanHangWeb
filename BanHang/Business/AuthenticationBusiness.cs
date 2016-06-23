using BanHang.Business.Logic;
using BanHang.Business.Logic.Common;
using BanHang.Models.Communication.Request;
using BanHang.Models.Communication.Response;
using BanHang.Models.ServiceModel;
using BanHang.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BanHang.Business
{
	public class AuthenticationBusiness
	{
		private const string SessonHashCookieName = "SESSONHASH";
		private readonly EmployeeRepository employeeRepository;
		private readonly AuthenticationRepository authenticationRepository;

		public AuthenticationBusiness(UnitOfWork unitOfWork)
		{
			employeeRepository = new EmployeeRepository(unitOfWork);
			authenticationRepository = new AuthenticationRepository(unitOfWork);
		}

		public int Logout()
		{
			var sessonHashCookie = CookieUtil.GetCookie(SessonHashCookieName);
			if (sessonHashCookie != null)
			{
				var sessonGuid = Guid.Parse(sessonHashCookie);
				authenticationRepository.Delete(x => x.SessionCode == sessonGuid);
				return 1;
			}
			else
			{
				throw new HttpException((int)HttpStatusCode.BadRequest, "Bad request");
			}
		}

		private Employee GetCurrentLoggedInUser()
		{
			var sessonHashCookie = CookieUtil.GetCookie(SessonHashCookieName);
			if (sessonHashCookie != null)
			{
				var sessonGuid = Guid.Parse(sessonHashCookie);
				var sesson = authenticationRepository.FindOne(x => x.SessionCode == sessonGuid, new[] { "User" });
				if (sesson != null)
				{
					return sesson.Employee;
				}
			}
			return null;
		}

		public bool IsUserLoggedIn()
		{
			return GetCurrentLoggedInUser() != null;
		}

		public LoginResponse Authenticate(LoginForm loginForm)
		{
			var employee = employeeRepository.FindOne(x => x.LoginName == loginForm.UserName && x.Password == loginForm.Password);

			if (employee == null)
			{
				throw new HttpException(401, "Unauthorized access");
			}

			var authentication = new Authentication()
			{
				SessionCode = Guid.NewGuid(),
				Employee = employee
			};

			authenticationRepository.Create(authentication);

			return new LoginResponse()
			{
				Authentication = authentication.SessionCode,
				Role = employee.Role
			};
		}
	}
}