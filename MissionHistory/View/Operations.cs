using MissionHistory.BusinessLogicLayer;
using MissionHistory.Helper;
using MissionHistory.Model;
using MissionHistory.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static MissionHistory.Helper.Enumeration;

namespace MissionHistory
{
    public partial class Operations : Form
    {
        #region Constructor
        public Operations()
        {
            InitializeComponent();
            InitializeValues();
            SetTimer(1);
        }
        #endregion

        #region GlobalVariables
        List<Mission> _CurrentMissions;
        List<Mission> _DayMissions;
        DateTime _CurrentDateTimeForGrdDayMissions = DateTime.Today;
        #endregion

        #region Initialize Default Values
        private void InitializeValues()
        {
            FillGrdCurrentMissions();
            FillGrdDayMissions();
            DisplayDateOfDayMissions(0);
        }

        private void FillGrdCurrentMissions()
        {
            _CurrentMissions = OperationsBlo.GetCurrentMissions();

            if (_CurrentMissions.Count > 0)
            {
                grdCurrentMissions.DataSource = _CurrentMissions.OrderByDescending(a => a.CreatedDate).Select(o => new
                {
                    Id = o.ID,
                    رقم_السيارة = o.VehicleNumber,
                    مجدولة = o.ScheduledTime == DateTime.MinValue ? "-" : o.ScheduledTime.Value.ToString(@"HH\:mm\:ss"),
                    الإنطلاق_إلى_الحالة = o.DepartureToCaseTime == DateTime.MinValue ? "-" : o.DepartureToCaseTime.Value.ToString(@"HH\:mm\:ss"),
                    الوصول_إلى_الحالة = o.ArrivalToCaseTime == DateTime.MinValue ? "-" : o.ArrivalToCaseTime.Value.ToString(@"HH\:mm\:ss"),
                    الإنطلاق_إلى_الوجهة = o.DepartureToDestinationTime == DateTime.MinValue ? "-" : o.DepartureToDestinationTime.Value.ToString(@"HH\:mm\:ss"),
                    الوصول_إلى_الوجهة = o.ArrivalToDestinationTime == DateTime.MinValue ? "-" : o.ArrivalToDestinationTime.Value.ToString(@"HH\:mm\:ss"),
                    الإنطلاق_إلى_المركز = o.MissionCompletedTime == DateTime.MinValue ? "-" : o.MissionCompletedTime.Value.ToString(@"HH\:mm\:ss"),
                    الوصول_إلى_المركز = o.ReturnToStationTime == DateTime.MinValue ? "-" : o.ReturnToStationTime.Value.ToString(@"HH\:mm\:ss")
                }).ToList();

                grdCurrentMissions.Columns[0].Visible = false;
            }
            else
                grdCurrentMissions.DataSource = null;
        }

        private void FillGrdDayMissions()
        {
            DateTime from = new DateTime(_CurrentDateTimeForGrdDayMissions.Year, _CurrentDateTimeForGrdDayMissions.Month, _CurrentDateTimeForGrdDayMissions.Day, 0, 0, 0, 0);
            DateTime to = new DateTime(_CurrentDateTimeForGrdDayMissions.Year, _CurrentDateTimeForGrdDayMissions.Month, _CurrentDateTimeForGrdDayMissions.Day, 23, 59, 59, 990);

            _DayMissions = OperationsBlo.GetDayMissions(from, to);

            if (_DayMissions.Count > 0)
            {
                grdDayMissions.Columns.Clear();

                grdDayMissions.DataSource = _DayMissions.OrderByDescending(a => a.DepartureToCaseTime).Select(o => new
                {
                    Id = o.ID,
                    رقم_السيارة = o.VehicleNumber,
                    ك_م_الانطلاق = o.InitialMileage,
                    ك_م_العودة = o.FinalMileage,
                    المسافة = o.TraveledDistanceInKm,
                    السائق = o.DriverName,
                    المسعفون = o.Rescuer1Name + " " + o.Rescuer2Name + " " + o.Rescuer3Name + " " + o.Rescuer4Name,
                    من = GetFromAndToLocations(o, true),
                    إلى = GetFromAndToLocations(o, false),
                    إسم_المريض = o.PatientFullName,
                    عمر_المريض = o.PatientYob == 0 ? 0 : DateTime.Now.Year - o.PatientYob,
                    الحالة = o.Case,
                    تفاصيل_الحالة = o.CaseDescription,
                    تصنيف_الحالة = o.CaseClassification,
                    إسم_المرافق = o.PassengerFullName,
                    عمر_المرافق = o.PassengerYob == 0 ? 0 : DateTime.Now.Year - o.PassengerYob,
                    الإنطلاق_إلى_الحالة = o.DepartureToCaseTime == DateTime.MinValue ? "-" : o.DepartureToCaseTime.Value.ToString(@"HH\:mm\:ss"),
                    الوصول_إلى_المركز = o.ReturnToStationTime == DateTime.MinValue ? "-" : o.ReturnToStationTime.Value.ToString(@"HH\:mm\:ss"),
                    مدّة_المهمة = TimeSpan.FromMinutes(o.MissionDurationInMinutes).ToString(@"hh\:mm\:ss")
                }).ToList();
                grdDayMissions.Columns[0].Visible = false;
            }
            else
                AddDefaultColumnHeadersToGrdDayMissionsColumns();
        }
        #endregion

