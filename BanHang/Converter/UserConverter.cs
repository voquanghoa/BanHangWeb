using BanHang.Converter.Base;
using BanHang.Models.Dto;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Converter
{
	public class UserConverter : BaseConverter<UserDto, Employee>
	{
		public Employee DtoToModel(UserDto dto, Employee employee = null)
		{
			if(employee == null)
			{
				employee = new Employee();
			}

			employee.Address = dto.Address;
			employee.Email = dto.Email;
			employee.Gender = dto.Gender;
			employee.Id = dto.Id;
			employee.JobTitle = dto.JobTitle;
			employee.LoginName = dto.LoginName;
			employee.Name = dto.Name;
			employee.Note = dto.Note;
			employee.Password = dto.Password;
			employee.Role = dto.Role;
			employee.PhoneNumber = dto.PhoneNumber;

			return employee;
			
		}

		public UserDto ModelToDto(Employee model)
		{
			return new UserDto()
			{
				Role = model.Role,
				PhoneNumber = model.PhoneNumber,
				Password = model.Password,
				Address = model.Address,
				Email = model.Email,
				Gender = model.Gender,
				Id = model.Id,
				JobTitle = model.JobTitle,
				LoginName = model.LoginName,
				Name = model.Name,
				Note = model.Note
			};
		}
	}
}