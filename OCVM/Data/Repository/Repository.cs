using Microsoft.EntityFrameworkCore;
using OCVM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly OcvmContext context;
        public Repository(OcvmContext _context)
        {
            context = _context;
        }

        protected void Save() => context.SaveChanges();
        public void Create(T entity)
        {
            context.Add(entity);
            Save();
        }

        public virtual void Delete(T entity)
        {
            context.Remove(entity);

            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return  context.Set<T>();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            Save();
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        public int Count(Func<T, Boolean> predicate)
        {
            return context.Set<T>().Where(predicate).Count();
        }
        public bool Any(Func<T, bool> predicate)
        {
            return context.Set<T>().Any(predicate);
        }
        public bool Any()
        {
            return context.Set<T>().Any();
        }
    }
}
