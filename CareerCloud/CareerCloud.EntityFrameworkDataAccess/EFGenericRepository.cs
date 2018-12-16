using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository <T> where T : class
    {
        private readonly CareerCloudContext _context;
        public EFGenericRepository(bool createProxy = true)
        {
            _context = new CareerCloudContext(createProxy);
        }

        public void Add(params T[] items)
        {
          
            foreach (T item in items)
            {
                //Console.WriteLine(_context.Entry(item).State);
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();
        }
        //linq expressions can be passed
        public IList<T> GetAll(params Expression<Func<T, object>>[] navegationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navprop in navegationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navprop);
            }
            return dbQuery.ToList<T>();
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navegationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navprop in navegationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navprop);
            }
            return dbQuery.Where(where).ToList<T>();
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navegationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (Expression<Func<T, object>> navprop in navegationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navprop);
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

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {

        }


    }
}
