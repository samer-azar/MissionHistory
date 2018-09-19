using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class MissionDirection
    {
        public int Id { get; set; }
        public int IdMissionCategory { get; set; }
        public int DirectionFlag { get; set; }
        public string Description { get; set; }
        
    }
}
