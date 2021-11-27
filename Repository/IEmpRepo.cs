using SalesMonitoringAPI.Models;
using SalesMonitoringAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMonitoringAPI.Repository
{
   public interface IEmpRepo
    {
        //--- get all employee ---//

        Task<List<EmployeeModel>> GetAllEmployee();



        //--- get employee by id ---//
        Task<EmployeeModel> GetEmployeeById(int id);

        Task<TblEmployee> DeleteEmployee(int id);





        //--- add Employee ---//
        Task<TblEmployee> AddEmployee(TblEmployee employee);



        //--- update Employee ---//
        Task<TblEmployee> UpdateEmployee(TblEmployee employee);



    }
}