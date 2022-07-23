using Microsoft.AspNetCore.Mvc;
using Sqlite_20220723.EFDbContext;

namespace Sqlite_20220723.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly AppDbContext _appDbContext;

        public EmployeeController(ILogger<EmployeeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _appDbContext.Employee;
        }
    }
}