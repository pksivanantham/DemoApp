using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Data
{
   public  interface IDemoAppContext
    {
       IDbSet<T> Set<T>() where T : class;
    }
}
