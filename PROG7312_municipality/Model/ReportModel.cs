using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_municipality.Model
{
    public class ReportModel
    {
        
        public string Location { get; set; }
        public string Description { get; set; }
        public string SelectedCategory { get; set; }
        public string FilePath { get; set; }

        //user id
        public Guid UserID { get; set; }
    }
}
