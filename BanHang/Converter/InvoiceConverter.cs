using BanHang.Converter.Base;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter
{
	public class InvoiceConverter : BaseConverter<InvoiceDto, Invoice>
	{
		public override Invoice DtoToModel(InvoiceDto dto, Invoice model = null)
		{
			if(model == null)
			{
				model = new Invoice();
			}

			model.CustomerId = ConverToInt(dto.CustomerId);
			model.Description = dto.Description;
			model.DiscountPercent = dto.DiscountPercent;
			model.EmployeeId = ConverToInt(dto.EmployeeId);
			model.Price = dto.Price;
			model.ProductionId = ConverToInt(dto.ProductionId);
			model.Quantity = dto.Quantity;
			model.RetailPrice = dto.RetailPrice;

			return model;
		}

		public override InvoiceDto ModelToDto(Invoice model)
		{
			return new InvoiceDto()
			{
				CustomerId = ConverToInt(model.CustomerId),
				Description = model.Description,
				DiscountPercent = model.DiscountPercent,
				EmployeeId = ConverToInt(model.EmployeeId),
				Price = model.Price,
				ProductionId = ConverToInt(model.ProductionId),
				Quantity = model.Quantity,
				RetailPrice = model.RetailPrice,
				Id = model.Id
			};
		}
	}
}