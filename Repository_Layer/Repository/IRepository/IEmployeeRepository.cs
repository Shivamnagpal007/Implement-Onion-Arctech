using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        bool Update(Employee employee);

    }
}
