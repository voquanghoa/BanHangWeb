using BanHang.Business.Logic.Common;
using BanHang.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Business.Logic
{
	public class EmployeeRepository : BaseRepository<Employee>
	{
		public EmployeeRepository(UnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}