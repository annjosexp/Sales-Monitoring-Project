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
    public class VisitController : ControllerBase
    {

        IVisitRepo visitRepository;
        public VisitController(IVisitRepo _p)
        {
            visitRepository = _p;
        }
        #region Visit details 
        [HttpGet]
        [Route("GetAllVisit")]
        public async Task<IActionResult> GetAllVisit()
        {
            try
            {
                var exp = await visitRepository.GetAllVisit();
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
        #region visit details by id
        [HttpGet]
        [Route("GetvisitById")]
        public async Task<IActionResult> GetVisitById(int id)
        {
            try
            {
                var exp = await visitRepository.GetVisitById(id);
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






        #region Delete visit
        [HttpDelete]
        [Route("Deletevisit")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            try
            {
                var exp = await visitRepository.DeleteVisit(id);
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








        #region Add Visit

        [HttpPost]
        [Route("AddVisit")]
        public async Task<IActionResult> AddEmployee(TblVisit visit)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var visitId = await visitRepository.AddVisit(visit);
                    if (visitId != null)
                    {
                        return Ok(visitId);
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





        #region Update visit
        [HttpPut]
        // [Authorize]
        [Route("UpdateVisit")]
        public async Task<IActionResult> UpdateVisit(TblVisit visit)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await visitRepository.UpdateVisit(visit);
                    return Ok(visit);
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