using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class 
    {
       internal DemoAppContext demoAppContext;
      internal IDbSet<T> dbSet;

       public Repository(DemoAppContext demoAppContext)
       {
           this.demoAppContext = demoAppContext;
          // this.dbSet = demoAppContext.Set<T>();
       }

        public  IQueryable<T> Table     
       {
           get
           {
               //return dbSet.AsQueryable<T>();
               return Entities;
           }
       }
        public  IEnumerable<T> TableAsEnumerable
        {
            get
            {
                IQueryable<T> query = dbSet;
                return query.ToList();

            }
        }

       public virtual T GetById(object Id)
       {
           return Entities.Find(Id);
       }
        public virtual int Insert(T entity)
       {
           var obj = Entities.Add(entity);
          return  demoAppContext.SaveChanges();
            
       }
        public virtual void Delete(Object Id)
        {
            T entityToDelete = Entities.Find(Id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if(demoAppContext.Entry(entity).State==EntityState.Detached)
            {
                Entities.Attach(entity);
            }
            Entities.Remove(entity);
        }
        public virtual int Update(T entity)
        {
            Entities.Attach(entity);
            demoAppContext.Entry(entity).State = EntityState.Modified;
            return demoAppContext.SaveChanges();
        }
        public IDbSet<T> Entities
        {
            get
            {
                if (dbSet == null)
                    dbSet = demoAppContext.Set<T>();
                return dbSet;
            }
        }


    }

}
