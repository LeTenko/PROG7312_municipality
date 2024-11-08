using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_municipality.Model
{
    public class EventLikeModel
    {
        public int LikeID { get; set; }
        public int EventID { get; set; }
        public Guid UserID { get; set; }
        public DateTime LikeTime { get; set; }
    }
}
