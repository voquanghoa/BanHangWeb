using BanHang.Controllers.Base;
using BanHang.Converter;
using BanHang.Models.Communication.Request;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System.Web.Http;
using System.Web.Http.Description;

namespace BanHang.Controllers
{
	public class BrandController : BaseController<Brand, NameDto>
	{
		public BrandController():base()
		{
			this.Converter = new NameConverter();
		}

		public IHttpActionResult Get()
		{
			return ExecuteAction(() => Ok(base.GetAll()));
		}

		[ResponseType(typeof(Brand))]
		public IHttpActionResult Post([FromBody]BrandRequest request)
		{
			return ExecuteAction(() => Ok(base.Post(request.Brand)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Put([FromBody]BrandRequest request)
		{
			return ExecuteAction(() => Ok(base.Put(request.Id, request.Brand)));
		}

		[ResponseType(typeof(int))]
		public IHttpActionResult Delete([FromBody]BrandRequest request)
		{
			return ExecuteAction(() => Ok(base.Delete(request.Id)));
		}
	}
}