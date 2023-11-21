using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository:GenericRepository<Employee>, IEmployeeRepository
    {


        private readonly MVCAppContext _dbContext;
        public EmployeeRepository(MVCAppContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }


        public IQueryable<Employee> GetEmployeeByAdress(string address)
        {
            return _dbContext.Employees.Where(e => e.Address == address);
        }

        public IQueryable<Employee> GetEmployeeByName(string SearchValue)
        {
                return _dbContext.Employees.Where(e => e.Name.ToLower().Contains(SearchValue.ToLower()));
        }
        //public int Add(Employee employee)
        //{
        //    _dbContext.Add(employee);
        //    return _dbContext.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    _dbContext.Remove(employee);
        //    return _dbContext.SaveChanges();
        //}

        //public IEnumerable<Employee> GetAll()
        //{
        //    return _dbContext.Employees.ToList();
        //}

        //public Employee GetById(int id)
        //{
        //    return _dbContext.Employees.Find(id);
        //}

        //public int Update(Employee employee)
        //{
        //    _dbContext.Employees.Update(employee);
        //    return _dbContext.SaveChanges();
        //}
    }
}
