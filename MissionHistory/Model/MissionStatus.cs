using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class MissionStatus
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public string Status { get; set; }
        public string StatusArabic { get; set; }
    }
}
