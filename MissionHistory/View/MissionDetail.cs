using MissionHistory.BusinessLogicLayer;
using MissionHistory.Helper;
using MissionHistory.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MissionHistory.Helper.Enumeration;

namespace MissionHistory.View
{
    public partial class MissionDetail : Form
    {
        #region Constructors
        public MissionDetail()
        {
            InitializeComponent();
            FillDdlVehicles();
            FillDdlNationality();
            FillDdlRescuers();
            FillDdlDriver();
            FillDdlVehicleLocation();
            FillDdlCaseType();
            FillDdlMissionCategory();
        }

        public MissionDetail(int IdMission, bool IsCurrent, bool IsVehicleInLastLocationBeforeMissionClosing)
        {
            //This constructor is called when user double clicks on a row in grdCurrentMissions or in grdDayMissions, IsCurrent points to current missions while true,
            //IsLastLocationBeforeMissionClosing comes when user updates the vehicle location and reaches the end of the mission(needs to fill all data before moving mission to grdDayMissions)
            this.IdMission = IdMission;
            this.IsCurrent = IsCurrent; //Is current is true when the mission is not complete
            this.IsVehicleInLastLocationBeforeMissionClosing = IsVehicleInLastLocationBeforeMissionClosing;

            InitializeComponent();
            FillDdlVehicles();
            FillDdlNationality();
            FillDdlRescuers();
            FillDdlDriver();
            FillDdlVehicleLocation();
            FillDdlCaseType();
            FillDdlMissionCategory();
            GetMissionValues();
        }
        #endregion

