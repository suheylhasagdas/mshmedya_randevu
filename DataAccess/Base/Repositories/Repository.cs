using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;
using Model.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DataAccess.Base.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntityBase, new()
        where TContext : DbContext, new()
    {

        private readonly IAppUserService _user;
        public Repository(IAppUserService user)
        {
            _user = user;
        }
        public TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            var context = new TContext();
            return context.Set<TEntity>().First(filter);
            
        }
        public TEntity Last(Expression<Func<TEntity, bool>> filter)
        {
            var context = new TContext();
            return context.Set<TEntity>().Last(filter);
            
        }

        public TEntity Max()
        {
            var context = new TContext();
            return context.Set<TEntity>().Max();
            
        }

        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            var context = new TContext();
            return context.Set<TEntity>().Where(filter).SingleOrDefault();
            
        }
        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            var context = new TContext();
            return context.Set<TEntity>().Any(filter);
            
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var context = new TContext();
            return orderBy == null ? context.Set<TEntity>().Where(filter) : orderBy(context.Set<TEntity>().Where(filter));
            
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            var context = new TContext();
            return context.Set<TEntity>().Select(selector);
            
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            var context = new TContext();
            return context.Set<TEntity>().Where(filter).Select(selector);
            
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            var context = new TContext();
            return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            
        }

        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            var context = new TContext();
            return GetList(filter).Count();
            
        }
        public TEntity Insert(TEntity entity)
        {
            var context = new TContext();
            var CreateDate = entity.GetType().GetProperty("CreateDate", BindingFlags.Public | BindingFlags.Instance);
                if (CreateDate != null && CreateDate.CanWrite)
                    CreateDate.SetValue(entity, DateTime.Now, null);

                var CreateUser = entity.GetType().GetProperty("CreateUser", BindingFlags.Public | BindingFlags.Instance);
                if (CreateUser != null && CreateUser.CanWrite)
                    CreateUser.SetValue(entity, _user.UserDetail == null ? 0 : _user.UserDetail.Id, null);

                var isActive = entity.GetType().GetProperty("IsActive", BindingFlags.Public | BindingFlags.Instance);
                if (isActive != null && isActive.CanWrite)
                    isActive.SetValue(entity, true, null);

                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();

                return entity;
            
        }
        public TEntity Update(TEntity entity)
        {
            var context = new TContext();
            var prop = entity.GetType().GetProperty("UpdateDate", BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.CanWrite)
                    prop.SetValue(entity, DateTime.Now, null);

                var prop1 = entity.GetType().GetProperty("UpdateUser", BindingFlags.Public | BindingFlags.Instance);
                if (prop1 != null && prop1.CanWrite)
                    prop1.SetValue(entity, _user.UserDetail.Id, null);

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            
        }
        public TEntity SoftDelete(TEntity entity)
        {
            var context = new TContext();
            var prop = entity.GetType().GetProperty("UpdateDate", BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.CanWrite)
                    prop.SetValue(entity, DateTime.Now, null);

                var prop1 = entity.GetType().GetProperty("UpdateUser", BindingFlags.Public | BindingFlags.Instance);
                if (prop1 != null && prop1.CanWrite)
                    prop1.SetValue(entity, _user.UserDetail.Id, null);

                var isActive = entity.GetType().GetProperty("IsActive", BindingFlags.Public | BindingFlags.Instance);
                if (isActive != null && isActive.CanWrite)
                    isActive.SetValue(entity, false, null);

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            
        }
        public TEntity UndoSoftDelete(TEntity entity)
        {
            var context = new TContext();
            var prop = entity.GetType().GetProperty("UpdateDate", BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.CanWrite)
                    prop.SetValue(entity, DateTime.Now, null);

                var prop1 = entity.GetType().GetProperty("UpdateUser", BindingFlags.Public | BindingFlags.Instance);
                if (prop1 != null && prop1.CanWrite)
                    prop1.SetValue(entity, _user.UserDetail.Id, null);

                var isActive = entity.GetType().GetProperty("IsActive", BindingFlags.Public | BindingFlags.Instance);
                if (isActive != null && isActive.CanWrite)
                    isActive.SetValue(entity, true, null);

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            
        }

        public bool Delete(TEntity entity)
        {
            var context = new TContext();
            context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();

                return true;
            
        }
    }
}
