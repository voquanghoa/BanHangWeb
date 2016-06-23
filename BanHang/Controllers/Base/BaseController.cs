using BanHang.Business.Logic.Common;
using BanHang.Converter.Base;
using BanHang.Models.Communication.Request.Base;
using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace BanHang.Controllers.Base
{
	public abstract class BaseController<Request,Model, Dto> : ApiController where Request : BaseRequest where Model : BaseModel where Dto: BaseDto
	{
		protected BaseRepository<Model> repository;
		protected UnitOfWork UnitOfWork;
		protected BaseConverter<Dto, Model> Converter;

		public BaseController()
		{
			UnitOfWork = new UnitOfWork();
			repository = new BaseRepository<Model>(UnitOfWork);
		}

		public virtual IHttpActionResult Get()
		{
			return Ok(repository.All().Select(x => Converter.ModelToDto(x)).ToList());
		}

		public virtual IHttpActionResult Get(int id)
		{
			return Ok(Converter.ModelToDto(repository.FindOne(id)));
		}

		public virtual IHttpActionResult Post([FromBody]Request request)
		{
			return Ok(repository.Create(Converter.DtoToModel((Dto)request.BaseDto)));
		}

		public virtual IHttpActionResult Delete([FromBody]Request request)
		{
			return Ok(repository.Delete(Converter.DtoToModel((Dto)request.BaseDto)));
		}

		public virtual IHttpActionResult Put([FromBody]Request request)
		{
			return Ok(repository.Update(Converter.DtoToModel((Dto)request.BaseDto)));
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
			catch
			{
				return StatusCode(System.Net.HttpStatusCode.Unauthorized);
			}
		}
	}
}