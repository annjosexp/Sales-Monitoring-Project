using Microsoft.EntityFrameworkCore;
using SalesMonitoringAPI.Models;
using SalesMonitoringAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMonitoringAPI.Repository
{
    public class EmpRepo:IEmpRepo
    {
        SalesMonitoringDBContext _db;

        public EmpRepo(SalesMonitoringDBContext db)
        {
            _db = db;
        }

        #region get all Employee
        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            if (_db != null)
            {
                return await (from e in _db.TblEmployee
                              from u in _db.TblUser
                              where e.LoginId == u.LoginId
                              select new EmployeeModel
                              {
                                  EmpId = e.EmpId,

                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Age = e.Age,
                                  Gender = e.Gender,
                                  EmpAddress = e.EmpAddress,
                                   PhoneNo = e.PhoneNo,
                                   UserType =u.UserType

                              }).ToListAsync();

            }
            return null;
        }
        #endregion


        #region Add employee

        public async Task<TblEmployee> AddEmployee(TblEmployee employee)
        {
            {
                //--- member function to add department ---//
                if (_db != null)
                {
                    await _db.TblEmployee.AddAsync(employee);
                    await _db.SaveChangesAsync();
                    return employee;
                }
                return null;

            }


        }
        #endregion

        public async Task<TblEmployee> DeleteEmployee(int id)
        {

            if (_db != null)
            {
                TblEmployee dbemp = _db.TblEmployee.Find(id);
                _db.TblEmployee.Remove(dbemp);
                _db.SaveChanges();

                return (dbemp);
            }

            return null;


        }

       


       

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            if (_db != null)
            {
                //LINQ
                //join post and category



                return await (from e in _db.TblEmployee
                              from u in _db.TblUser
                              where e.LoginId == u.LoginId
                              select new EmployeeModel
                              {
                                  EmpId = e.EmpId,

                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Age = e.Age,
                                  Gender = e.Gender,
                                  EmpAddress = e.EmpAddress,
                                  PhoneNo = e.PhoneNo,
                                  UserType = u.UserType
                              }).FirstOrDefaultAsync();


            }
            return null;

        }

        public async Task<TblEmployee> UpdateEmployee(TblEmployee employee)
        {
            if (_db != null)
            {
                _db.TblEmployee.Update(employee);
                await _db.SaveChangesAsync();
                return employee;
            }
            return null;
        }
        //--- member function to add values to room table ---//







    }
}