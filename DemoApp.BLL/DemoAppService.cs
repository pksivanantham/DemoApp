using DemoApp.Client;
using DemoApp.Data.UnitOfWork;
using DemoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.BLL
{
    public class DemoAppService:IDemoAppService
    {
        private IUnitOfWork _demoAppService;
        public DemoAppService(IUnitOfWork demoAppService)
        {
            this._demoAppService = demoAppService;
        }
         public IList<Student> GetStudentData()
        {
            var query = _demoAppService.Repository<Student>().Table.ToList();

            return query;
        }
    }
}
