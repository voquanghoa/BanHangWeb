using BanHang.Business.Logic.Common;
using BanHang.Converter.Base;
using BanHang.Exceptions;
using BanHang.Models.Communication.Request.Base;
using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BanHang.Controllers.Base
{
	public abstract class BaseController<Model, Dto> : ApiController where Model : BaseModel where Dto: BaseDto
	{
		protected BaseRepository<Model> repository;
		protected UnitOfWork UnitOfWork;
		protected BaseConverter<Dto, Model> Converter;

		public BaseController()
		{
			UnitOfWork = new UnitOfWork();
			repository = new BaseRepository<Model>(UnitOfWork);
		}

		protected virtual List<Dto> GetAll()
		{
			return repository.GetAll().Select(x => Converter.ModelToDto(x)).ToList();
		}

		protected virtual Dto Get(int id)
		{
			return Converter.ModelToDto(repository.FindOne(id));
		}

		protected virtual Dto Post(Dto dtoObj)
		{
			return Converter.ModelToDto(repository.Create(Converter.DtoToModel(dtoObj, null)));
		}

		protected virtual int Delete(int id)
		{
			var model = repository.FindOne(id);
			if (model == null)
			{
				throw new NotFoundException();
			}
			return repository.Delete(model);
		}

		protected virtual int Put(int id, Dto dtoObj)
		{
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
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(System.Net.HttpStatusCode.Unauthorized);
			}
		}
	}
}