using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class Area
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string NameArabic { get; set; }
        public int Radius { get; set; }
        public int IdRelatedStation { get; set; }
        public int IdSecondRelatedStation { get; set; }

    }
}
