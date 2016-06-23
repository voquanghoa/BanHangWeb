using BanHang.Converter.Base;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter
{
	public class CustomerConverter : BaseConverter<CustomerDto, Customer>
	{
		public Customer DtoToModel(CustomerDto dto, Customer model = null)
		{
			if(model == null)
			{
				model = new Customer();
				model.Id = dto.Id;
			}

			model.Address = dto.Address;
			model.Email = dto.Email;
			model.Gender = dto.Gender;
			model.Id = dto.Id;
			model.Name = dto.Name;
			model.Note = dto.Note;
			model.PhoneNumber = dto.PhoneNumber;
			model.GroupId = dto.GroupId;

			return model;
		}

		public CustomerDto ModelToDto(Customer model)
		{
			return new CustomerDto()
			{
				Address = model.Address,
				Id = model.Id,
				Email = model.Email,
				Gender = model.Gender,
				GroupId = model.GroupId.HasValue? model.GroupId.Value:0,
				Name = model.Name,
				Note = model.Note,
				PhoneNumber = model.PhoneNumber
			};
		}
	}
}