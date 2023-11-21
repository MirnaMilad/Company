using Demo.BLL.Interfaces;
using Demo.DAL.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        private readonly MVCAppContext _dbContext;

        public UnitOfWork(MVCAppContext dbContext) //Ask CLR to create object from DBcontext
        {
           EmployeeRepository= new EmployeeRepository(dbContext);
           DepartmentRepository= new DepartmentRepository(dbContext);
            _dbContext = dbContext;
        }

        public Task<int> CompleteAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
