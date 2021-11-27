using SalesMonitoringAPI.Models;
using SalesMonitoringAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMonitoringAPI.Repository
{
   public interface IVisitRepo
    {
        //--- get all Visit ---//

        Task<List<VisitModel>> GetAllVisit();



        //--- get Visit by id ---//
        Task<VisitModel> GetVisitById(int id);

        Task<TblVisit> DeleteVisit(int id);





        //--- add Visit ---//
        Task<TblVisit> AddVisit(TblVisit visit);



        //--- update Visit ---//
        Task<TblVisit> UpdateVisit(TblVisit Visit);



    }
}