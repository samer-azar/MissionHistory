using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameArabic { get; set; }
        public string Code { get; set; }
        public int IdRelatedStation { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Radius { get; set; }

    }
}
