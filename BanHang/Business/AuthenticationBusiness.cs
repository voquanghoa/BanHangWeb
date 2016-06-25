using BanHang.Business.Logic;
using BanHang.Business.Logic.Common;
using BanHang.Exceptions;
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
		
		private readonly EmployeeRepository employeeRepository;
		private readonly TemporareRepository<Authentication> authenticationRepository;

		public AuthenticationBusiness(UnitOfWork unitOfWork)
		{
			employeeRepository = new EmployeeRepository(unitOfWork);
			authenticationRepository = new TemporareRepository<Authentication>(unitOfWork);
		}

		public int Logout(Guid? authentication)
		{
			if (authentication.HasValue)
			{
				authenticationRepository.Delete(x => x.SessionCode == authentication.Value);
				return 1;
			}
			else
			{
				throw new HttpException((int)HttpStatusCode.BadRequest, "Bad request");
			}
		}

		public Employee GetUser(Guid? authentication)
		{
			if (authentication.HasValue)
			{
				var sesson = authenticationRepository.FindOne(x => x.SessionCode == authentication.Value, new[] { "Employee" });
				if (sesson != null)
				{
					return sesson.Employee;
				}
			}
			return null;
		}

		public LoginResponse Authenticate(LoginForm loginForm)
		{
			var employee = employeeRepository.FindOne(x =>!x.IsDeleted && x.LoginName == loginForm.UserName && x.Password == loginForm.Password);

			if (employee == null)
			{
				throw new UnauthorizedException();
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