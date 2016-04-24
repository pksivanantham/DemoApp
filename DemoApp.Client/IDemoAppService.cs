using DemoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Client
{
    public interface IDemoAppService
    {
         IList<Student>  GetStudentData();
    }
}
