using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class Vehicle
    {

        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int LastMileage { get; set; }
        public int Status { get; set; }
        public int MileageOnLubeChange { get; set; }
    }
}