        private string GetFromAndToLocations(Mission CurrentMission, bool IsFrom)
        {
            int directionFlag;
            string fromValue = "";
            string toValue = "";

            directionFlag = GetDirectionFlag(CurrentMission.IdMissionDirection);

            switch (directionFlag)
            {
                case (int)DirectionFlagEnum.FromAreaToHospital:
                    fromValue = CurrentMission.FromArea;
                    toValue = CurrentMission.ToHospital;
                    break;
                case (int)DirectionFlagEnum.FromHospitalToHospital:
                    fromValue = CurrentMission.FromHospital;
                    toValue = CurrentMission.ToHospital;
                    break;
                case (int)DirectionFlagEnum.FromHospitalToArea:
                    fromValue = CurrentMission.FromHospital;
                    toValue = CurrentMission.ToArea;
                    break;
                case (int)DirectionFlagEnum.FromAreaToArea:
                    fromValue = CurrentMission.FromArea;
                    toValue = CurrentMission.ToArea;
                    break;
                case (int)DirectionFlagEnum.FromAreaToNull:
                    fromValue = CurrentMission.FromArea;
                    toValue = string.Empty;
                    break;
                case (int)DirectionFlagEnum.FromNursingHomeToHospital:
                    fromValue = CurrentMission.FromNursingHome;
                    toValue = CurrentMission.ToHospital;
                    break;
                case (int)DirectionFlagEnum.FromAreaToNursingHome:
                    fromValue = CurrentMission.FromArea;
                    toValue = CurrentMission.ToNursingHome;
                    break;
                case (int)DirectionFlagEnum.FromHospitalToNursingHome:
                    fromValue = CurrentMission.FromHospital;
                    toValue = CurrentMission.ToNursingHome;
                    break;
                case (int)DirectionFlagEnum.FromNursingHomeToNursingHome:
                    fromValue = CurrentMission.FromNursingHome;
                    toValue = CurrentMission.ToNursingHome;
                    break;
                default:
                    fromValue = string.Empty;
                    toValue = string.Empty;
                    break;
            }

            if (IsFrom)
                return fromValue;
            else
                return toValue;
        }

        private int GetDirectionFlag(int idMissionDirection)
        {
            List<MissionDirection> missionDirectionList = OperationsBlo.GetAllMissionDirections();
            return missionDirectionList.Where(a => a.Id == idMissionDirection).Select(a => a.DirectionFlag).First();
        }

        private void AddDefaultColumnHeadersToGrdDayMissionsColumns()
        {
            grdDayMissions.DataSource = null;
            grdDayMissions.Columns.Clear();

            grdDayMissions.Columns.Add("", "رقم_السيارة");
            grdDayMissions.Columns.Add("", "ك_م_الانطلاق");
            grdDayMissions.Columns.Add("", "ك_م_العودة");
            grdDayMissions.Columns.Add("", "المسافة");
            grdDayMissions.Columns.Add("", "السائق");
            grdDayMissions.Columns.Add("", "المسعفون");
            grdDayMissions.Columns.Add("", "من");
            grdDayMissions.Columns.Add("", "إلى");
            grdDayMissions.Columns.Add("", "إسم_المريض");
            grdDayMissions.Columns.Add("", "عمر_المريض");
            grdDayMissions.Columns.Add("", "الحالة");
            grdDayMissions.Columns.Add("", "تفاصيل_الحالة");
            grdDayMissions.Columns.Add("", "تصنيف_الحالة");
            grdDayMissions.Columns.Add("", "إسم_المرافق");
            grdDayMissions.Columns.Add("", "عمر_المرافق");
            grdDayMissions.Columns.Add("", "الإنطلاق_إلى_الحالة");
            grdDayMissions.Columns.Add("", "الوصول_إلى_المركز");
            grdDayMissions.Columns.Add("", "مدّة_المهمة");
        }

