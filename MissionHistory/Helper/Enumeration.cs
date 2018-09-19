using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Helper
{
    public class Enumeration
    {
        public enum DirectionFlagEnum
        {
            FromAreaToHospital = 1,
            FromHospitalToHospital = 2,
            FromHospitalToArea = 3,
            FromAreaToArea = 4,
            FromAreaToNull = 5,
            FromNursingHomeToHospital = 6,
            FromAreaToNursingHome = 7,
            FromHospitalToNursingHome = 8,
            FromNursingHomeToNursingHome = 9
        }

        public enum FromDirectionFlagEnum
        {
            FromArea = 1,
            FromHospital = 2,
            FromNursingHome = 3
        }

        public enum MissionCategoryEnum
        {
            Emergency = 1,
            Transport = 2,
            Diverse = 3
        }

        public enum CaseTypeEnum
        {
            Trauma = 1,
            Medical = 2,
            Critical = 3,
            Other = 4
        }

        public enum MissionStatusEnum
        {
            Cancelled = 100,
            Scheduled = 1,
            DepartureToCase = 2,
            ArrivalToCase = 3,
            DepartureToDestination = 4,
            ArrivalToDestination = 5,
            DepartureToCenter = 6,
            ArrivalToCenter = 7,
            DetailsFilled = 8
        }

        public enum PhoneBookTabPages
        {
            Rescuers = 0,
            Stations = 1,
            Hospitals = 2,
            NursingHomes = 3,
            Bts = 4
        }



    }
}
