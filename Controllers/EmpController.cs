using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesMonitoringAPI.Models;
using SalesMonitoringAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
       

            IEmpRepo empRepository;
            public EmpController(IEmpRepo _p)
            {
                empRepository = _p;
            }
            #region Employee details 
            [HttpGet]
            [Route("GetAllEmployee")]
            public async Task<IActionResult> GetAllEmployee()
            {
                try
                {
                    var exp = await empRepository.GetAllEmployee();
                    if (exp == null)
                    {
                        return NotFound();
                    }
                    return Ok(exp);
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            #endregion
            #region Employee details by id
            [HttpGet]
            [Route("GetEmployeeById")]
            public async Task<IActionResult> GetEmployeeById(int id)
            {
                try
                {
                    var exp = await empRepository.GetEmployeeById(id);
                    if (exp == null)
                    {
                        return NotFound();
                    }
                    return Ok(exp);
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            #endregion






            #region Delete Employee 
            [HttpDelete]
            [Route("DeleteEmployee")]
            public async Task<IActionResult> DeleteEmployee(int id)
            {
                try
                {
                    var exp = await empRepository.DeleteEmployee(id);
                    if (exp == null)
                    {
                        return NotFound();
                    }
                    return Ok(exp);
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            #endregion







           
            #region Add employee

            [HttpPost]
            [Route("AddEmployee")]
            public async Task<IActionResult> AddEmployee(TblEmployee employee)
            {
                //check the validation of body
                if (ModelState.IsValid)
                {
                    try
                    {
                        var empId = await empRepository.AddEmployee(employee);
                        if (empId != null)
                        {
                            return Ok(empId);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }

            #endregion



           

            #region Update Employee
            [HttpPut]
            // [Authorize]
            [Route("UpdateEmployee")]
            public async Task<IActionResult> UpdateEmployee(TblEmployee employee)
            {
                //Check the validation of body
                if (ModelState.IsValid)
                {
                    try
                    {
                        await empRepository.UpdateEmployee(employee);
                        return Ok(employee);
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            #endregion
        }
    }