        #region Properties
        public int IdMission { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsVehicleInLastLocationBeforeMissionClosing { get; set; }
        #endregion

        #region Global Variables
        List<ComboBoxItem> _Items;
        List<Vehicle> _Vehicles;
        List<Nationality> _Nationalities;
        List<Rescuer> _Drivers;
        List<Rescuer> _Rescuers;
        List<CaseType> _CaseTypes;
        List<CaseClassification> _CaseClassifications;
        List<Case> _Cases;
        List<MissionCategory> _MissionCategories;
        List<MissionDirection> _MissionDirections;
        List<Area> _Areas;
        List<Hospital> _Hospitals;
        List<NursingHome> _NursingHomes;
        List<MissionStatus> _MissionStatuses;
        Mission _SelectedMission;
        int _NumberOfInjuries;
        #endregion

        private void GetMissionValues()
        {
            if (this.IdMission > 0)
            {
                _SelectedMission = OperationsBlo.GetSpecificMission(IdMission);
                if (_SelectedMission != null)
                {
                    if (_SelectedMission.IdVehicle > 0)
                        ddlVehicles.SelectedValue = _SelectedMission.IdVehicle;

                    if (_SelectedMission.FinalMileage > 0)
                        txtFinalMileage.Text = _SelectedMission.FinalMileage.ToString();

                    if (_SelectedMission.IdDriver > 0)
                        ddlDriver.SelectedValue = _SelectedMission.IdDriver;

                    if (_SelectedMission.IdRescuer1 > 0)
                        ddlRescuer1.SelectedValue = _SelectedMission.IdRescuer1;

                    if (_SelectedMission.IdRescuer2 > 0)
                        ddlRescuer2.SelectedValue = _SelectedMission.IdRescuer2;

                    if (_SelectedMission.IdRescuer3 > 0)
                        ddlRescuer3.SelectedValue = _SelectedMission.IdRescuer3;

                    if (_SelectedMission.IdRescuer4 > 0)
                        ddlRescuer4.SelectedValue = _SelectedMission.IdRescuer4;

                    if (_SelectedMission.IdMissionCategory > 0)
                        ddlMissionCategory.SelectedValue = _SelectedMission.IdMissionCategory;

                    if (_SelectedMission.IdMissionCategory == 3)
                    {
                        lblTo.Visible = false;
                        ddlTo.Visible = false;
                    }
                    else
                    {
                        lblTo.Visible = true;
                        ddlTo.Visible = true;
                    }

                    if (_SelectedMission.IdMissionDirection > 0)
                        ddlMissionDirection.SelectedValue = _SelectedMission.IdMissionDirection;

                    FillFromAndToDdlAccordingToDirectionFlag(_SelectedMission.IdMissionDirection);

                    ddlFrom.SelectedValue = GetFromAndToId(_SelectedMission, true);
                    ddlTo.SelectedValue = GetFromAndToId(_SelectedMission, false);

                    txtNotes.Text = _SelectedMission.Notes;
                    txtPatientName.Text = _SelectedMission.PatientFullName;

                    if (_SelectedMission.PatientYob != 0)
                        txtPatientAge.Text = Math.Ceiling((double)DateTime.Today.Year - (double)_SelectedMission.PatientYob).ToString();

                    if (_SelectedMission.IdPatientNationality > 0)
                        ddlNationality.SelectedValue = _SelectedMission.IdPatientNationality;

                    if (_SelectedMission.IdCaseType > 0)
                        ddlCaseType.SelectedValue = _SelectedMission.IdCaseType;

                    if (_SelectedMission.IdCase > 0)
                        ddlCase.SelectedValue = _SelectedMission.IdCase;

                    if (_SelectedMission.IdCaseClassification > 0)
                        ddlCaseClassification.SelectedValue = _SelectedMission.IdCaseClassification;

                    txtCaseDescription.Text = _SelectedMission.CaseDescription;
                    txtPassengerName.Text = _SelectedMission.PassengerFullName;

                    if (_SelectedMission.PassengerYob != 0)
                        txtPassengerAge.Text = Math.Ceiling((double)DateTime.Today.Year - (double)_SelectedMission.PassengerYob).ToString();

                    if (_SelectedMission.Status > 0)
                        ddlVehicleLocation.SelectedValue = _SelectedMission.Status;

                    if (_SelectedMission.DepartureToCaseTime.Value.Year != 1)
                        dtDepartureToCase.Value = _SelectedMission.DepartureToCaseTime.Value.Date;

                    if (_SelectedMission.DepartureToCaseTime.Value.Year != 1)
                        timeDepartureToCase.Value = _SelectedMission.DepartureToCaseTime.Value;

                    if (_SelectedMission.ArrivalToCaseTime.Value.Year != 1)
                        dtArrivalToCase.Value = _SelectedMission.ArrivalToCaseTime.Value.Date;

                    if (_SelectedMission.ArrivalToCaseTime.Value.Year != 1)
                        timeArrivalToCase.Value = _SelectedMission.ArrivalToCaseTime.Value;

                    if (_SelectedMission.DepartureToDestinationTime.Value.Year != 1)
                        dtDepartureToDestination.Value = _SelectedMission.DepartureToDestinationTime.Value.Date;

                    if (_SelectedMission.DepartureToDestinationTime.Value.Year != 1)
                        timeDepartureToDestination.Value = _SelectedMission.DepartureToDestinationTime.Value;

                    if (_SelectedMission.ArrivalToDestinationTime.Value.Year != 1)
                        dtArrivalToDestination.Value = _SelectedMission.ArrivalToDestinationTime.Value.Date;

                    if (_SelectedMission.ArrivalToDestinationTime.Value.Year != 1)
                        timeArrivalToDestination.Value = _SelectedMission.ArrivalToDestinationTime.Value;

                    if (_SelectedMission.MissionCompletedTime.Value.Year != 1)
                        dtDepartureToCenter.Value = _SelectedMission.MissionCompletedTime.Value.Date;

                    if (_SelectedMission.MissionCompletedTime.Value.Year != 1)
                        timeDepartureToCenter.Value = _SelectedMission.MissionCompletedTime.Value;

                    if (_SelectedMission.ReturnToStationTime.Value.Year != 1)
                        dtArrivalToCenter.Value = _SelectedMission.ReturnToStationTime.Value.Date;

                    if (_SelectedMission.ReturnToStationTime.Value.Year != 1)
                        timeArrivalToCenter.Value = _SelectedMission.ReturnToStationTime.Value;

                    _NumberOfInjuries = _SelectedMission.NumberOfInjuries;
                }
            }
        }

        private int GetFromAndToId(Mission CurrentMission, bool ReturnFromId)
        {
            int fromId = 0;
            int toId = 0;
            int directionFlag = 0;

            var missionDirection = _MissionDirections.Where(a => a.Id == _SelectedMission.IdMissionDirection).First();
            directionFlag = missionDirection.DirectionFlag;

            DirectionFlagEnum directionFlagEnum = (DirectionFlagEnum)directionFlag;

            switch (directionFlagEnum)
            {
                case DirectionFlagEnum.FromAreaToHospital:
                    fromId = CurrentMission.IdFromArea;
                    toId = CurrentMission.IdToHospital;
                    break;
                case DirectionFlagEnum.FromHospitalToHospital:
                    fromId = CurrentMission.IdFromHospital;
                    toId = CurrentMission.IdToHospital;
                    break;
                case DirectionFlagEnum.FromHospitalToArea:
                    fromId = CurrentMission.IdFromHospital;
                    toId = CurrentMission.IdToArea;
                    break;
                case DirectionFlagEnum.FromAreaToArea:
                    fromId = CurrentMission.IdFromArea;
                    toId = CurrentMission.IdToArea;
                    break;
                case DirectionFlagEnum.FromAreaToNull:
                    fromId = CurrentMission.IdFromArea;
                    toId = 0;
                    break;
                case DirectionFlagEnum.FromNursingHomeToHospital:
                    fromId = CurrentMission.IdFromNursingHome;
                    toId = CurrentMission.IdToHospital;
                    break;
                case DirectionFlagEnum.FromAreaToNursingHome:
                    fromId = CurrentMission.IdFromArea;
                    toId = CurrentMission.IdToNursingHome;
                    break;
                case DirectionFlagEnum.FromHospitalToNursingHome:
                    fromId = CurrentMission.IdFromHospital;
                    toId = CurrentMission.IdToNursingHome;
                    break;
                case DirectionFlagEnum.FromNursingHomeToNursingHome:
                    fromId = CurrentMission.IdFromNursingHome;
                    toId = CurrentMission.IdToNursingHome;
                    break;
            }

            if (ReturnFromId)
                return fromId;
            else
                return toId;
        }

        private void FillDdlVehicles()
        {
            _Items = new List<ComboBoxItem>();

            if (_Vehicles == null)
                _Vehicles = OperationsBlo.GetAllVehicles();

            if (_Vehicles.Count > 0)
            {
                foreach (Vehicle vehicle in _Vehicles)
                    _Items.Add(new ComboBoxItem { Text = vehicle.PlateNumber, Value = vehicle.Id });

                ddlVehicles.DisplayMember = "Text";
                ddlVehicles.ValueMember = "Value";
                ddlVehicles.DataSource = _Items;
                ddlVehicles.SelectedIndex = 0;

                // Get the last mileage of the first loaded vehicle
                if (IsCurrent)
                {
                    int SelectedVehicleId;
                    ComboBoxItem selectedVehicle = (ComboBoxItem)ddlVehicles.SelectedItem;
                    int.TryParse(selectedVehicle.Value.ToString(), out SelectedVehicleId);
                    txtStartingMileage.Text = OperationsBlo.GetLastMileage(_Vehicles, SelectedVehicleId);
                }
                else
                {
                    _SelectedMission = OperationsBlo.GetSpecificMission(this.IdMission);
                    if (_SelectedMission != null)
                    {
                        txtStartingMileage.Text = _SelectedMission.InitialMileage.ToString();
                    }
                }
            }
        }

        private void ddlVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox vehicleComboBox = (ComboBox)sender;
            int vehicleId;
            int.TryParse(vehicleComboBox.SelectedValue.ToString(), out vehicleId);

            if (this.IsCurrent)
            {
                txtStartingMileage.Text = OperationsBlo.GetLastMileage(_Vehicles, vehicleId);
            }
        }

