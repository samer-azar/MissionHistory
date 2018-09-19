using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class CaseClassification
    {
        public int Id { get; set; }
        public int IdMissionCategory { get; set; }
        public string Value { get; set; }
        public string ValueArabic { get; set; }


    }
}
