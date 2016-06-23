using BanHang.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BanHang.Business.Logic.Common
{
	public class BaseRepository<T>  where T : BaseModel
	{
		private readonly UnitOfWork unitOfWork;
		private readonly DbSet<T> dbSet;

		/// <summary>
		/// Contructor with unitOfWork
		/// </summary>
		/// <param name="unitOfWork">UnitOfWork object</param>
		/// <exception cref="ArgumentNullException">When unitOfWork is null</exception>
		public BaseRepository(UnitOfWork unitOfWork)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException("unitOfWork is null");
			}

			this.unitOfWork = unitOfWork;
			dbSet = this.unitOfWork.DbContext.Set<T>();
		}

		/// <summary>
		/// Get the object by id
		/// </summary>
		/// <param name="id">The object's id</param>
		/// <returns>The object if found or an exception will throw if not found</returns>
		public T GetById(int id)
		{
			return dbSet.Find(id);
		}

		/// <summary>
		/// Get all object(s) from database
		/// </summary>
		/// <returns>The list of object(s)</returns>
		public List<T> GetAll()
		{
			return All().ToList();
		}

		/// <summary>
		/// Get the queryable for all object(s)
		/// </summary>
		/// <param name="includes">List of field's name should be included innned</param>
		/// <returns>The queryable for all object(s)</returns>
		public IQueryable<T> All(string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = dbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				return query.AsQueryable();
			}

			return dbSet.AsQueryable();
		}

		/// <summary>
		/// Find an object by id
		/// </summary>
		/// <param name="id">The object's id, id can be null</param>
		/// <returns>The object if found or a Null object if not found</returns>
		public T FindOne(int id)
		{
			return dbSet.FirstOrDefault(x => x.Id == id);
		}

		/// <summary>
		/// Find an object by a predicate
		/// </summary>
		/// <param name="predicate">The predicate</param>
		/// <param name="includes">The list of field's name should include</param>
		/// <returns>The object if found, null if not found</returns>
		public T FindOne(Expression<Func<T, bool>> predicate, string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = dbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				return query.FirstOrDefault(predicate);
			}

			return dbSet.FirstOrDefault(predicate);
		}

		/// <summary>
		/// Create a queryable for object(s) which match a predicate
		/// </summary>
		/// <param name="predicate">The predicate</param>
		/// <param name="includes">The list of field's name should include</param>
		/// <returns>The queryable for the given filter</returns>
		public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = dbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				return query.Where(predicate).AsQueryable();
			}

			return dbSet.Where(predicate).AsQueryable();
		}

		/// <summary>
		/// Create a new object to database.
		/// </summary>
		/// <param name="TObject">Specified a new object to create.</param>
		/// <returns>The created object</returns>
		public virtual T Create(T TObject)
		{
			var newEntry = dbSet.Add(TObject);
			newEntry.CreatedDate = newEntry.LastUpdatedDate = DateTime.Now;
			unitOfWork.DbContext.SaveChanges();

			return newEntry;
		}

		/// <summary>
		/// Delete the object from database.
		/// </summary>
		/// <param name="TObject">Specified a existing object to delete.</param>
		/// <returns>1 if success, 0 if failed</returns>
		public virtual int Delete(T TObject) 
		{
			if (TObject is StoreModel)
			{
				var storeObject = (StoreModel)(object)TObject;
				storeObject.IsDeleted = true;
				return Update(TObject);
			}
			dbSet.Remove(TObject);
			return unitOfWork.DbContext.SaveChanges();
		}

		public virtual int Update(T TObject)
		{
			dbSet.Attach(TObject);
			TObject.LastUpdatedDate = DateTime.Now;
			unitOfWork.DbContext.Entry(TObject).State = EntityState.Modified;
			return unitOfWork.DbContext.SaveChanges();
		}


		public virtual int Delete(Expression<Func<T, bool>> predicate)
		{
			dbSet.RemoveRange(Filter(predicate));
			return unitOfWork.DbContext.SaveChanges();
		}


		public bool Contains(Expression<Func<T, bool>> predicate)
		{
			return dbSet.Any(predicate);
		}

		public virtual void SaveChanges()
		{
			unitOfWork.DbContext.SaveChanges();
		}

		public void Dispose()
		{
			unitOfWork.DbContext?.Dispose();
		}
	}
}