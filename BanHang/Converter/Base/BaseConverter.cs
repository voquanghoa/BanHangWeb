using BanHang.Models.Communication.Request.Base;
using BanHang.Models.Dto.Base;
using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter.Base
{
	public interface BaseConverter<Dto,Model> where Dto : BaseDto where Model : BaseModel
	{
		Dto ModelToDto(Model model);
		Model DtoToModel(Dto dto, Model model=null);
	}
}