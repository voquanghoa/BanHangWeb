using BanHang.Models.Communication.Request.Base;
using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter.Base
{
	public abstract class BaseConverter<Dto,Model> where Dto : BaseDto where Model : BaseModel
	{
		public abstract Dto ModelToDto(Model model);
		public abstract Model DtoToModel(Dto dto, Model model=null);

		public int ConverToInt(int? value)
		{
			return value.HasValue ? value.Value : 0;
		}
	}
}