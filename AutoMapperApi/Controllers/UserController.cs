using AutoMapper;
using AutoMapperModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperApi.Controllers
{

    [ApiController]
   
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/user")]
        public ActionResult<UserDTO> GetUser()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            var userDto = _mapper.Map<UserDTO>(user);

            return Ok(userDto);
        }


        [HttpGet]
        [Route("api/employees")]
        public ActionResult<EmployeeDTO> GetEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FullName = "John Doe", Department = "HR", Salary = 50000 },
                new Employee { Id = 2, FullName = "Jane Smith", Department = "IT", Salary = 60000 }
            };

            var employeeDtos = _mapper.Map<List<EmployeeDTO>>(employees);

            return Ok(employeeDtos);
        }
    }
}

