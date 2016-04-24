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
           this.dbSet = demoAppContext.Set<T>();
       }

        public  IQueryable<T> Table     
       {
           get
           {
               return dbSet.AsQueryable<T>();
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
           return dbSet.Find(Id);
       }
        public virtual void Insert(T entity)
       {
           var obj = dbSet.Add(entity);
           demoAppContext.SaveChanges();
            
       }
        public virtual void Delete(Object Id)
        {
            T entityToDelete = dbSet.Find(Id);
            
        }

        public virtual void Delete(T entity)
        {
            if(demoAppContext.Entry(entity).State==EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            demoAppContext.Entry(entity).State = EntityState.Modified;
        }


    }

}
