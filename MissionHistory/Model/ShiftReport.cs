using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class ShiftReport
    {
        public int Id { get; set; }
        public DateTime ShiftDate { get; set; }
        public bool IsDamaged476 { get; set; }
        public bool IsDamaged477 { get; set; }
        public bool IsDamaged478 { get; set; }
        public bool IsDamaged479 { get; set; }
        public bool IsDamaged480 { get; set; }
        public bool IsDamaged443 { get; set; }
        public int SoinAuCentre { get; set; }
        public int NumberOfRescuers { get; set; }
        public int NumberOfTeams { get; set; }
        public int IdTeamLeader { get; set; }
        public string Notes { get; set; }
        public string MissionClassification { get; set; }
        public int MissionClassificationOccurence { get; set; }
    }
}
