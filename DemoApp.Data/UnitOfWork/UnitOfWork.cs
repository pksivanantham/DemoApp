using DemoApp.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoAppContext _demoAppContext;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork()
        {
            _demoAppContext = new DemoAppContext();
        }
        public UnitOfWork(DemoAppContext demoAppContext)
        {
            _demoAppContext = demoAppContext;
        }
        public void Save()
        {
            _demoAppContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!_disposed)

                if (disposing)

                    _demoAppContext.Dispose();
            _disposed = true;
        }


        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();
            var type = typeof(T).Name;
            if(!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _demoAppContext);
                _repositories.Add(type, repositoryInstance);
            }
            return (IRepository<T>)_repositories[type];
        }
    }
}
