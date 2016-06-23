using BanHang.Converter.Base;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter
{
	public class ProductionConverter : BaseConverter<ProductionDto, Production>
	{
		public Production DtoToModel(ProductionDto dto, Production model = null)
		{
			if(model == null)
			{
				model = new Production();
				model.Id = dto.Id;
			}
			model.BrandId = dto.BrandId;
			model.CategoryId = dto.CategoryId;
			model.ImageUrl = dto.ImageUrl;
			model.Name = dto.Name;
			model.OriginPrice = dto.OriginPrice;
			model.RetailPrice = dto.RetailPrice;
			model.Quantity = dto.Quantity;
			model.VipPrice = dto.VipPrice;
			model.WholesalePrice = dto.WholesalePrice;
			return model;
		}

		public ProductionDto ModelToDto(Production model)
		{
			return new ProductionDto()
			{
				BrandId = model.BrandId.HasValue ? model.BrandId.Value : 0,
				CategoryId = model.CategoryId.HasValue ? model.CategoryId.Value : 0,
				Id = model.Id,
				ImageUrl = model.ImageUrl,
				Name = model.Name,
				OriginPrice = model.OriginPrice,
				Quantity = model.Quantity,
				RetailPrice = model.RetailPrice,
				VipPrice = model.VipPrice, 
				WholesalePrice = model.WholesalePrice
			};
		}
	}
}