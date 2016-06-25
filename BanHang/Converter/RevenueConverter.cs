using BanHang.Converter.Base;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter
{
	public class RevenueConverter : BaseConverter<RevenueDto, Invoice>
	{
		public override Invoice DtoToModel(RevenueDto dto, Invoice model = null)
		{
			throw new NotImplementedException();
		}

		public override RevenueDto ModelToDto(Invoice model)
		{
			return new RevenueDto()
			{
				Customer = model.Customer.Name,
				Discount = model.DiscountPercent,
				Employee = model.Employee.Name,
				Price = model.Price,
				PriceType = model.RetailPrice,
				Production = model.Production.Name,
				Quantity = model.Quantity
			};
		}
	}
}