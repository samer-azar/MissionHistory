using MissionHistory.DataAccessLayer;
using MissionHistory.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MissionHistory.Helper.Enumeration;

namespace MissionHistory.BusinessLogicLayer
{
    public class OperationsBlo
    {
        public static List<Vehicle> GetAllVehicles()
        {
            Vehicle vehicle;
            List<Vehicle> vehicles = new List<Vehicle>();

            int id, year, lastMileage, status;

            DataSet dsVehicles = OperationsDal.GetAllVehicles();
            if (dsVehicles.Tables.Count > 0 && dsVehicles.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsVehicles.Tables[0].Rows)
                {
                    vehicle = new Vehicle();
                    int.TryParse(dr["ID"].ToString(), out id);
                    vehicle.Id = id;
                    vehicle.PlateNumber = dr["Number"].ToString();
                    vehicle.Brand = dr["Brand"].ToString();
                    vehicle.Model = dr["Model"].ToString();
                    int.TryParse(dr["Year"].ToString(), out year);
                    vehicle.Year = year;
                    int.TryParse(dr["LastMileage"].ToString(), out lastMileage);
                    vehicle.LastMileage = lastMileage;
                    int.TryParse(dr["Status"].ToString(), out status);
                    vehicle.Status = status;

                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }
        
        public static string GetLastMileage(List<Vehicle> Vehicles, int Id)
        {
            Vehicle vehicle = Vehicles.Where(a => a.Id == Id).First();
            return vehicle.LastMileage.ToString();
        }

        public static List<Nationality> GetAllNationalities()
        {
            Nationality nationality;
            List<Nationality> nationalities = new List<Nationality>();

            int id, degree;

            DataSet dsNationality = OperationsDal.GetAllNationalities();
            if (dsNationality.Tables.Count > 0 && dsNationality.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsNationality.Tables[0].Rows)
                {
                    nationality = new Nationality();
                    int.TryParse(dr["ID"].ToString(), out id);
                    nationality.Id = id;
                    nationality.Country = dr["Country"].ToString();
                    nationality.CountryCode = dr["CountryCode"].ToString();
                    nationality.NationalityValue = dr["Nationality"].ToString();
                    int.TryParse(dr["Degree"].ToString(), out degree);
                    nationality.Degree = degree;

                    nationalities.Add(nationality);
                }
            }
            return nationalities;
        }

        public static List<Rescuer> GetActiveRescuers()
        {
            Rescuer rescuer;
            List<Rescuer> rescuers = new List<Rescuer>();

            int id, idStation, teamNumber, status;
            bool isEdj, isDriver;
            DateTime dob, doe;

            DataSet dsRescuer = OperationsDal.GetActiveRescuers();
            if (dsRescuer.Tables.Count > 0 && dsRescuer.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsRescuer.Tables[0].Rows)
                {
                    rescuer = new Rescuer();
                    int.TryParse(dr["ID"].ToString(), out id);
                    rescuer.Id = id;
                    int.TryParse(dr["IdStation"].ToString(), out idStation);
                    rescuer.IdStation = idStation;
                    int.TryParse(dr["TeamNumber"].ToString(), out teamNumber);
                    rescuer.TeamNumber = teamNumber;
                    bool.TryParse(dr["IsEdj"].ToString(), out isEdj);
                    rescuer.IsEdj = isEdj;
                    rescuer.Name = dr["Name"].ToString();
                    rescuer.LastName = dr["FamilyName"].ToString();
                    rescuer.Nickname = dr["Nickname"].ToString();
                    DateTime.TryParse(dr["DateOfBirth"].ToString(), out dob);
                    rescuer.DateOfBirth = dob;
                    DateTime.TryParse(dr["DateOfEnrollement"].ToString(), out doe);
                    rescuer.DateOfEnrollement = doe;
                    rescuer.MembershipCardNumber = dr["MembershipCardNumber"].ToString();
                    rescuer.BloodType = dr["BloodType"].ToString();
                    rescuer.Address = dr["Address"].ToString();
                    rescuer.PhoneNumber = dr["PhoneNumber"].ToString();
                    rescuer.MobileNumber = dr["MobileNumber"].ToString();
                    rescuer.EmailAddress = dr["EmailAddress"].ToString();
                    bool.TryParse(dr["IsDriver"].ToString(), out isDriver);
                    rescuer.IsDriver = isDriver;
                    int.TryParse(dr["Status"].ToString(), out status);
                    rescuer.Status = status;

                    rescuers.Add(rescuer);
                }
            }
            return rescuers;
        }
        
        internal static List<Rescuer> OrderRescuersByShift(List<Rescuer> Rescuers)
        {
            List<Rescuer> primaryList;
            List<Rescuer> secondaryList;
            List<Rescuer> tertiaryList;

            bool isEdjTiming = false;
            int teamNumber = 0;
            int dayOfWeek = (int)DateTime.Today.DayOfWeek;
            int hour = DateTime.Now.Hour;

            if (dayOfWeek >= 1 && dayOfWeek <= 6)
            {
                //Case of Monday to Saturday
                if (hour >= 0 && hour < 8)
                {
                    //Between midnight and 8 o'clock in the morning, get the EDN
                    isEdjTiming = false;
                    if (dayOfWeek == 1)
                    {
                        //If it's a monday, get the sunday team
                        teamNumber = GetSundayTeamNumber();
                    }
                    else
                    {
                        //If it's not a monday get the weekday number of the day before
                        teamNumber = dayOfWeek - 1;
                    }
                }
                else
                {
                    teamNumber = dayOfWeek;
                    if (hour >= 8 && hour < 18)
                    {
                        //Between 8 o'clock in the morning and 6 o'clock in the evening, get the EDJ
                        isEdjTiming = true;
                        teamNumber = dayOfWeek;
                    }
                    if (hour >= 18)
                    {
                        //Between 6 o'clock in the evening and midnight
                        isEdjTiming = false;
                        if (dayOfWeek == 6)
                            teamNumber = GetSaturdayTeamNumber();
                        else
                            teamNumber = dayOfWeek;
                    }
                }
            }
            else if (dayOfWeek == 0)
            {
                //Case of Sundays
                isEdjTiming = false;
                if (hour >= 0 && hour < 13)
                {
                    //Between midnight and 1 o'clock in the afternoon, get the Saturday team
                    teamNumber = GetSaturdayTeamNumber();
                }
                else
                {
                    //Between 1 o'clock in the afternoon and midnight, get the week day team of the sunday shift
                    teamNumber = GetSundayTeamNumber();
                }
            }

            if (isEdjTiming)
            {
                primaryList = Rescuers.Where(a => a.IsEdj == isEdjTiming).ToList();
                secondaryList = Rescuers.Where(a => a.IsEdj != isEdjTiming).Where(c => c.TeamNumber == teamNumber).ToList();
                tertiaryList = Rescuers.Where(a => a.IsEdj != isEdjTiming).Where(c => c.TeamNumber != teamNumber).ToList();
                return primaryList.Union(secondaryList).Union(tertiaryList).ToList();
            }
            else
            {
                primaryList = Rescuers.Where(c => c.TeamNumber == teamNumber).ToList();
                secondaryList = Rescuers.Where(c => c.TeamNumber != teamNumber).ToList();
                return primaryList.Union(secondaryList).ToList();
            }
        }

