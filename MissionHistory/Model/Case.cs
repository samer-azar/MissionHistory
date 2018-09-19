using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class Case
    {
        public int Id { get; set; }
        public int IdCaseType { get; set; }
        public string Value { get; set; }
        public string ValueArabic { get; set; }
        public int IdBettaCaseClassification { get; set; }

    }
}
