using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_CRUD_API.Context;
using WEB_CRUD_API.Helper;
using WEB_CRUD_API.Models;
using WEB_CRUD_API.Repositories;

namespace WEB_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly EmployeeRepository _employeeRepo;
        public ResponCode _responCode = new();

        private object _respon;
        private object _objek;
        private Employee dataCheck;
        public EmployeeController(AppDbContext context, EmployeeRepository employee)
        {
            _employeeRepo = employee;
            _context = context;
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetEmployee()
        {
            _objek = _employeeRepo.GetAllEmployee();
            _respon = _responCode.Respon(_responCode.CodeOk, _responCode.MessageGetSuccess("Employee"), _objek);

            return Ok(_respon);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepo.CreateEmployee(employee);
                _respon = _responCode.Respon(_responCode.CodeOk, _responCode.MessageAddSuccess("Employee"), employee);

                return Ok(_respon);
            }
            _respon = _responCode.Respon(_responCode.CodeBadRequest, _responCode.MessageInputWrong("Employee"), null);
            return Ok(_respon);
        }

        [Route("GetDetail/{id}")]
        [HttpGet]
        public IActionResult DetailEmployee(Guid id)
        {
            dataCheck = _employeeRepo.GetEmployeeById(id);

            if (dataCheck != null)
            {
                _respon = _responCode.Respon(_responCode.CodeOk, _responCode.MessageGetSuccess("Employee"), dataCheck);
                return Ok(_respon);
            }

            _respon = _responCode.Respon(_responCode.CodeBadRequest, _responCode.MessageDataNotFound("Employee"), null);
            return Ok(_respon);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                dataCheck = _employeeRepo.GetEmployeeById(id);
                
                if (dataCheck != null)
                {
                    await _employeeRepo.DeleteEmploye(dataCheck);

                    _respon = _responCode.Respon(_responCode.CodeOk, _responCode.MessageDeleteSuccess("Employee"), dataCheck);
                    
                    return Ok(_respon);
                }
                
                _respon = _responCode.Respon(_responCode.CodeInternalServerError, _responCode.MessageDataNotFound("Employee"), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _responCode.Respon(_responCode.CodeBadRequest, _responCode.MessageInputWrong("Employee"), null);
                return Ok(_respon);
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dataCheck = _employeeRepo.GetEmployeeById(employee.EmployeeId);

                if (dataCheck != null)
                {
                    await _employeeRepo.UpdateEmployee(employee);

                    dataCheck = _employeeRepo.GetEmployeeById(employee.EmployeeId);

                    _respon = _responCode.Respon(_responCode.CodeOk, _responCode.MessageEditSuccess("Employee"), dataCheck);
                    return Ok(_respon);
                }
                _respon = _responCode.Respon(_responCode.CodeInternalServerError, _responCode.MessageDataNotFound("Employee"), null);
                return Ok(_respon);
            }

            _respon = _responCode.Respon(_responCode.CodeBadRequest, _responCode.MessageInputWrong("Employee"), null);
            return Ok(_respon);
        }
    }
}