        private void FillDdlNationality()
        {
            _Items = new List<ComboBoxItem>();
            if (_Nationalities == null)
                _Nationalities = OperationsBlo.GetAllNationalities();
            if (_Nationalities.Count > 0)
            {
                foreach (Nationality nationality in _Nationalities)
                    _Items.Add(new ComboBoxItem { Text = nationality.NationalityValue, Value = nationality.Id });

                ddlNationality.DisplayMember = "Text";
                ddlNationality.ValueMember = "Value";
                ddlNationality.DataSource = _Items;
                ddlNationality.SelectedIndex = 0;
            }
        }

        private void FillDdlDriver()
        {
            List<Rescuer> orderedDriversList;
            _Items = new List<ComboBoxItem>();
            if (_Drivers == null)
                _Drivers = OperationsBlo.GetActiveDrivers();

            orderedDriversList = OperationsBlo.OrderRescuersByShift(_Drivers);

            if (_Drivers.Count > 0)
            {
                foreach (Rescuer driver in orderedDriversList)
                    _Items.Add(new ComboBoxItem { Text = driver.Nickname + " - " + driver.Name + " " + driver.LastName, Value = driver.Id });

                ddlDriver.DisplayMember = "Text";
                ddlDriver.ValueMember = "Value";
                ddlDriver.DataSource = _Items;
                ddlDriver.SelectedIndex = 0;
            }
        }

        private void FillDdlRescuers()
        {
            List<Rescuer> orderedRescuersList;

            _Items = new List<ComboBoxItem>();
            _Items.Add(new ComboBoxItem { Text = "", Value = 0 });
            if (_Rescuers == null)
                _Rescuers = OperationsBlo.GetActiveRescuers();

            orderedRescuersList = OperationsBlo.OrderRescuersByShift(_Rescuers);

            if (orderedRescuersList.Count > 0)
            {
                foreach (Rescuer rescuer in orderedRescuersList)
                    _Items.Add(new ComboBoxItem { Text = rescuer.Nickname + " - " + rescuer.Name + " " + rescuer.LastName, Value = rescuer.Id });

                ddlRescuer1.DisplayMember = "Text";
                ddlRescuer1.ValueMember = "Value";
                ddlRescuer1.DataSource = new List<ComboBoxItem>(_Items);
                ddlRescuer1.SelectedIndex = 0;

                ddlRescuer2.DisplayMember = "Text";
                ddlRescuer2.ValueMember = "Value";
                ddlRescuer2.DataSource = new List<ComboBoxItem>(_Items);
                ddlRescuer2.SelectedIndex = 0;

                ddlRescuer3.DisplayMember = "Text";
                ddlRescuer3.ValueMember = "Value";
                ddlRescuer3.DataSource = new List<ComboBoxItem>(_Items);
                ddlRescuer3.SelectedIndex = 0;

                ddlRescuer4.DisplayMember = "Text";
                ddlRescuer4.ValueMember = "Value";
                ddlRescuer4.DataSource = new List<ComboBoxItem>(_Items);
                ddlRescuer4.SelectedIndex = 0;
            }
        }

        private void FillDdlVehicleLocation()
        {
            if (IsCurrent == true)
            {
                _Items = new List<ComboBoxItem>();
                if (_MissionStatuses == null)
                    _MissionStatuses = OperationsBlo.GetMissionStatuses();

                if (_MissionStatuses.Count > 0)
                {
                    foreach (MissionStatus missionStatus in _MissionStatuses)
                        _Items.Add(new ComboBoxItem(missionStatus.Code, missionStatus.Status + " - " + missionStatus.StatusArabic));

                    ddlVehicleLocation.DisplayMember = "Text";
                    ddlVehicleLocation.ValueMember = "Value";
                    ddlVehicleLocation.DataSource = _Items;
                    ddlVehicleLocation.SelectedIndex = -1;
                }
            }
            else
            {
                lblVehicleLocation.Visible = false;
                ddlVehicleLocation.Visible = false;
            }
        }

        private void FillDdlCaseType()
        {
            _Items = new List<ComboBoxItem>();
            _CaseTypes = OperationsBlo.GetAllCaseTypes();
            if (_CaseTypes.Count > 0)
            {
                foreach (CaseType caseType in _CaseTypes)
                    _Items.Add(new ComboBoxItem(caseType.Id, caseType.Value + " - " + caseType.ValueArabic));

                ddlCaseType.DisplayMember = "Text";
                ddlCaseType.ValueMember = "Value";
                ddlCaseType.DataSource = _Items;
                ddlCaseType.SelectedIndex = 0;
            }
        }

