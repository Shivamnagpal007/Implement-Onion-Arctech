using Domain_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implement_Onion_Arctech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }

        [HttpGet]
        public IActionResult GetDepartments()
        {

            var EmployeeList = _employeeService.GetAll().ToList();
            return Ok(EmployeeList);

        }
        [HttpGet("{Id:int}", Name = "Getdep")]
        public IActionResult GetDepatment(int Id)
        {

            var Employee = _employeeService.Get(Id);
            if (Employee == null)
                return StatusCode(404, ModelState);
            return Ok(Employee);
        }
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Employee employee)
        {
            if (employee == null)            
                return BadRequest();  // 400 Error         
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_employeeService.Add(employee))
            {            
                return StatusCode(500, ModelState); // Server Error
            }
            return Ok();

        }
        [HttpPut("{Id:int}")]
        public IActionResult UpdateDepartment(int Id, [FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();
           
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_employeeService.Update(employee))
            {               
                return StatusCode(500, ModelState);
            }
            return Ok();

        }
        [HttpDelete("{Id:int}")]
        public IActionResult DeleteDepartment(int Id)
        {        
            if (Id == 0)
                return NotFound();
            if (!_employeeService.Remove(Id))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return Ok();
        }
    }
}

