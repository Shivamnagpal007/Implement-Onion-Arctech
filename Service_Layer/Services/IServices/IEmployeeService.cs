using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services.IServices
{
    public interface IEmployeeService
    {
        Employee Get(int Id);

        IEnumerable<Employee> GetAll();

        bool Add(Employee entity);

        bool Remove(int id);

        bool Save();
        bool Update(Employee employeeTable);
    }
}
