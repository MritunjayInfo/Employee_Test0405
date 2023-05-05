using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Test0405.Models;
using Test0405.TestDbContext;

namespace Test0405.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public EmployeeController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }


        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var emp = _dbContext.Employees.ToList();
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult PostEmployee([FromForm] AddEmployee employee)
        {
            var GetDOB = DateTime.Parse(employee.Dob.ToString()).Year;

            var today = DateTime.Today;

            var age=today.Year-GetDOB;

            var org = employee;
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms)
;
                org.DocumentByteUpload = ms.ToArray();
            }

            var emp = new Employee
            {
                Name= employee.Name,
                Age= age,
                Dob= employee.Dob,
                Mobile= employee.Mobile,
                Password= employee.Password,
                DocumentByteUpload=org.DocumentByteUpload,
            };
            _dbContext.Employees.Add(emp);
            _dbContext.SaveChanges();
            return Ok(emp);
        }
    }
}
