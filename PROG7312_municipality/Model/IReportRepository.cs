using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_municipality.Model
{
    internal interface IReportRepository
    {
       
        void AddReport(ReportModel report);


        List<ReportModel> GetReportsByUserId(Guid id);





        // All Retrieve
        IEnumerable<ReportModel> GetAllReports();

        //Can implement something that grab the latest few.

       
    }
}