using Repository_Layer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
       
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            employee = new EmployeeRepository(_context);

        }
        public IEmployeeRepository employee { get; private set; }   
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
