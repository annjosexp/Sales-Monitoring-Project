using Microsoft.AspNetCore.Mvc;
using SalesMonitoringAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMonitoringAPI.Repository
{
    public interface ILogin
    {
        public TblUser GetUser(TblUser tblUser);

        Task<ActionResult<TblUser>> GetUserByPassword(string un, string pwd);
        public TblUser validateUser(string username, string password);


    }
}