        private void btnAddMission_Click(object sender, EventArgs e)
        {
            NewMission newMission = new NewMission(_CurrentMissions);
            newMission.ShowDialog();

            FillGrdCurrentMissions();
        }

        private void btnUpdateVehicleLocation_Click(object sender, EventArgs e)
        {
            bool isMissingInfo = false;
            int selectedRowIndex, idMission, newStatus;
            if (grdCurrentMissions.Rows.Count > 0)
            {
                selectedRowIndex = grdCurrentMissions.SelectedRows[0].Index;
                int.TryParse(grdCurrentMissions.Rows[selectedRowIndex].Cells["ID"].FormattedValue.ToString(), out idMission);

                Mission currentMission;
                if (_CurrentMissions.Count > 0)
                {
                    currentMission = _CurrentMissions.Where(a => a.ID == idMission).First();

                    newStatus = currentMission.Status + 1;

                    if (newStatus == (int)MissionStatusEnum.DetailsFilled)
                    {
                        _CurrentMissions = OperationsBlo.GetCurrentMissions();
                        currentMission = _CurrentMissions.Where(a => a.ID == idMission).First();
                        CheckIfMissingInfoExist(currentMission, out isMissingInfo);
                        if (isMissingInfo)
                        {
                            MissionDetail missionDetail = new MissionDetail(idMission, true, true);
                            missionDetail.Show();
                            _CurrentMissions = OperationsBlo.GetCurrentMissions();
                            currentMission = _CurrentMissions.Where(a => a.ID == idMission).First();
                            CheckIfMissingInfoExist(currentMission, out isMissingInfo);
                        }
                    }

                    if (isMissingInfo)
                        MessageBox.Show("الرجاء تعبئة كل تفاصيل المهمة", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        OperationsBlo.MoveVehicleToNextLocation(currentMission, newStatus);

                        if (newStatus == (int)MissionStatusEnum.ArrivalToCenter)
                        {
                            _CurrentMissions = OperationsBlo.GetCurrentMissions();
                            currentMission = _CurrentMissions.Where(a => a.ID == idMission).First();
                            OperationsBlo.UpdateMissionDuration(currentMission);
                        }

                        FillGrdCurrentMissions();

                        if (newStatus != (int)MissionStatusEnum.DetailsFilled)
                        {
                            //Select the current row after filling the grid grdCurrentMissions
                            grdCurrentMissions.CurrentCell = grdCurrentMissions.Rows[selectedRowIndex].Cells[1];
                        }
                        else
                        {
                            //Update vehicle last mileage in case the mission is completed 
                            //and all the details are filled(so the mission is closed and moved to day missions)
                            OperationsBlo.UpdateVehicleLastMileage(currentMission);
                        }

                        FillGrdDayMissions();
                    }
                }
            }
        }

        private void CheckIfMissingInfoExist(Mission currentMission, out bool isMissingInfo)
        {
            isMissingInfo = false;

            while (true)
            {
                if (currentMission.InitialMileage == 0)
                {
                    isMissingInfo = true;
                    break;
                }

                if (currentMission.FinalMileage == 0)
                {
                    isMissingInfo = true;
                    break;
                }

                if (currentMission.IdMissionCategory == 1 || currentMission.IdMissionCategory == 2)
                {
                    if (currentMission.PatientFullName == string.Empty || currentMission.PatientFullName == null)
                    {
                        isMissingInfo = true;
                        break;
                    }

                    if (currentMission.PatientYob == 0)
                    {
                        isMissingInfo = true;
                        break;
                    }
                }

                //If it's not diverse nor SSP, there should be a destination entered, orelse inputs are not complete
                if (currentMission.IdMissionCategory != (int)MissionCategoryEnum.Diverse)
                {
                    //IdMissionDirection = 7 means SSP
                    if (currentMission.IdMissionDirection != 7)
                    {
                        if (currentMission.IdToArea == 0 && currentMission.IdToHospital == 0 && currentMission.IdToNursingHome == 0)
                        {
                            isMissingInfo = true;
                            break;
                        }
                    }
                }


                //Breaks by default
                break;
            }
        }
        
