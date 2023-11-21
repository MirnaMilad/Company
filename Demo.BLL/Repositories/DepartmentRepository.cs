using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        private readonly MVCAppContext _dbContext;
        public DepartmentRepository(MVCAppContext _dbContext) : base(_dbContext) { }
    }
}
