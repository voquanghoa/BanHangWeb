using BanHang.Converter.Base;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter
{
	public class CategoryProductConverter : BaseConverter<CategoryProductDto, CategoryProduct>
	{
		public override CategoryProduct DtoToModel(CategoryProductDto dto, CategoryProduct model = null)
		{
			if (model == null)
			{
				model = new CategoryProduct();
			}
			model.Id = dto.Id;
			model.Name = dto.Name;
			return model;
		}

		public override CategoryProductDto ModelToDto(CategoryProduct model)
		{
			return new CategoryProductDto()
			{
				Name = model.Name,
				Id = model.Id
			};
		}
	}
}