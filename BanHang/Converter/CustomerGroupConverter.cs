using BanHang.Converter.Base;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter
{
	public class CustomerGroupConverter : BaseConverter<CustomerGroupDto, CustomerGroup>
	{
		public override CustomerGroup DtoToModel(CustomerGroupDto dto, CustomerGroup model = null)
		{
			if (model == null)
			{
				model = new CustomerGroup();
			}
			model.Id = dto.Id;
			model.Name = dto.Name;
			model.DiscountPercent = dto.DiscountPercent;
			model.Note = dto.Note;
			return model;
		}

		public override CustomerGroupDto ModelToDto(CustomerGroup model)
		{
			return new CustomerGroupDto()
			{
				Name = model.Name,
				Id = model.Id,
				Note = model.Note,
				DiscountPercent = model.DiscountPercent
			};
		}
	}
}