        private void DisplayDateOfDayMissions(int Counter)
        {
            DateTime dateBeforeXDays = DateTime.Today.AddDays(-7);

            if (_CurrentDateTimeForGrdDayMissions.AddDays(Counter).Date == DateTime.Today.Date)
                btnNextDayMissions.Enabled = false;
            else
                btnNextDayMissions.Enabled = true;

            if (_CurrentDateTimeForGrdDayMissions.AddDays(Counter).Date == dateBeforeXDays.Date)
                btnPreviousDayMissions.Enabled = false;
            else
                btnPreviousDayMissions.Enabled = true;

            if (_CurrentDateTimeForGrdDayMissions.AddDays(Counter) <= DateTime.Today.Date && _CurrentDateTimeForGrdDayMissions.AddDays(Counter) >= dateBeforeXDays.Date)
            {
                _CurrentDateTimeForGrdDayMissions = _CurrentDateTimeForGrdDayMissions.AddDays(Counter);
                txtCurrentDay.Text = _CurrentDateTimeForGrdDayMissions.ToLongDateString();
            }
        }

        private void btnPreviousDayMissions_Click(object sender, EventArgs e)
        {
            DisplayDateOfDayMissions(-1);
            FillGrdDayMissions();
        }

        private void btnNextDayMissions_Click(object sender, EventArgs e)
        {
            DisplayDateOfDayMissions(1);
            FillGrdDayMissions();
        }

        private void btnPhoneBook_Click(object sender, EventArgs e)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.ShowDialog();
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            DailyReportSummary dailyReport = new DailyReportSummary();
            dailyReport.Show();
        }

        private void SetTimer(int minutes)
        {
            System.Timers.Timer timer = new System.Timers.Timer(minutes * 60 * 1000);
            timer.Elapsed += HandleTimer;
            timer.Start();
        }

        private static void HandleTimer(Object source, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime rangeFrom = new DateTime(now.Year, now.Month, now.Day, 17, 45, 0);
            DateTime rangeTo = new DateTime(now.Year, now.Month, now.Day, 18, 10, 0);

            if (now >= rangeFrom && now <= rangeTo)
            {
                //17:45 - 18:10 This is the time range to prompt user to fill out the shift report information
                DateTime from = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                DateTime to = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

                ShiftReport dailyShiftReport = OperationsBlo.GetSpecificShiftReport(from, to);

                if (dailyShiftReport == null)
                {
                    bool isDailyReportEditFormOpened = false;

                    FormCollection formCollection = Application.OpenForms;
                    foreach (Form form in formCollection)
                    {
                        if (form.Name == "DailyReportEdit")
                            isDailyReportEditFormOpened = true;
                    }

                    //If the form DailyReportEdit is not open, open it and prompt user to fill report
                    if (isDailyReportEditFormOpened == false)
                    {
                        DailyReportEdit dailyReportEdit = new DailyReportEdit();
                        dailyReportEdit.ShowDialog();
                        //MessageBox.Show("الرجاء تعبئة التقرير اليومي", "تذكير", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void grdDayMissions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex, idMission;
            DataGridView grdDayMissions = (DataGridView)sender;
            selectedRowIndex = grdDayMissions.SelectedRows[0].Index;
            int.TryParse(grdDayMissions.Rows[selectedRowIndex].Cells["ID"].FormattedValue.ToString(), out idMission);

            MissionDetail missionDetailForm = new MissionDetail(idMission, false, false);
            missionDetailForm.ShowDialog();

            FillGrdDayMissions();
        }
        
        private void grdCurrentMissions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex, idMission;
            DataGridView grdCurrentMissions = (DataGridView)sender;
            selectedRowIndex = grdCurrentMissions.SelectedRows[0].Index;
            int.TryParse(grdCurrentMissions.Rows[selectedRowIndex].Cells["ID"].FormattedValue.ToString(), out idMission);

            MissionDetail missionDetailForm = new MissionDetail(idMission, true, false);
            missionDetailForm.ShowDialog();

            FillGrdCurrentMissions();
        }


    }
}

