using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using System.Data.Entity;

namespace BanHang.Business.Logic.Common
{
	public class UnitOfWork
	{
		private TransactionScope transaction;

		public DbContext DbContext
		{
			get; set;
		}

		public UnitOfWork()
		{
			DbContext = new BanHangDataContext();
			DbContext.Configuration.ProxyCreationEnabled = false;
			DbContext.Configuration.LazyLoadingEnabled = false;
		}

		public void Dispose()
		{
		}

		public void StartTransaction()
		{
			transaction = new TransactionScope();
		}

		public void Commit()
		{
			DbContext.SaveChanges();
			transaction.Complete();
		}
	}
}