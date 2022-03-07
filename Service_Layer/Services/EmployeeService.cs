using Domain_Layer;
using Repository_Layer.Repository.IRepository;
using Service_Layer.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public bool Add(Employee entity)
        {
            if (entity == null)
                return false;
            _unitOfWork.employee.Add(entity);
            _unitOfWork.employee.Save();
            return true;
        }

        public Employee Get(int Id)
        {
            if (Id == 0)
                return null;
            var employee = _unitOfWork.employee.Get(Id);
            if (employee == null)
                return null;
            return employee;


        }

        public IEnumerable<Employee> GetAll()
        {
            var employelist = _unitOfWork.employee.GetAll();
            return employelist;
        }

        public bool Remove(int id)
        {         
            var emp = _unitOfWork.employee.Get(id);
            if (emp == null)
                return false;
            if (!_unitOfWork.employee.Remove(emp))
            {
                return false;
            }
            return true;
        }

        public bool Save()
        {
            return _unitOfWork.employee.Save();
        }

        public bool Update(Employee employee)
        {
            if (employee == null)
                return false;
            if (!_unitOfWork.employee.Update(employee))
            {
                return false;
            }
            return true;
        }
    }
}
