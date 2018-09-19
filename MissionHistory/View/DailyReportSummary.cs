using MissionHistory.BusinessLogicLayer;
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

namespace MissionHistory.View
{
    public partial class DailyReportSummary : Form
    {
        DateTime _CurrentDateTimeSetter;
        List<Rescuer> _TeamLeaders;

        public DailyReportSummary()
        {
            InitializeComponent();
            _CurrentDateTimeSetter = DateTime.Today;
            _TeamLeaders = OperationsBlo.GetAllTeamLeaders();
            DisplayDateMargins(0);
            FillReportInfo();

            if (grdDailyMissionReport.DataSource != null)
                this.grdDailyMissionReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DisplayDateMargins(int Counter)
        {
            DateTime dateBeforeXDays = DateTime.Today.AddDays(-7);

            if (_CurrentDateTimeSetter.AddDays(Counter).Date == DateTime.Today.Date)
                btnNextDayMissions.Enabled = false;
            else
                btnNextDayMissions.Enabled = true;

            if (_CurrentDateTimeSetter.AddDays(Counter).Date == dateBeforeXDays.Date)
                btnPreviousDayMissions.Enabled = false;
            else
                btnPreviousDayMissions.Enabled = true;

            if (_CurrentDateTimeSetter.AddDays(Counter) <= DateTime.Today.Date && _CurrentDateTimeSetter.AddDays(Counter) >= dateBeforeXDays.Date)
            {
                _CurrentDateTimeSetter = _CurrentDateTimeSetter.AddDays(Counter);
                txtCurrentDay.Text = _CurrentDateTimeSetter.ToLongDateString();
            }
        }

        private void btnPreviousDayMissions_Click(object sender, EventArgs e)
        {
            DisplayDateMargins(-1);
            FillReportInfo();
        }

        private void btnNextDayMissions_Click(object sender, EventArgs e)
        {
            DisplayDateMargins(1);
            FillReportInfo();
        }

        private void FillReportInfo()
        {
            FillGrdDailyMissionReport();
            FillDailyShiftReport();
        }

        private void FillGrdDailyMissionReport()
        {
            DateTime missionReportDate = _CurrentDateTimeSetter.AddDays(-1);
            lblDailyReportDate.Text = missionReportDate.ToLongDateString();
            DateTime from = new DateTime(missionReportDate.Year, missionReportDate.Month, missionReportDate.Day, 0, 0, 0);
            DateTime to = new DateTime(missionReportDate.Year, missionReportDate.Month, missionReportDate.Day, 23, 59, 59);

            List<ShiftReport> dailyMissionReport = OperationsBlo.GetDailyMissionReport(from, to);

            if (dailyMissionReport.Count > 0)
            {
                grdDailyMissionReport.DataSource = dailyMissionReport.Select(o => new
                {
                    تصنيف_المهمة = o.MissionClassification,
                    عدد_المهمات = o.MissionClassificationOccurence
                }).ToList();
            }
            else
                grdDailyMissionReport.DataSource = null;
        }

        private void FillDailyShiftReport()
        {
            string teamLeader = string.Empty;
            lblShiftReportDate.Text = _CurrentDateTimeSetter.ToLongDateString();
            DateTime from = new DateTime(_CurrentDateTimeSetter.Year, _CurrentDateTimeSetter.Month, _CurrentDateTimeSetter.Day, 0, 0, 0);
            DateTime to = new DateTime(_CurrentDateTimeSetter.Year, _CurrentDateTimeSetter.Month, _CurrentDateTimeSetter.Day, 23, 59, 59);

            ShiftReport dailyShiftReport = OperationsBlo.GetSpecificShiftReport(from, to);

            if (dailyShiftReport != null)
            {
                if (dailyShiftReport.IsDamaged476)
                    cb476.BackColor = System.Drawing.Color.Coral;
                else
                    cb476.BackColor = SystemColors.ControlLightLight;

                if (dailyShiftReport.IsDamaged477)
                    cb477.BackColor = System.Drawing.Color.Coral;
                else
                    cb477.BackColor = SystemColors.ControlLightLight;

                if (dailyShiftReport.IsDamaged478)
                    cb478.BackColor = System.Drawing.Color.Coral;
                else
                    cb478.BackColor = SystemColors.ControlLightLight;

                if (dailyShiftReport.IsDamaged479)
                    cb479.BackColor = System.Drawing.Color.Coral;
                else
                    cb479.BackColor = SystemColors.ControlLightLight;

                if (dailyShiftReport.IsDamaged480)
                    cb480.BackColor = System.Drawing.Color.Coral;
                else
                    cb480.BackColor = SystemColors.ControlLightLight;

                if (dailyShiftReport.IsDamaged443)
                    cb443.BackColor = System.Drawing.Color.Coral;
                else
                    cb443.BackColor = SystemColors.ControlLightLight;

                txtNumberOfRescuers.Text = dailyShiftReport.NumberOfRescuers.ToString();
                txtNumberOfTeams.Text = dailyShiftReport.NumberOfTeams.ToString();

                try
                {
                    var oTeamLeader = _TeamLeaders.First(a => a.Id == dailyShiftReport.IdTeamLeader);
                    if (oTeamLeader != null)
                        teamLeader = oTeamLeader.Name + " " + oTeamLeader.LastName;
                }
                catch (Exception ex)
                {
                    teamLeader = OperationsBlo.GetTeamLeaderName(dailyShiftReport.IdTeamLeader);
                }

                txtTeamLeader.Text = teamLeader;
                txtNotes.Text = dailyShiftReport.Notes;
            }
            else
            {
                cb476.BackColor = SystemColors.ControlLightLight;
                cb477.BackColor = SystemColors.ControlLightLight;
                cb478.BackColor = SystemColors.ControlLightLight;
                cb479.BackColor = SystemColors.ControlLightLight;
                cb480.BackColor = SystemColors.ControlLightLight;
                cb443.BackColor = SystemColors.ControlLightLight;
                txtNumberOfRescuers.Text = string.Empty;
                txtNumberOfTeams.Text = string.Empty;
                txtTeamLeader.Text = string.Empty;
                txtNotes.Text = string.Empty;
            }
        }

        private void btnManageReport_Click(object sender, EventArgs e)
        {
            DailyReportEdit dailyReportEdit = new DailyReportEdit();
            dailyReportEdit.ShowDialog();
            FillReportInfo();
        }


    }
}
