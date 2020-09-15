using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SchoolAPI.Models
{
    public class EFGenericRepository<T>
        where T : class
    {
        private SchoolContext _context;
        public EFGenericRepository()
        {
            _context = new SchoolContext();
        }
        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();
        }

        

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }
            return dbQuery.ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }
            return dbQuery.FirstOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }
    }
}