        private void ddlCaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox caseTypeComboBox = (ComboBox)sender;
            int idCaseType;
            int.TryParse(caseTypeComboBox.SelectedValue.ToString(), out idCaseType);

            FillDdlCase(idCaseType);
        }

        private void FillDdlCase(int idCaseType)
        {
            List<Case> specificCases;

            //if (ddlCase.Items.Count > 0)
            //    ddlCase.Items.Clear();

            _Items = new List<ComboBoxItem>();

            if (_Cases == null)
                _Cases = OperationsBlo.GetAllCases();

            specificCases = OperationsBlo.GetSpecificCases(_Cases, idCaseType);

            if (specificCases.Count > 0)
            {
                foreach (Case casee in specificCases)
                    _Items.Add(new ComboBoxItem(casee.Id, casee.Value + " - " + casee.ValueArabic));

                ddlCase.DisplayMember = "Text";
                ddlCase.ValueMember = "Value";
                ddlCase.DataSource = _Items;
                ddlCase.SelectedIndex = 0;
            }
        }

        private void FillDdlMissionCategory()
        {
            _Items = new List<ComboBoxItem>();
            _MissionCategories = OperationsBlo.GetMissionCategories();
            if (_MissionCategories.Count > 0)
            {
                foreach (MissionCategory missionCategory in _MissionCategories)
                    _Items.Add(new ComboBoxItem(missionCategory.Id, missionCategory.DescriptionEnglish + " - " + missionCategory.DescriptionArabic));

                ddlMissionCategory.DisplayMember = "Text";
                ddlMissionCategory.ValueMember = "Value";
                ddlMissionCategory.DataSource = _Items;
                ddlMissionCategory.SelectedIndex = 0;
            }
        }

        private void ddlMissionCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox missionCategoryComboBox = (ComboBox)sender;
            int missionCategoryId;
            int.TryParse(missionCategoryComboBox.SelectedValue.ToString(), out missionCategoryId);

            FillDdlMissionDirection(missionCategoryId);
            FillDdlCaseClassification(missionCategoryId);