        public static string GetTeamLeaderName(int idTeamLeader)
        {
            return OperationsDal.GetTeamLeaderName(idTeamLeader);
        }

        private static int GetSaturdayTeamNumber()
        {
            DateTime saturdayAnchor = MissionHistory.Properties.Settings.Default.Saturday6DateAnchor;
            TimeSpan timeSpan = DateTime.Now.Subtract(saturdayAnchor);
            int dateDiff = timeSpan.Days;
            int totalWeeks = (int)dateDiff / 7;

            if ((totalWeeks % 2) == 0)
                return 6;
            else return 7;
        }

        internal static double UpdateMissionDuration(Mission CurrentMission)
        {
            double missionDurationInMninutes = 0;
            TimeSpan? missionDuration;
            if (CurrentMission.ReturnToStationTime.Value.Year != 1 && CurrentMission.DepartureToCaseTime.Value.Year != 1)
            {
                missionDuration = CurrentMission.ReturnToStationTime - CurrentMission.DepartureToCaseTime;
                missionDurationInMninutes = missionDuration.Value.TotalMinutes;
                OperationsDal.UpdateMissionDuration(missionDurationInMninutes, CurrentMission.ID);
            }

            return missionDurationInMninutes;
        }

        private static int GetSundayTeamNumber()
        {
            DateTime team1SundayDate = MissionHistory.Properties.Settings.Default.MondayTeamSundayDateAnchor;
            TimeSpan timeSpan = DateTime.Now.Subtract(team1SundayDate);
            int dateDiff = timeSpan.Days;
            int totalWeeks = (int)dateDiff / 7;
            int weekCounter = totalWeeks % 5;

            if (weekCounter == 0)
                return 5;
            else return ++weekCounter;
        }


        public static List<MissionDirection> GetAllMissionDirections()
        {
            MissionDirection missionDirection;
            List<MissionDirection> missionDirections = new List<MissionDirection>();

            int id, idMissionCategory, directionFlag;

            DataSet dsMissionDirection = OperationsDal.GetAllMissionDirections();
            if (dsMissionDirection.Tables.Count > 0 && dsMissionDirection.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsMissionDirection.Tables[0].Rows)
                {
                    missionDirection = new MissionDirection();
                    int.TryParse(dr["ID"].ToString(), out id);
                    missionDirection.Id = id;
                    int.TryParse(dr["IdMissionCategory"].ToString(), out idMissionCategory);
                    missionDirection.IdMissionCategory = idMissionCategory;
                    int.TryParse(dr["DirectionFlag"].ToString(), out directionFlag);
                    missionDirection.DirectionFlag = directionFlag;
                    missionDirection.Description = dr["Description"].ToString();

                    missionDirections.Add(missionDirection);
                }
            }

