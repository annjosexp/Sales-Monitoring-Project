using Microsoft.EntityFrameworkCore;
using SalesMonitoringAPI.Models;
using SalesMonitoringAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMonitoringAPI.Repository
{
    public class VisitRepo:IVisitRepo
    {
        SalesMonitoringDBContext _db;

        public VisitRepo(SalesMonitoringDBContext db)
        {
            _db = db;
        }

        #region get all Visit
        public async Task<List<VisitModel>> GetAllVisit()
        {
            if (_db != null)
            {
                return await (from v in _db.TblVisit
                              from e in _db.TblEmployee
                              where v.EmpId == e.EmpId
                              select new VisitModel
                              {
                                  VisitId = v.VisitId,
                                  CustName = v.CustName,
                                  ContactPerson = v.ContactPerson,
                                  ContactNo = v.ContactNo,
                                  InterestProduct = v.InterestProduct,
                                  VisitSubject = v.VisitSubject,
                                  Vdescription = v.Vdescription,
                                  VisitDateTime = v.VisitDateTime,
                                  IsDisabled = v.IsDisabled,
                                  IsDeleted = v.IsDeleted,
                                  FirstName = e.FirstName,
                                  LastName = e.LastName

                                         
       
                       
                

    }).ToListAsync();

            }
            return null;
        }
        #endregion


        #region Add Visit

        public async Task<TblVisit> AddVisit(TblVisit visit)
        {
            {
                
                if (_db != null)
                {
                    await _db.TblVisit.AddAsync(visit);
                    await _db.SaveChangesAsync();
                    return visit;
                }
                return null;

            }


        }
        #endregion

        public async Task<TblVisit> DeleteVisit(int id)
        {

            if (_db != null)
            {
                TblVisit dbvisit = _db.TblVisit.Find(id);
                dbvisit.IsDeleted=true;
                dbvisit.IsDisabled = true;

                _db.SaveChanges();

                return (dbvisit);
            }

            return null;


        }






        public async Task<VisitModel> GetVisitById(int id)
        {
            if (_db != null)
            {
                //LINQ
                //join post and category



                return await (from v in _db.TblVisit
                              from e in _db.TblEmployee
                              where v.EmpId == e.EmpId
                              select new VisitModel
                              {
                                  VisitId = v.VisitId,
                                  CustName = v.CustName,
                                  ContactPerson = v.ContactPerson,
                                  ContactNo = v.ContactNo,
                                  InterestProduct = v.InterestProduct,
                                  VisitSubject = v.VisitSubject,
                                  Vdescription = v.Vdescription,
                                  VisitDateTime = v.VisitDateTime,
                                  IsDisabled = v.IsDisabled,
                                  IsDeleted = v.IsDeleted,
                                  FirstName = e.FirstName,
                                  LastName = e.LastName
                              }).FirstOrDefaultAsync();


            }
            return null;

        }

        public async Task<TblVisit> UpdateVisit(TblVisit visit)
        {
            if (_db != null)
            {
                _db.TblVisit.Update(visit);
                await _db.SaveChangesAsync();
                return visit;
            }
            return null;
        }

       
    }
}
   