            if (missionCategoryId == (int)MissionCategoryEnum.Diverse)
            {
                if (ddlNationality.Items.Count > 0)
                    ddlNationality.SelectedIndex = -1;

                if (ddlCaseType.Items.Count > 0)
                    ddlCaseType.SelectedIndex = (int)CaseTypeEnum.Other - 1;
            }
            else
            {
                if (ddlNationality.Items.Count > 0)
                    ddlNationality.SelectedIndex = 0;

                if (ddlCaseType.Items.Count > 0)
                    ddlCaseType.SelectedIndex = 0;
            }
        }

        private void FillDdlMissionDirection(int missionCategoryId)
        {
            List<MissionDirection> specificMissionDirection;

            //if (ddlMissionDirection.Items.Count > 0)
            //    ddlMissionDirection.DataSource = null;

            _Items = new List<ComboBoxItem>();

            if (_MissionDirections == null)
                _MissionDirections = OperationsBlo.GetAllMissionDirections();

            specificMissionDirection = OperationsBlo.GetSpecificMissionDirections(_MissionDirections, missionCategoryId);

            if (specificMissionDirection.Count > 0)
            {
                foreach (MissionDirection missionDirection in specificMissionDirection)
                    _Items.Add(new ComboBoxItem(missionDirection.Id, missionDirection.Description));

                ddlMissionDirection.DisplayMember = "Text";
                ddlMissionDirection.ValueMember = "Value";
                ddlMissionDirection.DataSource = _Items;
                ddlMissionDirection.SelectedIndex = 0;
            }
        }

        private void FillDdlCaseClassification(int missionCategoryId)
        {
            List<CaseClassification> specificCaseClassifications;

            //if (ddlCaseClassification.Items.Count > 0)
            //    ddlCaseClassification.Items.Clear();

            _Items = new List<ComboBoxItem>();

            if (_CaseClassifications == null)
                _CaseClassifications = OperationsBlo.GetAllCaseClassifications();

            specificCaseClassifications = OperationsBlo.GetSpecificCaseClassifications(_CaseClassifications, missionCategoryId);

            if (specificCaseClassifications.Count > 0)
            {
                foreach (CaseClassification caseClassification in specificCaseClassifications)
                    _Items.Add(new ComboBoxItem(caseClassification.Id, caseClassification.Value + " - " + caseClassification.ValueArabic));

                ddlCaseClassification.DisplayMember = "Text";
                ddlCaseClassification.ValueMember = "Value";
                ddlCaseClassification.DataSource = _Items;
                ddlCaseClassification.SelectedIndex = 0;
            }
        }

        private void ddlMissionDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Areas == null)
                    _Areas = OperationsBlo.GetAllAreas();

                if (_Hospitals == null)
                    _Hospitals = OperationsBlo.GetAllHospitals();

                if (_NursingHomes == null)
                    _NursingHomes = OperationsBlo.GetAllNursingHomes();

                lblTo.Visible = true;
                ddlTo.Visible = true;

                ComboBox missionDirectionComboBox = (ComboBox)sender;
                int idMissionDirection = 0;
                int.TryParse(missionDirectionComboBox.SelectedValue.ToString(), out idMissionDirection);
                FillFromAndToDdlAccordingToDirectionFlag(idMissionDirection);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void FillFromAndToDdlAccordingToDirectionFlag(int idMissionDirection)
        {
            int directionFlag = 0;

            var missionDirection = _MissionDirections.Where(a => a.Id == idMissionDirection).First();
            directionFlag = missionDirection.DirectionFlag;

            DirectionFlagEnum directionFlagEnum = (DirectionFlagEnum)directionFlag;

            switch (directionFlagEnum)
            {
                case DirectionFlagEnum.FromAreaToHospital:
                    {
                        FillDdlFrom(_Areas);
                        FillDdlTo(_Hospitals);
                    }
                    break;
                case DirectionFlagEnum.FromHospitalToHospital:
                    {
                        FillDdlFrom(_Hospitals);
                        FillDdlTo(_Hospitals);
                    }
                    break;
                case DirectionFlagEnum.FromHospitalToArea:
                    {
                        FillDdlFrom(_Hospitals);
                        FillDdlTo(_Areas);
                    }
                    break;
                case DirectionFlagEnum.FromAreaToArea:
                    {
                        FillDdlFrom(_Areas);
                        FillDdlTo(_Areas);
                    }
                    break;
                case DirectionFlagEnum.FromAreaToNull:
                    {
                        FillDdlFrom(_Areas);
                        lblTo.Visible = false;
                        ddlTo.Visible = false;
                    }
                    break;
                case DirectionFlagEnum.FromNursingHomeToHospital:
                    {
                        FillDdlFrom(_NursingHomes);
                        FillDdlTo(_Hospitals);
                    }
                    break;
                case DirectionFlagEnum.FromAreaToNursingHome:
                    {
                        FillDdlFrom(_Areas);
                        FillDdlTo(_NursingHomes);
                    }
                    break;
                case DirectionFlagEnum.FromHospitalToNursingHome:
                    {
                        FillDdlFrom(_Hospitals);
                        FillDdlTo(_NursingHomes);
                    }
                    break;
                case DirectionFlagEnum.FromNursingHomeToNursingHome:
                    {
                        FillDdlFrom(_NursingHomes);
                        FillDdlTo(_NursingHomes);
                    }
                    break;
            }
        }

        private void FillDdlFrom(List<Area> Areas)
        {
            //if (ddlFrom.Items.Count > 0)
            //    ddlFrom.Items.Clear();

            _Items = new List<ComboBoxItem>();
            if (Areas.Count > 0)
            {
                foreach (Area area in Areas)
                    _Items.Add(new ComboBoxItem(area.Id, area.Name + " - " + area.NameArabic));

                ddlFrom.DisplayMember = "Text";
                ddlFrom.ValueMember = "Value";
                ddlFrom.DataSource = _Items;
                ddlFrom.SelectedIndex = 0;
            }
        }

        private void FillDdlFrom(List<Hospital> Hospitals)
        {
            //if (ddlFrom.Items.Count > 0)
            //    ddlFrom.Items.Clear();

            _Items = new List<ComboBoxItem>();
            if (Hospitals.Count > 0)
            {
                foreach (Hospital hospital in Hospitals)
                    _Items.Add(new ComboBoxItem
                    {
                        Text = hospital.Code.Equals(string.Empty) ? hospital.Name : hospital.Name + " - " + hospital.Code,
                        Value = hospital.Id
                    });

                ddlFrom.DisplayMember = "Text";
                ddlFrom.ValueMember = "Value";
                ddlFrom.DataSource = _Items;
                ddlFrom.SelectedIndex = 0;
            }
        }

        private void FillDdlFrom(List<NursingHome> NursingHomes)
        {
            //if (ddlFrom.Items.Count > 0)
            //    ddlFrom.Items.Clear();

            _Items = new List<ComboBoxItem>();
            if (NursingHomes.Count > 0)
            {
                foreach (NursingHome nursingHome in NursingHomes)
                    _Items.Add(new ComboBoxItem(nursingHome.Id, nursingHome.Name));

                ddlFrom.DisplayMember = "Text";
                ddlFrom.ValueMember = "Value";
                ddlFrom.DataSource = _Items;
                ddlFrom.SelectedIndex = 0;
            }
        }

        private void FillDdlTo(List<Area> Areas)
        {
            //if (ddlTo.Items.Count > 0)
            //    ddlTo.Items.Clear();

            _Items = new List<ComboBoxItem>();
            if (Areas.Count > 0)
            {
                foreach (Area area in Areas)
                    _Items.Add(new ComboBoxItem(area.Id, area.Name + " - " + area.NameArabic));

                ddlTo.DisplayMember = "Text";
                ddlTo.ValueMember = "Value";
                ddlTo.DataSource = _Items;
                ddlTo.SelectedIndex = 0;
            }
        }

        private void FillDdlTo(List<Hospital> Hospitals)
        {
            string hospitalName;

            //if (ddlTo.Items.Count > 0)
            //    ddlTo.Items.Clear();

            _Items = new List<ComboBoxItem>();
            if (Hospitals.Count > 0)
            {
                foreach (Hospital hospital in Hospitals)
                    _Items.Add(new ComboBoxItem
                    {
                        Value = hospital.Id,
                        Text = hospital.Code.Equals(string.Empty) ? hospital.Name : hospital.Name + " - " + hospital.Code
                    });

                ddlTo.DisplayMember = "Text";
                ddlTo.ValueMember = "Value";
                ddlTo.DataSource = _Items;
                ddlTo.SelectedIndex = 0;
            }
        }

        private void FillDdlTo(List<NursingHome> NursingHomes)
        {
            //if (ddlTo.Items.Count > 0)
            //    ddlTo.Items.Clear();

            _Items = new List<ComboBoxItem>();
            if (NursingHomes.Count > 0)
            {
                foreach (NursingHome nursingHome in NursingHomes)
                    _Items.Add(new ComboBoxItem(nursingHome.Id, nursingHome.Name));

                ddlTo.DisplayMember = "Text";
                ddlTo.ValueMember = "Value";
                ddlTo.DataSource = _Items;
                ddlTo.SelectedIndex = 0;
            }
        }

        private void txtFinalMileage_TextChanged(object sender, EventArgs e)
        {
            int startingMileage, finalMileage, traveledDistance;
            if (int.TryParse(txtStartingMileage.Text.Trim(), out startingMileage) && int.TryParse(txtFinalMileage.Text.Trim(), out finalMileage))
            {
                traveledDistance = finalMileage - startingMileage;
                txtTraveledDistance.Text = traveledDistance.ToString();

                if (traveledDistance < 0)
                    txtTraveledDistance.BackColor = Color.LightSalmon;
                else
                    txtTraveledDistance.BackColor = Color.LightGray;
            }
            else
                MessageBox.Show("Invalid mileage inputs", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool inputsAreValid = true;
            bool inputsAreComplete = true;

            //Conditions: int textboxes should only contain integers(Mileage & Age), final mileage greater than the starting mileage 
            //            Datetime is incremental(arrival to case time > departure to case)

            int initialMileage = 0;
            int finalMileage = 0;
            int travelledDistance = 0;
            int patientAge = 0;
            int passengerAge = 0;
            int idFrom;
            int idTo = 0;

            while (inputsAreValid)
            {
                if (txtStartingMileage.Text.Trim() != string.Empty)
                {
                    inputsAreValid = int.TryParse(txtStartingMileage.Text.Trim(), out initialMileage);
                    if (!inputsAreValid) break;
                }

                if (txtFinalMileage.Text.Trim() != string.Empty)
                {
                    inputsAreValid = int.TryParse(txtFinalMileage.Text.Trim(), out finalMileage);
                    if (!inputsAreValid) break;
                }

                if (initialMileage > 0 && finalMileage > 0)
                {
                    travelledDistance = finalMileage - initialMileage;
                    if (travelledDistance <= 0)
                    {
                        inputsAreValid = false;
                        break;
                    }
                }

                if (txtPatientAge.Text.Trim() != string.Empty)
                {
                    inputsAreValid = int.TryParse(txtPatientAge.Text.Trim(), out patientAge);
                    if (!inputsAreValid) break;
                }

                if (patientAge > 130)
                {
                    inputsAreValid = false;
                    break;
                }

                if (txtPassengerAge.Text.Trim() != string.Empty)
                {
                    inputsAreValid = int.TryParse(txtPassengerAge.Text.Trim(), out passengerAge);
                    if (!inputsAreValid) break;
                }

                if (passengerAge > 130)
                {
                    inputsAreValid = false;
                    break;
                }

                //Should break by default, so it goes one time through the loop
                break;
            }

            if (this.IdMission > 0 && inputsAreValid.Equals(true))
            {
                //If it is a Post mission, prompt the number of injured
                if ((int)ddlCaseClassification.SelectedValue == 19)
                {

                }

                _SelectedMission.ID = this.IdMission;
                _SelectedMission.IdVehicle = (int)ddlVehicles.SelectedValue;

                if (initialMileage > 0)
                    _SelectedMission.InitialMileage = initialMileage;

                if (finalMileage > 0)
                    _SelectedMission.FinalMileage = finalMileage;

                if (travelledDistance > 0)
                    _SelectedMission.TraveledDistanceInKm = travelledDistance;

                if (ddlDriver.SelectedIndex > -1)
                    _SelectedMission.IdDriver = (int)ddlDriver.SelectedValue;

                if (ddlRescuer1.SelectedIndex > -1)
                    _SelectedMission.IdRescuer1 = (int)ddlRescuer1.SelectedValue;

                if (ddlRescuer2.SelectedIndex > -1)
                    _SelectedMission.IdRescuer2 = (int)ddlRescuer2.SelectedValue;

                if (ddlRescuer3.SelectedIndex > -1)
                    _SelectedMission.IdRescuer3 = (int)ddlRescuer3.SelectedValue;

                if (ddlRescuer4.SelectedIndex > -1)
                    _SelectedMission.IdRescuer4 = (int)ddlRescuer4.SelectedValue;

                _SelectedMission.IdMissionCategory = (int)ddlMissionCategory.SelectedValue;
                _SelectedMission.IdMissionDirection = (int)ddlMissionDirection.SelectedValue;

                int.TryParse(ddlFrom.SelectedValue.ToString(), out idFrom);

                if (ddlTo.SelectedIndex >= 0)
                    int.TryParse(ddlTo.SelectedValue.ToString(), out idTo);

                SaveFromAndToId(idFrom, idTo);

                _SelectedMission.Notes = txtNotes.Text.Trim();
                _SelectedMission.PatientFullName = txtPatientName.Text.Trim();

                if (txtPatientName.Text.Trim() == string.Empty)
                    _SelectedMission.PatientYob = 0;

                if (patientAge > 0)
                    _SelectedMission.PatientYob = DateTime.Today.Year - patientAge;

                if (ddlNationality.SelectedIndex >= 0)
                    _SelectedMission.IdPatientNationality = (int)ddlNationality.SelectedValue;

                _SelectedMission.IdCaseType = (int)ddlCaseType.SelectedValue;
                _SelectedMission.IdCase = (int)ddlCase.SelectedValue;
                _SelectedMission.IdCaseClassification = (int)ddlCaseClassification.SelectedValue;

                _SelectedMission.CaseDescription = txtCaseDescription.Text.Trim();
                _SelectedMission.PassengerFullName = txtPassengerName.Text.Trim();

                if (txtPassengerName.Text.Trim() == string.Empty)
                    _SelectedMission.PassengerYob = 0;

                if (passengerAge > 0)
                    _SelectedMission.PassengerYob = DateTime.Today.Year - passengerAge;

                if (ddlVehicleLocation.SelectedValue != null)
                    _SelectedMission.Status = (int)ddlVehicleLocation.SelectedValue;

                _SelectedMission.DepartureToCaseTime = new DateTime(dtDepartureToCase.Value.Year, dtDepartureToCase.Value.Month, dtDepartureToCase.Value.Day, timeDepartureToCase.Value.Hour, timeDepartureToCase.Value.Minute, timeDepartureToCase.Value.Second);
                _SelectedMission.ArrivalToCaseTime = new DateTime(dtArrivalToCase.Value.Year, dtArrivalToCase.Value.Month, dtArrivalToCase.Value.Day, timeArrivalToCase.Value.Hour, timeArrivalToCase.Value.Minute, timeArrivalToCase.Value.Second);
                _SelectedMission.DepartureToDestinationTime = new DateTime(dtDepartureToDestination.Value.Year, dtDepartureToDestination.Value.Month, dtDepartureToDestination.Value.Day, timeDepartureToDestination.Value.Hour, timeDepartureToDestination.Value.Minute, timeDepartureToDestination.Value.Second);
                _SelectedMission.ArrivalToDestinationTime = new DateTime(dtArrivalToDestination.Value.Year, dtArrivalToDestination.Value.Month, dtArrivalToDestination.Value.Day, timeArrivalToDestination.Value.Hour, timeArrivalToDestination.Value.Minute, timeArrivalToDestination.Value.Second);
                _SelectedMission.MissionCompletedTime = new DateTime(dtDepartureToCenter.Value.Year, dtDepartureToCenter.Value.Month, dtDepartureToCenter.Value.Day, timeDepartureToCenter.Value.Hour, timeDepartureToCenter.Value.Minute, timeDepartureToCenter.Value.Second);
                _SelectedMission.ReturnToStationTime = new DateTime(dtArrivalToCenter.Value.Year, dtArrivalToCenter.Value.Month, dtArrivalToCenter.Value.Day, timeArrivalToCenter.Value.Hour, timeArrivalToCenter.Value.Minute, timeArrivalToCenter.Value.Second);

                switch (_SelectedMission.Status)
                {
                    case (int)MissionStatusEnum.Scheduled:
                        _SelectedMission.DepartureToCaseTime = null;
                        _SelectedMission.ArrivalToCaseTime = null;
                        _SelectedMission.DepartureToDestinationTime = null;
                        _SelectedMission.ArrivalToDestinationTime = null;
                        _SelectedMission.MissionCompletedTime = null;
                        _SelectedMission.ReturnToStationTime = null;
                        break;
                    case (int)MissionStatusEnum.DepartureToCase:
                        _SelectedMission.ArrivalToCaseTime = null;
                        _SelectedMission.DepartureToDestinationTime = null;
                        _SelectedMission.ArrivalToDestinationTime = null;
                        _SelectedMission.MissionCompletedTime = null;
                        _SelectedMission.ReturnToStationTime = null;
                        break;
                    case (int)MissionStatusEnum.ArrivalToCase:
                        _SelectedMission.DepartureToDestinationTime = null;
                        _SelectedMission.ArrivalToDestinationTime = null;
                        _SelectedMission.MissionCompletedTime = null;
                        _SelectedMission.ReturnToStationTime = null;
                        break;
                    case (int)MissionStatusEnum.DepartureToDestination:
                        _SelectedMission.ArrivalToDestinationTime = null;
                        _SelectedMission.MissionCompletedTime = null;
                        _SelectedMission.ReturnToStationTime = null;
                        break;
                    case (int)MissionStatusEnum.ArrivalToDestination:
                        _SelectedMission.MissionCompletedTime = null;
                        _SelectedMission.ReturnToStationTime = null;
                        break;
                    case (int)MissionStatusEnum.DepartureToCenter:
                        _SelectedMission.ReturnToStationTime = null;
                        break;
                    case (int)MissionStatusEnum.ArrivalToCenter:
                        _SelectedMission.MissionDurationInMinutes = OperationsBlo.UpdateMissionDuration(_SelectedMission);
                        break;
                    case (int)MissionStatusEnum.DetailsFilled:
                        inputsAreComplete = CheckIfAllInputsAreComplete();
                        if (inputsAreComplete)
                        {
                            if (_SelectedMission.ReturnToStationTime == null)
                                _SelectedMission.ReturnToStationTime = DateTime.Now;
                            _SelectedMission.MissionDurationInMinutes = OperationsBlo.UpdateMissionDuration(_SelectedMission);
                            //Update vehicle last mileage in case the details are filled and the mission is still in current
                            if (IsCurrent)
                                OperationsBlo.UpdateVehicleLastMileage(_SelectedMission);
                        }
                        break;
                    case (int)MissionStatusEnum.Cancelled:
                        inputsAreComplete = CheckIfAllInputsAreComplete();
                        if (inputsAreComplete)
                        {
                            if (_SelectedMission.ReturnToStationTime == null)
                                _SelectedMission.ReturnToStationTime = DateTime.Now;
                            _SelectedMission.MissionDurationInMinutes = OperationsBlo.UpdateMissionDuration(_SelectedMission);
                            //Update vehicle last mileage in case the details are filled and the mission is still in current
                            if (IsCurrent)
                                OperationsBlo.UpdateVehicleLastMileage(_SelectedMission);
                        }

                        break;
                }

                if (_SelectedMission.Status == (int)MissionStatusEnum.Cancelled || _SelectedMission.Status == (int)MissionStatusEnum.DetailsFilled)
                {
                    if (inputsAreComplete)
                    {
                        OperationsBlo.UpdateMission(_SelectedMission);

                        //Close the form
                        this.Close();
                    }
                    else
                        MessageBox.Show("هناك نقص في المعلومات المعبأة(ك.م. توجه السيارة، إسم وعمر المريض)", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OperationsBlo.UpdateMission(_SelectedMission);

                    //Close the form
                    this.Close();
                }

                if ((int)ddlCaseClassification.SelectedValue == ConstantsClass.PostIdCaseClassification || (int)ddlCaseClassification.SelectedValue == ConstantsClass.AvpIdCaseClassification)
                {
                    PostInjuries postInjuriesForm = new PostInjuries(_SelectedMission);
                    postInjuriesForm.ShowDialog();
                }
            }
            else
                MessageBox.Show("هناك خطأ في إدخال البيانات. الرجاء التحقق من كل المعلومات(كيلومتراج، عمر)", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool CheckIfAllInputsAreComplete()
        {
            bool inputsAreComplete = true;

            while (inputsAreComplete)
            {
                if (txtStartingMileage.Text.Trim() == string.Empty)
                {
                    inputsAreComplete = false;
                    break;
                }

                if (txtFinalMileage.Text.Trim() == string.Empty)
                {
                    inputsAreComplete = false;
                    break;
                }

                if (_SelectedMission.IdMissionCategory == 1 || _SelectedMission.IdMissionCategory == 2)
                {
                    if (txtPatientName.Text.Trim() == string.Empty)
                    {
                        inputsAreComplete = false;
                        break;
                    }

                    if (txtPatientAge.Text.Trim() == string.Empty)
                    {
                        inputsAreComplete = false;
                        break;
                    }
                }

                //If it's not diverse nor SSP, there should be a destination entered, orelse inputs are not complete
                if (_SelectedMission.IdMissionCategory != (int)MissionCategoryEnum.Diverse)
                {
                    //IdMissionDirection = 7 means SSP
                    if (_SelectedMission.IdMissionDirection != 7)
                    {
                        if (ddlTo.SelectedValue == null)
                        {
                            inputsAreComplete = false;
                            break;
                        }
                    }
                }

                //Break by default when all components are checked
                break;
            }

            return inputsAreComplete;
        }

        private void SaveFromAndToId(int FromId, int ToId)
        {
            int directionFlag = 0;

            var missionDirection = _MissionDirections.Where(a => a.Id == _SelectedMission.IdMissionDirection).First();
            directionFlag = missionDirection.DirectionFlag;

            DirectionFlagEnum directionFlagEnum = (DirectionFlagEnum)directionFlag;

            switch (directionFlagEnum)
            {
                case DirectionFlagEnum.FromAreaToHospital:
                    _SelectedMission.IdFromArea = FromId;
                    _SelectedMission.IdToHospital = ToId;
                    break;
                case DirectionFlagEnum.FromHospitalToHospital:
                    _SelectedMission.IdFromHospital = FromId;
                    _SelectedMission.IdToHospital = ToId;
                    break;
                case DirectionFlagEnum.FromHospitalToArea:
                    _SelectedMission.IdFromHospital = FromId;
                    _SelectedMission.IdToArea = ToId;
                    break;
                case DirectionFlagEnum.FromAreaToArea:
                    _SelectedMission.IdFromArea = FromId;
                    _SelectedMission.IdToArea = ToId;
                    break;
                case DirectionFlagEnum.FromAreaToNull:
                    _SelectedMission.IdFromArea = FromId;
                    break;
                case DirectionFlagEnum.FromNursingHomeToHospital:
                    _SelectedMission.IdFromNursingHome = FromId;
                    _SelectedMission.IdToHospital = ToId;
                    break;
                case DirectionFlagEnum.FromAreaToNursingHome:
                    _SelectedMission.IdFromArea = FromId;
                    _SelectedMission.IdToNursingHome = ToId;
                    break;
                case DirectionFlagEnum.FromHospitalToNursingHome:
                    _SelectedMission.IdFromHospital = FromId;
                    _SelectedMission.IdToNursingHome = ToId;
                    break;
                case DirectionFlagEnum.FromNursingHomeToNursingHome:
                    _SelectedMission.IdFromNursingHome = FromId;
                    _SelectedMission.IdToNursingHome = ToId;
                    break;
            }
        }

        private void btnDeleteMission_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل فعلاً تريد الغاء هذه المهمة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                OperationsBlo.DeleteMission(this.IdMission);
                this.Close();
            }
        }



    }
}
