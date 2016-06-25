using BanHang.Business;
using BanHang.Business.Logic.Common;
using BanHang.Converter.Base;
using BanHang.Exceptions;
using BanHang.Models.Communication.Request.Base;
using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel;
using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace BanHang.Controllers.Base
{
	public abstract class BaseController<Model, Dto> : ApiController where Model : StoreModel where Dto: BaseDto
	{
		protected BaseRepository<Model> repository;
		protected UnitOfWork UnitOfWork;
		protected BaseConverter<Dto, Model> Converter;
		private AuthenticationBusiness authenticationBusiness;

		public BaseController()
		{
			UnitOfWork = new UnitOfWork();
			repository = new BaseRepository<Model>(UnitOfWork);
			authenticationBusiness = new AuthenticationBusiness(UnitOfWork);
		}

		protected virtual List<Dto> BaseGetAll(Guid? authentcation, Expression<Func<Model, bool>> predicate=null)
		{
			RequireLogin(authentcation);
			if (predicate != null)
			{
				return repository.All(GetIncludes()).Where(predicate).ToList().Select(x => Converter.ModelToDto(x)).ToList();
			}

			return repository.All(GetIncludes()).Where(x=>!x.IsDeleted).ToList().Select(x => Converter.ModelToDto(x)).ToList();
		}

		protected virtual Dto BaseGet(int id, Guid? authentcation)
		{
			RequireLogin(authentcation);
			var model = repository.FindOne(id, GetIncludes());
			if(model == null)
			{
				throw new NotFoundException();
			}

			return Converter.ModelToDto(model);
		}

		protected virtual Dto BasePost(Dto dtoObj, Guid? authentcation)
		{
			RequireLogin(authentcation);
			return Converter.ModelToDto(repository.Create(Converter.DtoToModel(dtoObj, null)));
		}

		protected virtual string[] GetIncludes()
		{
			return null;
		}

		protected virtual int BaseDelete(int id, Guid? authentcation)
		{
			RequireAdmin(RequireLogin(authentcation));

			var model = repository.FindOne(id);
			if (model == null)
			{
				throw new NotFoundException();
			}
			return repository.Delete(model);
		}

		protected virtual int BasePut(int id, Dto dtoObj, Guid? authentcation)
		{
			RequireLogin(authentcation);

			var model = repository.FindOne(id);
			if (model == null)
			{
				throw new NotFoundException();
			}
			Converter.DtoToModel(dtoObj, model);
			model.Id = id;

			return repository.Update(model);
		}

		protected IHttpActionResult ExecuteAction(Action action)
		{
			return ExecuteAction(() =>
			{
				action();
				return Ok();
			});
		}

		private Employee RequireLogin(Guid? authentcation)
		{
			var employee = authenticationBusiness.GetUser(authentcation);
			if (employee == null)
			{
				throw new UnauthorizedException();
			}
			return employee;
		}

		private void RequireAdmin(Employee employee)
		{
			if(employee.Role!= Role.Admin)
			{
				throw new ForbiddenException();
			}
		}
		/// <summary>
		/// Execute a specific action
		/// </summary>
		/// <param name="action">The action to be executed</param>
		/// <returns></returns>
		protected IHttpActionResult ExecuteAction(Func<IHttpActionResult> action)
		{
			try
			{
				return action();
			}
			catch(NotFoundException ex)
			{
				Log(ex);
				return StatusCode(System.Net.HttpStatusCode.NotFound);
			}
			catch(ForbiddenException ex)
			{
				Log(ex);
				return StatusCode(System.Net.HttpStatusCode.Forbidden);
			}
			catch (UnauthorizedException ex)
			{
				Log(ex);
				return StatusCode(System.Net.HttpStatusCode.Unauthorized);
			}
			catch (BadRequestException ex)
			{
				Log(ex);
				return StatusCode(System.Net.HttpStatusCode.BadRequest);
			}
			catch (Exception ex)
			{
				Log(ex);
				return StatusCode(System.Net.HttpStatusCode.Unauthorized);
			}
		}

		private void Log(Exception ex)
		{
			
		}
	}
}