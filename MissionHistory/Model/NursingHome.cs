using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class NursingHome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdRelatedStation { get; set; }
        public string PhoneNumber { get; set; }
    }
}
