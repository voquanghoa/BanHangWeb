using BanHang.Converter.Base;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter
{
	public class NameConverter : BaseConverter<NameDto, Brand>
	{
		public override Brand DtoToModel(NameDto dto, Brand model = null)
		{
			if(model == null)
			{
				model = new Brand();
			}
			model.Id = dto.Id;
			model.Name = dto.Name;
			return model;
		}

		public override NameDto ModelToDto(Brand model)
		{
			return new NameDto()
			{
				Name = model.Name,
				Id = model.Id
			};
		}
	}
}