            return missionDirections;
        }

        public static List<MissionDirection> GetSpecificMissionDirections(List<MissionDirection> missionDirections, int missionCategoryId)
        {
            return missionDirections.Where(a => a.IdMissionCategory == missionCategoryId).ToList();
        }

        public static List<CaseType> GetAllCaseTypes()
        {
            CaseType caseType;
            List<CaseType> caseTypes = new List<CaseType>();

            int id;

            DataSet dsCaseType = OperationsDal.GetAllCaseTypes();
            if (dsCaseType.Tables.Count > 0 && dsCaseType.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsCaseType.Tables[0].Rows)
                {
                    caseType = new CaseType();
                    int.TryParse(dr["ID"].ToString(), out id);
                    caseType.Id = id;
                    caseType.Value = dr["Value"].ToString();
                    caseType.ValueArabic = dr["ValueArabic"].ToString();

                    caseTypes.Add(caseType);
                }
            }
            return caseTypes;
        }

        public static List<Case> GetAllCases()
        {
            Case casee;
            List<Case> cases = new List<Case>();

            int id, idCaseType, idBettaCaseClassification;

            DataSet dsCases = OperationsDal.GetAllCases();
            if (dsCases.Tables.Count > 0 && dsCases.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsCases.Tables[0].Rows)
                {
                    casee = new Case();
                    int.TryParse(dr["ID"].ToString(), out id);
                    casee.Id = id;
                    int.TryParse(dr["IdCaseType"].ToString(), out idCaseType);
                    casee.IdCaseType = idCaseType;
                    casee.Value = dr["Value"].ToString();
                    casee.ValueArabic = dr["ValueArabic"].ToString();
                    int.TryParse(dr["IdBettaCaseClassification"].ToString(), out idBettaCaseClassification);
                    casee.IdBettaCaseClassification = idBettaCaseClassification;

                    cases.Add(casee);
                }
            }
            return cases;
        }

        public static List<Case> GetSpecificCases(List<Case> cases, int caseTypeId)
        {
            return cases.Where(a => a.IdCaseType == caseTypeId).ToList();
        }

        public static List<CaseClassification> GetAllCaseClassifications()
        {
            CaseClassification caseClassification;
            List<CaseClassification> caseClassifications = new List<CaseClassification>();

            int id, idMissionCategory;

            DataSet dsCaseClassification = OperationsDal.GetAllCaseClassifications();
            if (dsCaseClassification.Tables.Count > 0 && dsCaseClassification.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsCaseClassification.Tables[0].Rows)
                {
                    caseClassification = new CaseClassification();
                    int.TryParse(dr["ID"].ToString(), out id);
                    caseClassification.Id = id;
                    int.TryParse(dr["IdMissionCategory"].ToString(), out idMissionCategory);
                    caseClassification.IdMissionCategory = idMissionCategory;
                    caseClassification.Value = dr["Value"].ToString();
                    caseClassification.ValueArabic = dr["ValueArabic"].ToString();

                    caseClassifications.Add(caseClassification);
                }
            }
            return caseClassifications;
        }

        public static List<CaseClassification> GetSpecificCaseClassifications(List<CaseClassification> caseClassifications, int missionCategoryId)
        {
            return caseClassifications.Where(a => a.IdMissionCategory == missionCategoryId).ToList();
        }

        public static List<Rescuer> GetActiveDrivers()
        {
            Rescuer rescuer;
            List<Rescuer> rescuers = new List<Rescuer>();

            int id, idStation, teamNumber, status;
            bool isEdj, isDriver;
            DateTime dob, doe;

            DataSet dsRescuer = OperationsDal.GetActiveRescuers();
            if (dsRescuer.Tables.Count > 0 && dsRescuer.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsRescuer.Tables[0].Rows)
                {
                    rescuer = new Rescuer();
                    int.TryParse(dr["ID"].ToString(), out id);
                    rescuer.Id = id;
                    int.TryParse(dr["IdStation"].ToString(), out idStation);
                    rescuer.IdStation = idStation;
                    int.TryParse(dr["TeamNumber"].ToString(), out teamNumber);
                    rescuer.TeamNumber = teamNumber;
                    bool.TryParse(dr["IsEdj"].ToString(), out isEdj);
                    rescuer.IsEdj = isEdj;
                    rescuer.Name = dr["Name"].ToString();
                    rescuer.LastName = dr["FamilyName"].ToString();
                    rescuer.Nickname = dr["Nickname"].ToString();
                    DateTime.TryParse(dr["DateOfBirth"].ToString(), out dob);
                    rescuer.DateOfBirth = dob;
                    DateTime.TryParse(dr["DateOfEnrollement"].ToString(), out doe);
                    rescuer.DateOfEnrollement = doe;
                    rescuer.MembershipCardNumber = dr["MembershipCardNumber"].ToString();
                    rescuer.BloodType = dr["BloodType"].ToString();
                    rescuer.Address = dr["Address"].ToString();
                    rescuer.PhoneNumber = dr["PhoneNumber"].ToString();
                    rescuer.MobileNumber = dr["MobileNumber"].ToString();
                    rescuer.EmailAddress = dr["EmailAddress"].ToString();
                    bool.TryParse(dr["IsDriver"].ToString(), out isDriver);
                    rescuer.IsDriver = isDriver;
                    int.TryParse(dr["Status"].ToString(), out status);
                    rescuer.Status = status;

                    rescuers.Add(rescuer);
                }
            }

            return rescuers.Where(a => a.IsDriver == true).ToList();
        }

        public static List<MissionCategory> GetMissionCategories()
        {
            int id;

            MissionCategory missionCategory;
            List<MissionCategory> missionCategories = new List<MissionCategory>();

            DataSet dsMissionCategory = OperationsDal.GetMissionCategories();
            if (dsMissionCategory.Tables.Count > 0 && dsMissionCategory.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsMissionCategory.Tables[0].Rows)
                {
                    missionCategory = new MissionCategory();
                    int.TryParse(dr["ID"].ToString(), out id);
                    missionCategory.Id = id;
                    missionCategory.DescriptionEnglish = dr["Description"].ToString();
                    missionCategory.DescriptionArabic = dr["DescriptionArabic"].ToString();

                    missionCategories.Add(missionCategory);
                }
            }

            return missionCategories;
        }

        public static List<Area> GetAllAreas()
        {
            int id, radius, IdRelatedStation, IdSecondRelatedStation;

            Area area;
            List<Area> areas = new List<Area>();

            DataSet dsAreas = OperationsDal.GetAllAreas();
            if (dsAreas.Tables.Count > 0 && dsAreas.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsAreas.Tables[0].Rows)
                {
                    area = new Area();
                    int.TryParse(dr["ID"].ToString(), out id);
                    area.Id = id;
                    area.Name = dr["Name"].ToString();
                    area.NameArabic = dr["NameArabic"].ToString();
                    int.TryParse(dr["Radius"].ToString(), out radius);
                    area.Radius = radius;
                    int.TryParse(dr["IdRelatedStation"].ToString(), out IdRelatedStation);
                    area.IdRelatedStation = IdRelatedStation;
                    int.TryParse(dr["IdSecondRelatedStation"].ToString(), out IdSecondRelatedStation);
                    area.IdSecondRelatedStation = IdSecondRelatedStation;

                    areas.Add(area);
                }
            }

            return areas;
        }

        public static List<Hospital> GetAllHospitals()
        {
            int id, idRelatedStation, radius;

            Hospital hospital;
            List<Hospital> hospitals = new List<Hospital>();

            DataSet dsHospitals = OperationsDal.GetAllHospitals();
            if (dsHospitals.Tables.Count > 0 && dsHospitals.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsHospitals.Tables[0].Rows)
                {
                    hospital = new Hospital();
                    int.TryParse(dr["ID"].ToString(), out id);
                    hospital.Id = id;
                    hospital.Name = dr["Name"].ToString();
                    hospital.NameArabic = dr["NameArabic"].ToString();
                    hospital.Code = dr["Code"].ToString();
                    int.TryParse(dr["IdRelatedStation"].ToString(), out idRelatedStation);
                    hospital.IdRelatedStation = idRelatedStation;
                    hospital.PhoneNumber1 = dr["PhoneNumber1"].ToString();
                    hospital.PhoneNumber2 = dr["PhoneNumber2"].ToString();
                    hospital.Location = dr["Location"].ToString();
                    hospital.Latitude = dr["Latitude"].ToString();
                    hospital.Longitude = dr["Longitude"].ToString();
                    int.TryParse(dr["Radius"].ToString(), out radius);
                    hospital.Radius = radius;

                    hospitals.Add(hospital);
                }
            }

            return hospitals;
        }

        public static List<NursingHome> GetAllNursingHomes()
        {
            int id, idRelatedStation;

            NursingHome nursingHome;
            List<NursingHome> nursingHomes = new List<NursingHome>();

            DataSet dsNursingHomes = OperationsDal.GetAllNursingHomes();
            if (dsNursingHomes.Tables.Count > 0 && dsNursingHomes.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsNursingHomes.Tables[0].Rows)
                {
                    nursingHome = new NursingHome();
                    int.TryParse(dr["ID"].ToString(), out id);
                    nursingHome.Id = id;
                    nursingHome.Name = dr["Name"].ToString();
                    int.TryParse(dr["IdRelatedStation"].ToString(), out idRelatedStation);
                    nursingHome.IdRelatedStation = idRelatedStation;
                    nursingHome.PhoneNumber = dr["PhoneNumber"].ToString();

                    nursingHomes.Add(nursingHome);
                }
            }

            return nursingHomes;
        }

        public static List<MissionStatus> GetMissionStatuses()
        {
            int id, code;

            MissionStatus missionStatus;
            List<MissionStatus> missionStatuses = new List<MissionStatus>();

            DataSet dsMissionStatuses = OperationsDal.GetAllMissionStatuses();
            if (dsMissionStatuses.Tables.Count > 0 && dsMissionStatuses.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsMissionStatuses.Tables[0].Rows)
                {
                    missionStatus = new MissionStatus();
                    int.TryParse(dr["ID"].ToString(), out id);
                    missionStatus.ID = id;
                    int.TryParse(dr["Code"].ToString(), out code);
                    missionStatus.Code = code;
                    missionStatus.Status = dr["Status"].ToString();
                    missionStatus.StatusArabic = dr["StatusArabic"].ToString();

                    missionStatuses.Add(missionStatus);
                }
            }
            return missionStatuses;
        }

        public static List<Mission> GetCurrentMissions()
        {
            DateTime scheduledTime, departureToCaseTime, arrivalToCaseTime, departureToDestinationTime, arrivalToDestinationTime,
                missionCompletedTime, returnToStationTime, createdDate, lastModifiedDate;
            int id, missionDurationInMinutes, idVehicle, initialMileage, finalMileage, traveledDistanceKm, idDriver,
                idRescuer1, idRescuer2, idRescuer3, idRescuer4, idMissionCategory, idMissionDirection, idFromArea,
                idFromHospital, idFromNursingHome, idToArea, idToHospital, idToNursingHome, patientYob, idPatientNationality,
                idCaseType, idCase, idCaseClassification, passengerYob, status;

            Mission currentMission;
            List<Mission> currentMissions = new List<Mission>();

            DataSet dsCurrentMissions = OperationsDal.GetCurrentMissions();
            if (dsCurrentMissions.Tables.Count > 0 && dsCurrentMissions.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsCurrentMissions.Tables[0].Rows)
                {
                    currentMission = new Mission();
                    int.TryParse(dr["ID"].ToString(), out id);
                    currentMission.ID = id;
                    DateTime.TryParse(dr["ScheduledTime"].ToString(), out scheduledTime);
                    currentMission.ScheduledTime = scheduledTime;
                    DateTime.TryParse(dr["DepartureToCaseTime"].ToString(), out departureToCaseTime);
                    currentMission.DepartureToCaseTime = departureToCaseTime;
                    DateTime.TryParse(dr["ArrivalToCaseTime"].ToString(), out arrivalToCaseTime);
                    currentMission.ArrivalToCaseTime = arrivalToCaseTime;
                    DateTime.TryParse(dr["DepartureToDestinationTime"].ToString(), out departureToDestinationTime);
                    currentMission.DepartureToDestinationTime = departureToDestinationTime;
                    DateTime.TryParse(dr["ArrivalToDestinationTime"].ToString(), out arrivalToDestinationTime);
                    currentMission.ArrivalToDestinationTime = arrivalToDestinationTime;
                    DateTime.TryParse(dr["MissionCompletedTime"].ToString(), out missionCompletedTime);
                    currentMission.MissionCompletedTime = missionCompletedTime;
                    DateTime.TryParse(dr["ReturnToStationTime"].ToString(), out returnToStationTime);
                    currentMission.ReturnToStationTime = returnToStationTime;
                    int.TryParse(dr["MissionDurationInMinutes"].ToString(), out missionDurationInMinutes);
                    currentMission.MissionDurationInMinutes = missionDurationInMinutes;
                    int.TryParse(dr["IdVehicle"].ToString(), out idVehicle);
                    currentMission.IdVehicle = idVehicle;
                    currentMission.VehicleNumber = dr["Number"].ToString();
                    int.TryParse(dr["InitialMileage"].ToString(), out initialMileage);
                    currentMission.InitialMileage = initialMileage;
                    int.TryParse(dr["FinalMileage"].ToString(), out finalMileage);
                    currentMission.FinalMileage = finalMileage;
                    int.TryParse(dr["TraveledDistanceInKm"].ToString(), out traveledDistanceKm);
                    currentMission.TraveledDistanceInKm = traveledDistanceKm;
                    int.TryParse(dr["IdDriver"].ToString(), out idDriver);
                    currentMission.IdDriver = idDriver;
                    int.TryParse(dr["IdRescuer1"].ToString(), out idRescuer1);
                    currentMission.IdRescuer1 = idRescuer1;
                    int.TryParse(dr["IdRescuer2"].ToString(), out idRescuer2);
                    currentMission.IdRescuer2 = idRescuer2;
                    int.TryParse(dr["IdRescuer3"].ToString(), out idRescuer3);
                    currentMission.IdRescuer3 = idRescuer3;
                    int.TryParse(dr["IdRescuer4"].ToString(), out idRescuer4);
                    currentMission.IdRescuer4 = idRescuer4;
                    int.TryParse(dr["IdMissionCategory"].ToString(), out idMissionCategory);
                    currentMission.IdMissionCategory = idMissionCategory;
                    int.TryParse(dr["IdMissionDirection"].ToString(), out idMissionDirection);
                    currentMission.IdMissionDirection = idMissionDirection;
                    int.TryParse(dr["IdFromArea"].ToString(), out idFromArea);
                    currentMission.IdFromArea = idFromArea;
                    int.TryParse(dr["IdFromHospital"].ToString(), out idFromHospital);
                    currentMission.IdFromHospital = idFromHospital;
                    int.TryParse(dr["IdFromNursingHome"].ToString(), out idFromNursingHome);
                    currentMission.IdFromNursingHome = idFromNursingHome;
                    int.TryParse(dr["IdToArea"].ToString(), out idToArea);
                    currentMission.IdToArea = idToArea;
                    int.TryParse(dr["IdToHospital"].ToString(), out idToHospital);
                    currentMission.IdToHospital = idToHospital;
                    int.TryParse(dr["IdToNursingHome"].ToString(), out idToNursingHome);
                    currentMission.IdToNursingHome = idToNursingHome;
                    currentMission.PatientFullName = dr["PatientName"].ToString();
                    int.TryParse(dr["PatientYob"].ToString(), out patientYob);
                    currentMission.PatientYob = patientYob;
                    int.TryParse(dr["IdPatientNationality"].ToString(), out idPatientNationality);
                    currentMission.IdPatientNationality = idPatientNationality;
                    int.TryParse(dr["IdCaseType"].ToString(), out idCaseType);
                    currentMission.IdCaseType = idCaseType;
                    int.TryParse(dr["IdCase"].ToString(), out idCase);
                    currentMission.IdCase = idCase;
                    int.TryParse(dr["IdCaseClassification"].ToString(), out idCaseClassification);
                    currentMission.IdCaseClassification = idCaseClassification;
                    currentMission.CaseDescription = dr["CaseDescription"].ToString();
                    currentMission.PassengerFullName = dr["PassengerName"].ToString();
                    int.TryParse(dr["PassengerYob"].ToString(), out passengerYob);
                    currentMission.PassengerYob = passengerYob;
                    currentMission.Notes = dr["Notes"].ToString();
                    int.TryParse(dr["Status"].ToString(), out status);
                    currentMission.Status = status;
                    currentMission.CreatedBy = dr["CreatedBy"].ToString();
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out createdDate);
                    currentMission.CreatedDate = createdDate;
                    DateTime.TryParse(dr["LastModifiedDate"].ToString(), out lastModifiedDate);
                    currentMission.LastModifiedDate = lastModifiedDate;


                    currentMissions.Add(currentMission);
                }
            }
            return currentMissions;
        }

        public static List<Mission> GetDayMissions()
        {
            DateTime scheduledTime, departureToCaseTime, arrivalToCaseTime, departureToDestinationTime, arrivalToDestinationTime,
                missionCompletedTime, returnToStationTime, createdDate, lastModifiedDate;
            int id, missionDurationInMinutes, idVehicle, initialMileage, finalMileage, traveledDistanceKm, idDriver,
                idRescuer1, idRescuer2, idRescuer3, idRescuer4, idMissionCategory, idMissionDirection, idFromArea,
                idFromHospital, idFromNursingHome, idToArea, idToHospital, idToNursingHome, patientYob, idPatientNationality,
                idCaseType, idCase, idCaseClassification, passengerYob, status;

            Mission dayMission;
            List<Mission> dayMissions = new List<Mission>();

            DataSet dsDayMissions = OperationsDal.GetDayMissions();
            if (dsDayMissions.Tables.Count > 0 && dsDayMissions.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsDayMissions.Tables[0].Rows)
                {
                    dayMission = new Mission();
                    int.TryParse(dr["ID"].ToString(), out id);
                    dayMission.ID = id;
                    DateTime.TryParse(dr["ScheduledTime"].ToString(), out scheduledTime);
                    dayMission.ScheduledTime = scheduledTime;
                    DateTime.TryParse(dr["DepartureToCaseTime"].ToString(), out departureToCaseTime);
                    dayMission.DepartureToCaseTime = departureToCaseTime;
                    DateTime.TryParse(dr["ArrivalToCaseTime"].ToString(), out arrivalToCaseTime);
                    dayMission.ArrivalToCaseTime = arrivalToCaseTime;
                    DateTime.TryParse(dr["DepartureToDestinationTime"].ToString(), out departureToDestinationTime);
                    dayMission.DepartureToDestinationTime = departureToDestinationTime;
                    DateTime.TryParse(dr["ArrivalToDestinationTime"].ToString(), out arrivalToDestinationTime);
                    dayMission.ArrivalToDestinationTime = arrivalToDestinationTime;
                    DateTime.TryParse(dr["MissionCompletedTime"].ToString(), out missionCompletedTime);
                    dayMission.MissionCompletedTime = missionCompletedTime;
                    DateTime.TryParse(dr["ReturnToStationTime"].ToString(), out returnToStationTime);
                    dayMission.ReturnToStationTime = returnToStationTime;
                    int.TryParse(dr["MissionDurationInMinutes"].ToString(), out missionDurationInMinutes);
                    dayMission.MissionDurationInMinutes = missionDurationInMinutes;
                    int.TryParse(dr["IdVehicle"].ToString(), out idVehicle);
                    dayMission.IdVehicle = idVehicle;
                    dayMission.VehicleNumber = dr["VehicleNumber"].ToString();
                    int.TryParse(dr["InitialMileage"].ToString(), out initialMileage);
                    dayMission.InitialMileage = initialMileage;
                    int.TryParse(dr["FinalMileage"].ToString(), out finalMileage);
                    dayMission.FinalMileage = finalMileage;
                    int.TryParse(dr["TraveledDistanceInKm"].ToString(), out traveledDistanceKm);
                    dayMission.TraveledDistanceInKm = traveledDistanceKm;
                    int.TryParse(dr["IdDriver"].ToString(), out idDriver);
                    dayMission.IdDriver = idDriver;
                    dayMission.DriverName = dr["DriverNickName"].ToString();
                    int.TryParse(dr["IdRescuer1"].ToString(), out idRescuer1);
                    dayMission.IdRescuer1 = idRescuer1;
                    dayMission.Rescuer1Name = dr["Rescuer1NickName"].ToString();
                    int.TryParse(dr["IdRescuer2"].ToString(), out idRescuer2);
                    dayMission.IdRescuer2 = idRescuer2;
                    dayMission.Rescuer2Name = dr["Rescuer2NickName"].ToString();
                    int.TryParse(dr["IdRescuer3"].ToString(), out idRescuer3);
                    dayMission.IdRescuer3 = idRescuer3;
                    dayMission.Rescuer3Name = dr["Rescuer3NickName"].ToString();
                    int.TryParse(dr["IdRescuer4"].ToString(), out idRescuer4);
                    dayMission.IdRescuer4 = idRescuer4;
                    dayMission.Rescuer4Name = dr["Rescuer4NickName"].ToString();
                    int.TryParse(dr["IdMissionCategory"].ToString(), out idMissionCategory);
                    dayMission.IdMissionCategory = idMissionCategory;
                    dayMission.MissionCategoryValue = dr["MissionCategoryDescription"].ToString();
                    int.TryParse(dr["IdMissionDirection"].ToString(), out idMissionDirection);
                    dayMission.IdMissionDirection = idMissionDirection;
                    dayMission.MissionDirectionValue = dr["MissionDirectionDescription"].ToString();
                    int.TryParse(dr["IdFromArea"].ToString(), out idFromArea);
                    dayMission.IdFromArea = idFromArea;
                    dayMission.FromArea = dr["FromArea"].ToString();
                    int.TryParse(dr["IdFromHospital"].ToString(), out idFromHospital);
                    dayMission.IdFromHospital = idFromHospital;
                    dayMission.FromHospital = dr["FromHospital"].ToString();
                    int.TryParse(dr["IdFromNursingHome"].ToString(), out idFromNursingHome);
                    dayMission.IdFromNursingHome = idFromNursingHome;
                    dayMission.FromNursingHome = dr["FromNursingHome"].ToString();
                    int.TryParse(dr["IdToArea"].ToString(), out idToArea);
                    dayMission.IdToArea = idToArea;
                    dayMission.ToArea = dr["ToArea"].ToString();
                    int.TryParse(dr["IdToHospital"].ToString(), out idToHospital);
                    dayMission.IdToHospital = idToHospital;
                    dayMission.ToHospital = dr["ToHospital"].ToString();
                    int.TryParse(dr["IdToNursingHome"].ToString(), out idToNursingHome);
                    dayMission.IdToNursingHome = idToNursingHome;
                    dayMission.ToNursingHome = dr["ToNursingHome"].ToString();
                    dayMission.PatientFullName = dr["PatientName"].ToString();
                    int.TryParse(dr["PatientYob"].ToString(), out patientYob);
                    dayMission.PatientYob = patientYob;
                    int.TryParse(dr["IdPatientNationality"].ToString(), out idPatientNationality);
                    dayMission.IdPatientNationality = idPatientNationality;
                    dayMission.PatientNationality = dr["Nationality"].ToString();
                    int.TryParse(dr["IdCaseType"].ToString(), out idCaseType);
                    dayMission.IdCaseType = idCaseType;
                    int.TryParse(dr["IdCase"].ToString(), out idCase);
                    dayMission.IdCase = idCase;
                    dayMission.Case = dr["Case"].ToString();
                    int.TryParse(dr["IdCaseClassification"].ToString(), out idCaseClassification);
                    dayMission.IdCaseClassification = idCaseClassification;
                    dayMission.CaseClassification = dr["CaseClassification"].ToString();
                    dayMission.CaseDescription = dr["CaseDescription"].ToString();
                    dayMission.PassengerFullName = dr["PassengerName"].ToString();
                    int.TryParse(dr["PassengerYob"].ToString(), out passengerYob);
                    dayMission.PassengerYob = passengerYob;
                    dayMission.Notes = dr["Notes"].ToString();
                    int.TryParse(dr["Status"].ToString(), out status);
                    dayMission.Status = status;
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out createdDate);
                    dayMission.CreatedDate = createdDate;


                    dayMissions.Add(dayMission);
                }
            }
            return dayMissions;
        }

        public static List<Mission> GetDayMissions(DateTime DateFrom, DateTime DateTo)
        {
            DateTime scheduledTime, departureToCaseTime, arrivalToCaseTime, departureToDestinationTime, arrivalToDestinationTime,
                missionCompletedTime, returnToStationTime, createdDate;
            int id, idVehicle, initialMileage, finalMileage, traveledDistanceKm, idDriver,
                idRescuer1, idRescuer2, idRescuer3, idRescuer4, idMissionCategory, idMissionDirection, idFromArea,
                idFromHospital, idFromNursingHome, idToArea, idToHospital, idToNursingHome, patientYob, idPatientNationality,
                idCaseType, idCase, idCaseClassification, passengerYob, status;
            double missionDurationInMinutes;

            Mission dayMission;
            List<Mission> dayMissions = new List<Mission>();

            DataSet dsDayMissions = OperationsDal.GetDayMissions(DateFrom, DateTo);
            if (dsDayMissions.Tables.Count > 0 && dsDayMissions.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsDayMissions.Tables[0].Rows)
                {
                    dayMission = new Mission();
                    int.TryParse(dr["ID"].ToString(), out id);
                    dayMission.ID = id;
                    DateTime.TryParse(dr["ScheduledTime"].ToString(), out scheduledTime);
                    dayMission.ScheduledTime = scheduledTime;
                    DateTime.TryParse(dr["DepartureToCaseTime"].ToString(), out departureToCaseTime);
                    dayMission.DepartureToCaseTime = departureToCaseTime;
                    DateTime.TryParse(dr["ArrivalToCaseTime"].ToString(), out arrivalToCaseTime);
                    dayMission.ArrivalToCaseTime = arrivalToCaseTime;
                    DateTime.TryParse(dr["DepartureToDestinationTime"].ToString(), out departureToDestinationTime);
                    dayMission.DepartureToDestinationTime = departureToDestinationTime;
                    DateTime.TryParse(dr["ArrivalToDestinationTime"].ToString(), out arrivalToDestinationTime);
                    dayMission.ArrivalToDestinationTime = arrivalToDestinationTime;
                    DateTime.TryParse(dr["MissionCompletedTime"].ToString(), out missionCompletedTime);
                    dayMission.MissionCompletedTime = missionCompletedTime;
                    DateTime.TryParse(dr["ReturnToStationTime"].ToString(), out returnToStationTime);
                    dayMission.ReturnToStationTime = returnToStationTime;
                    double.TryParse(dr["MissionDurationInMinutes"].ToString(), out missionDurationInMinutes);
                    dayMission.MissionDurationInMinutes = missionDurationInMinutes;
                    int.TryParse(dr["IdVehicle"].ToString(), out idVehicle);
                    dayMission.IdVehicle = idVehicle;
                    dayMission.VehicleNumber = dr["VehicleNumber"].ToString();
                    int.TryParse(dr["InitialMileage"].ToString(), out initialMileage);
                    dayMission.InitialMileage = initialMileage;
                    int.TryParse(dr["FinalMileage"].ToString(), out finalMileage);
                    dayMission.FinalMileage = finalMileage;
                    int.TryParse(dr["TraveledDistanceInKm"].ToString(), out traveledDistanceKm);
                    dayMission.TraveledDistanceInKm = traveledDistanceKm;
                    int.TryParse(dr["IdDriver"].ToString(), out idDriver);
                    dayMission.IdDriver = idDriver;
                    dayMission.DriverName = dr["DriverNickName"].ToString();
                    int.TryParse(dr["IdRescuer1"].ToString(), out idRescuer1);
                    dayMission.IdRescuer1 = idRescuer1;
                    dayMission.Rescuer1Name = dr["Rescuer1NickName"].ToString();
                    int.TryParse(dr["IdRescuer2"].ToString(), out idRescuer2);
                    dayMission.IdRescuer2 = idRescuer2;
                    dayMission.Rescuer2Name = dr["Rescuer2NickName"].ToString();
                    int.TryParse(dr["IdRescuer3"].ToString(), out idRescuer3);
                    dayMission.IdRescuer3 = idRescuer3;
                    dayMission.Rescuer3Name = dr["Rescuer3NickName"].ToString();
                    int.TryParse(dr["IdRescuer4"].ToString(), out idRescuer4);
                    dayMission.IdRescuer4 = idRescuer4;
                    dayMission.Rescuer4Name = dr["Rescuer4NickName"].ToString();
                    int.TryParse(dr["IdMissionCategory"].ToString(), out idMissionCategory);
                    dayMission.IdMissionCategory = idMissionCategory;
                    dayMission.MissionCategoryValue = dr["MissionCategoryDescription"].ToString();
                    int.TryParse(dr["IdMissionDirection"].ToString(), out idMissionDirection);
                    dayMission.IdMissionDirection = idMissionDirection;
                    dayMission.MissionDirectionValue = dr["MissionDirectionDescription"].ToString();
                    int.TryParse(dr["IdFromArea"].ToString(), out idFromArea);
                    dayMission.IdFromArea = idFromArea;
                    dayMission.FromArea = dr["FromArea"].ToString();
                    int.TryParse(dr["IdFromHospital"].ToString(), out idFromHospital);
                    dayMission.IdFromHospital = idFromHospital;
                    dayMission.FromHospital = dr["FromHospital"].ToString();
                    int.TryParse(dr["IdFromNursingHome"].ToString(), out idFromNursingHome);
                    dayMission.IdFromNursingHome = idFromNursingHome;
                    dayMission.FromNursingHome = dr["FromNursingHome"].ToString();
                    int.TryParse(dr["IdToArea"].ToString(), out idToArea);
                    dayMission.IdToArea = idToArea;
                    dayMission.ToArea = dr["ToArea"].ToString();
                    int.TryParse(dr["IdToHospital"].ToString(), out idToHospital);
                    dayMission.IdToHospital = idToHospital;
                    dayMission.ToHospital = dr["ToHospital"].ToString();
                    int.TryParse(dr["IdToNursingHome"].ToString(), out idToNursingHome);
                    dayMission.IdToNursingHome = idToNursingHome;
                    dayMission.ToNursingHome = dr["ToNursingHome"].ToString();
                    dayMission.PatientFullName = dr["PatientName"].ToString();
                    int.TryParse(dr["PatientYob"].ToString(), out patientYob);
                    dayMission.PatientYob = patientYob;
                    int.TryParse(dr["IdPatientNationality"].ToString(), out idPatientNationality);
                    dayMission.IdPatientNationality = idPatientNationality;
                    dayMission.PatientNationality = dr["Nationality"].ToString();
                    int.TryParse(dr["IdCaseType"].ToString(), out idCaseType);
                    dayMission.IdCaseType = idCaseType;
                    int.TryParse(dr["IdCase"].ToString(), out idCase);
                    dayMission.IdCase = idCase;
                    dayMission.Case = dr["Case"].ToString();
                    int.TryParse(dr["IdCaseClassification"].ToString(), out idCaseClassification);
                    dayMission.IdCaseClassification = idCaseClassification;
                    dayMission.CaseClassification = dr["CaseClassification"].ToString();
                    dayMission.CaseDescription = dr["CaseDescription"].ToString();
                    dayMission.PassengerFullName = dr["PassengerName"].ToString();
                    int.TryParse(dr["PassengerYob"].ToString(), out passengerYob);
                    dayMission.PassengerYob = passengerYob;
                    dayMission.Notes = dr["Notes"].ToString();
                    int.TryParse(dr["Status"].ToString(), out status);
                    dayMission.Status = status;
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out createdDate);
                    dayMission.CreatedDate = createdDate;


                    dayMissions.Add(dayMission);
                }
            }
            return dayMissions;
        }

        public static Mission GetSpecificMission(int IdMission)
        {
            DateTime scheduledTime, departureToCaseTime, arrivalToCaseTime, departureToDestinationTime, arrivalToDestinationTime,
                missionCompletedTime, returnToStationTime, createdDate;
            int id, missionDurationInMinutes, idVehicle, initialMileage, finalMileage, traveledDistanceKm, idDriver,
                idRescuer1, idRescuer2, idRescuer3, idRescuer4, idMissionCategory, idMissionDirection, idFromArea,
                idFromHospital, idFromNursingHome, idToArea, idToHospital, idToNursingHome, patientYob, idPatientNationality,
                idCaseType, idCase, idCaseClassification, passengerYob, status, numberOfInjured;

            Mission specificMission = null;

            DataSet dsSpecificMission = OperationsDal.GetSpecificMission(IdMission);
            if (dsSpecificMission.Tables.Count > 0 && dsSpecificMission.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsSpecificMission.Tables[0].Rows[0];
                specificMission = new Mission();

                int.TryParse(dr["ID"].ToString(), out id);
                specificMission.ID = id;
                DateTime.TryParse(dr["ScheduledTime"].ToString(), out scheduledTime);
                specificMission.ScheduledTime = scheduledTime;
                DateTime.TryParse(dr["DepartureToCaseTime"].ToString(), out departureToCaseTime);
                specificMission.DepartureToCaseTime = departureToCaseTime;
                DateTime.TryParse(dr["ArrivalToCaseTime"].ToString(), out arrivalToCaseTime);
                specificMission.ArrivalToCaseTime = arrivalToCaseTime;
                DateTime.TryParse(dr["DepartureToDestinationTime"].ToString(), out departureToDestinationTime);
                specificMission.DepartureToDestinationTime = departureToDestinationTime;
                DateTime.TryParse(dr["ArrivalToDestinationTime"].ToString(), out arrivalToDestinationTime);
                specificMission.ArrivalToDestinationTime = arrivalToDestinationTime;
                DateTime.TryParse(dr["MissionCompletedTime"].ToString(), out missionCompletedTime);
                specificMission.MissionCompletedTime = missionCompletedTime;
                DateTime.TryParse(dr["ReturnToStationTime"].ToString(), out returnToStationTime);
                specificMission.ReturnToStationTime = returnToStationTime;
                int.TryParse(dr["IdVehicle"].ToString(), out idVehicle);
                specificMission.IdVehicle = idVehicle;
                specificMission.VehicleNumber = dr["VehicleNumber"].ToString();
                int.TryParse(dr["InitialMileage"].ToString(), out initialMileage);
                specificMission.InitialMileage = initialMileage;
                int.TryParse(dr["FinalMileage"].ToString(), out finalMileage);
                specificMission.FinalMileage = finalMileage;
                int.TryParse(dr["TraveledDistanceInKm"].ToString(), out traveledDistanceKm);
                specificMission.TraveledDistanceInKm = traveledDistanceKm;
                int.TryParse(dr["IdDriver"].ToString(), out idDriver);
                specificMission.IdDriver = idDriver;
                specificMission.DriverName = dr["DriverNickName"].ToString();
                int.TryParse(dr["IdRescuer1"].ToString(), out idRescuer1);
                specificMission.IdRescuer1 = idRescuer1;
                specificMission.Rescuer1Name = dr["Rescuer1NickName"].ToString();
                int.TryParse(dr["IdRescuer2"].ToString(), out idRescuer2);
                specificMission.IdRescuer2 = idRescuer2;
                specificMission.Rescuer2Name = dr["Rescuer2NickName"].ToString();
                int.TryParse(dr["IdRescuer3"].ToString(), out idRescuer3);
                specificMission.IdRescuer3 = idRescuer3;
                specificMission.Rescuer3Name = dr["Rescuer3NickName"].ToString();
                int.TryParse(dr["IdRescuer4"].ToString(), out idRescuer4);
                specificMission.IdRescuer4 = idRescuer4;
                specificMission.Rescuer4Name = dr["Rescuer4NickName"].ToString();
                int.TryParse(dr["IdMissionCategory"].ToString(), out idMissionCategory);
                specificMission.IdMissionCategory = idMissionCategory;
                specificMission.MissionCategoryValue = dr["MissionCategoryDescription"].ToString();
                int.TryParse(dr["IdMissionDirection"].ToString(), out idMissionDirection);
                specificMission.IdMissionDirection = idMissionDirection;
                specificMission.MissionDirectionValue = dr["MissionDirectionDescription"].ToString();
                int.TryParse(dr["IdFromArea"].ToString(), out idFromArea);
                specificMission.IdFromArea = idFromArea;
                specificMission.FromArea = dr["FromArea"].ToString();
                int.TryParse(dr["IdFromHospital"].ToString(), out idFromHospital);
                specificMission.IdFromHospital = idFromHospital;
                specificMission.FromHospital = dr["FromHospital"].ToString();
                int.TryParse(dr["IdFromNursingHome"].ToString(), out idFromNursingHome);
                specificMission.IdFromNursingHome = idFromNursingHome;
                specificMission.FromNursingHome = dr["FromNursingHome"].ToString();
                int.TryParse(dr["IdToArea"].ToString(), out idToArea);
                specificMission.IdToArea = idToArea;
                specificMission.ToArea = dr["ToArea"].ToString();
                int.TryParse(dr["IdToHospital"].ToString(), out idToHospital);
                specificMission.IdToHospital = idToHospital;
                specificMission.ToHospital = dr["ToHospital"].ToString();
                int.TryParse(dr["IdToNursingHome"].ToString(), out idToNursingHome);
                specificMission.IdToNursingHome = idToNursingHome;
                specificMission.ToNursingHome = dr["ToNursingHome"].ToString();
                specificMission.PatientFullName = dr["PatientName"].ToString();
                int.TryParse(dr["PatientYob"].ToString(), out patientYob);
                specificMission.PatientYob = patientYob;
                int.TryParse(dr["IdPatientNationality"].ToString(), out idPatientNationality);
                specificMission.IdPatientNationality = idPatientNationality;
                specificMission.PatientNationality = dr["Nationality"].ToString();
                int.TryParse(dr["IdCaseType"].ToString(), out idCaseType);
                specificMission.IdCaseType = idCaseType;
                int.TryParse(dr["IdCase"].ToString(), out idCase);
                specificMission.IdCase = idCase;
                specificMission.Case = dr["Case"].ToString();
                int.TryParse(dr["IdCaseClassification"].ToString(), out idCaseClassification);
                specificMission.IdCaseClassification = idCaseClassification;
                specificMission.CaseClassification = dr["CaseClassification"].ToString();
                specificMission.CaseDescription = dr["CaseDescription"].ToString();
                specificMission.PassengerFullName = dr["PassengerName"].ToString();
                int.TryParse(dr["PassengerYob"].ToString(), out passengerYob);
                specificMission.PassengerYob = passengerYob;
                specificMission.Notes = dr["Notes"].ToString();
                int.TryParse(dr["Status"].ToString(), out status);
                specificMission.Status = status;
                DateTime.TryParse(dr["CreatedDate"].ToString(), out createdDate);
                specificMission.CreatedDate = createdDate;
                int.TryParse(dr["NumberOfInjuries"].ToString(), out numberOfInjured);
                specificMission.NumberOfInjuries = numberOfInjured;
            }
            return specificMission;
        }

        public static void AddNewMission(int idVehicle, int status, DateTime scheduledDatetime)
        {
            int newId = OperationsDal.AddMission(idVehicle, status, scheduledDatetime);
        }

        public static void AddNewMission(int idVehicle, int status, int IdMissionCategory, int IdMissionDirection, int FromDirectionFlag, int IdFrom, DateTime scheduledDatetime)
        {
            int newId = OperationsDal.AddMission(idVehicle, status, IdMissionCategory, IdMissionDirection, FromDirectionFlag, IdFrom, scheduledDatetime);
        }

        public static void UpdateMission(Mission SelectedMission)
        {
            OperationsDal.UpdateMission(SelectedMission);
        }

        public static void UpdateNumberOfInjured(int MissionId, int NumberOfInjured)
        {
            OperationsDal.UpdateNumberOfInjured(MissionId, NumberOfInjured);
        }

        public static void MoveVehicleToNextLocation(Mission CurrentMission, int Status)
        {
            OperationsDal.UpdateVehicleLocation(CurrentMission.ID, Status);
        }

        public static void UpdateVehicleLastMileage(Mission currentMission)
        {
            OperationsDal.UpdateVehicleLastMileage(currentMission.IdVehicle, currentMission.FinalMileage);
        }

        public static List<Rescuer> GetAllTeamLeaders()
        {
            Rescuer teamLeader;
            List<Rescuer> teamLeaders = new List<Rescuer>();

            int id;

            DataSet dsTeamLeaders = OperationsDal.GetAllTeamLeaders();
            if (dsTeamLeaders.Tables.Count > 0 && dsTeamLeaders.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsTeamLeaders.Tables[0].Rows)
                {
                    teamLeader = new Rescuer();
                    int.TryParse(dr["IdRescuerTeamLeader"].ToString(), out id);
                    teamLeader.Id = id;
                    teamLeader.Name = dr["TeamLeaderName"].ToString();

                    teamLeaders.Add(teamLeader);
                }
            }
            return teamLeaders;
        }

        public static ShiftReport GetSpecificShiftReport(DateTime ShiftDateFrom, DateTime ShiftDateTo)
        {
            int id, numberOfRescuers, numberOfTeams, idTeamLeader, soinAuCentre;
            DateTime shiftDate;
            bool damaged476, damaged477, damaged478, damaged479, damaged480, damaged443;

            ShiftReport specificReport = null;

            DataSet dsSpecificReport = OperationsDal.GetSpecificShiftReport(ShiftDateFrom, ShiftDateTo);
            if (dsSpecificReport.Tables.Count > 0 && dsSpecificReport.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsSpecificReport.Tables[0].Rows[0];
                specificReport = new ShiftReport();

                int.TryParse(dr["ID"].ToString(), out id);
                specificReport.Id = id;
                DateTime.TryParse(dr["ShiftDate"].ToString(), out shiftDate);
                specificReport.ShiftDate = shiftDate;
                bool.TryParse(dr["Damaged476"].ToString(), out damaged476);
                specificReport.IsDamaged476 = damaged476;
                bool.TryParse(dr["Damaged477"].ToString(), out damaged477);
                specificReport.IsDamaged477 = damaged477;
                bool.TryParse(dr["Damaged478"].ToString(), out damaged478);
                specificReport.IsDamaged478 = damaged478;
                bool.TryParse(dr["Damaged479"].ToString(), out damaged479);
                specificReport.IsDamaged479 = damaged479;
                bool.TryParse(dr["Damaged480"].ToString(), out damaged480);
                specificReport.IsDamaged480 = damaged480;
                bool.TryParse(dr["Damaged443"].ToString(), out damaged443);
                specificReport.IsDamaged443 = damaged443;
                int.TryParse(dr["SoinAuCentre"].ToString(), out soinAuCentre);
                specificReport.SoinAuCentre = soinAuCentre;
                int.TryParse(dr["NumberOfRescuers"].ToString(), out numberOfRescuers);
                specificReport.NumberOfRescuers = numberOfRescuers;
                int.TryParse(dr["NumberOfTeams"].ToString(), out numberOfTeams);
                specificReport.NumberOfTeams = numberOfTeams;
                int.TryParse(dr["IdTeamLeader"].ToString(), out idTeamLeader);
                specificReport.IdTeamLeader = idTeamLeader;
                specificReport.Notes = dr["Notes"].ToString();
            }
            return specificReport;
        }

        public static void AddOrUpdateShiftReport(ShiftReport shiftReport)
        {
            OperationsDal.AddOrUpdateShiftReport(shiftReport);
        }

        public static List<ShiftReport> GetDailyMissionReport(DateTime from, DateTime to)
        {
            List<ShiftReport> dailyMissions = new List<ShiftReport>();
            ShiftReport dailyMission;
            int numberOfMissions;

            DataSet dsDailyMissionReport = OperationsDal.GetDailyMissionReport(from, to);
            if (dsDailyMissionReport.Tables.Count > 0 && dsDailyMissionReport.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsDailyMissionReport.Tables[0].Rows)
                {
                    dailyMission = new ShiftReport();
                    dailyMission.MissionClassification = dr["Mission_Classification"].ToString();
                    int.TryParse(dr["Number_of_missions"].ToString(), out numberOfMissions);
                    dailyMission.MissionClassificationOccurence = numberOfMissions;

                    dailyMissions.Add(dailyMission);
                }
            }

            return dailyMissions;
        }

        public static void DeleteMission(int idMission)
        {
            OperationsDal.DeleteMission(idMission);
        }

        public static List<Station> GetAllStations()
        {
            Station station;
            List<Station> stations = new List<Station>();

            int id;

            DataSet dsStations = OperationsDal.GetAllStations();
            if (dsStations.Tables.Count > 0 && dsStations.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsStations.Tables[0].Rows)
                {
                    station = new Station();
                    int.TryParse(dr["ID"].ToString(), out id);
                    station.ID = id;
                    station.Name = dr["Name"].ToString();
                    station.Code = dr["Code"].ToString();
                    station.PhoneNumber = dr["PhoneNumber"].ToString();

                    stations.Add(station);
                }
            }
            return stations;
        }
        
        public static List<BtsCenter> GetAllBtsCenters()
        {
            BtsCenter btsCenter;
            List<BtsCenter> btsCenters = new List<BtsCenter>();

            int id;

            DataSet dsBtsCenters = OperationsDal.GetAllBtsCenters();
            if (dsBtsCenters.Tables.Count > 0 && dsBtsCenters.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsBtsCenters.Tables[0].Rows)
                {
                    btsCenter = new BtsCenter();
                    int.TryParse(dr["ID"].ToString(), out id);
                    btsCenter.ID = id;
                    btsCenter.Name = dr["Name"].ToString();
                    btsCenter.Code = dr["Code"].ToString();
                    btsCenter.PhoneNumber = dr["PhoneNumber"].ToString();
                    btsCenter.Website = dr["Website"].ToString();

                    btsCenters.Add(btsCenter);
                }
            }
            return btsCenters;
        }
    }
}
