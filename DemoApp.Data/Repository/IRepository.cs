﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Data.Repository
{
    public interface IRepository<T> where T : class 
    {

       IQueryable<T> Table { get;  }
      IEnumerable<T> TableAsEnumerable { get;  }
       T GetById(object Id);
       void Insert(T entity);
       void Delete(Object Id);
       void Delete(T entity);
       void Update(T Entity);      


      
    }
}