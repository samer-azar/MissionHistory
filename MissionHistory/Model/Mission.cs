using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class Mission
    {
        public int ID { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public DateTime? DepartureToCaseTime { get; set; }
        public DateTime? ArrivalToCaseTime { get; set; }
        public DateTime? DepartureToDestinationTime { get; set; }
        public DateTime? ArrivalToDestinationTime { get; set; }
        public DateTime? MissionCompletedTime { get; set; }
        public DateTime? ReturnToStationTime { get; set; }
        public double MissionDurationInMinutes { get; set; }
        public int IdVehicle { get; set; }
        public string VehicleNumber { get; set; }
        public int InitialMileage { get; set; }
        public int FinalMileage { get; set; }
        public int TraveledDistanceInKm { get; set; }
        public int IdDriver { get; set; }
        public string DriverName { get; set; }
        public int IdRescuer1 { get; set; }
        public string Rescuer1Name { get; set; }
        public int IdRescuer2 { get; set; }
        public string Rescuer2Name { get; set; }
        public int IdRescuer3 { get; set; }
        public string Rescuer3Name { get; set; }
        public int IdRescuer4 { get; set; }
        public string Rescuer4Name { get; set; }
        public int IdMissionCategory { get; set; }
        public string MissionCategoryValue { get; set; }
        public int IdMissionDirection { get; set; }
        public string MissionDirectionValue { get; set; }
        public int IdFromArea { get; set; }
        public string FromArea { get; set; }
        public int IdFromHospital { get; set; }
        public string FromHospital { get; set; }
        public int IdFromNursingHome { get; set; }
        public string FromNursingHome { get; set; }
        public int IdToArea { get; set; }
        public string ToArea { get; set; }
        public int IdToHospital { get; set; }
        public string ToHospital { get; set; }
        public int IdToNursingHome { get; set; }
        public string ToNursingHome { get; set; }
        public string PatientFullName { get; set; }
        public int PatientYob { get; set; }
        public int IdPatientNationality { get; set; }
        public string PatientNationality { get; set; }
        public int IdCaseType { get; set; }
        public int IdCase { get; set; }
        public string Case { get; set; }
        public string CaseDescription { get; set; }
        public int IdCaseClassification { get; set; }
        public string CaseClassification { get; set; }
        public string PassengerFullName { get; set; }
        public int PassengerYob { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public int NumberOfInjuries { get; set; }
    }
}
