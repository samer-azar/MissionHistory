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

namespace MissionHistory.View
{
    public partial class DailyReportEdit : Form
    {
        #region Global Variables
        DateTime _CurrentDateTimeSetter = DateTime.Today;
        List<Rescuer> _TeamLeaders;
        #endregion

        public DailyReportEdit()
        {
            InitializeComponent();
            FillDdlTeamLeader();
            DisplayDateMargins(0);
            FillReportInfo();
        }

        private void FillDdlTeamLeader()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            _TeamLeaders = OperationsBlo.GetAllTeamLeaders();

            if (_TeamLeaders.Count > 0)
            {
                foreach (Rescuer teamLeader in _TeamLeaders)
                    items.Add(new ComboBoxItem { Text = teamLeader.Name, Value = teamLeader.Id });

                //Add Other choice
                items.Add(new ComboBoxItem { Text = "Other", Value = ConstantsClass.OtherIdTeamLeader });

                //Bind the combo box to the list
                ddlTeamLeader.DisplayMember = "Text";
                ddlTeamLeader.ValueMember = "Value";
                ddlTeamLeader.DataSource = items;
                ddlTeamLeader.SelectedIndex = -1;
            }
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
            DateTime from = new DateTime(_CurrentDateTimeSetter.Year, _CurrentDateTimeSetter.Month, _CurrentDateTimeSetter.Day, 0, 0, 0);
            DateTime to = new DateTime(_CurrentDateTimeSetter.Year, _CurrentDateTimeSetter.Month, _CurrentDateTimeSetter.Day, 23, 59, 59);

            ShiftReport shiftReport = OperationsBlo.GetSpecificShiftReport(from, to);

            if (shiftReport != null)
            {
                cb476.Checked = shiftReport.IsDamaged476;
                cb477.Checked = shiftReport.IsDamaged477;
                cb478.Checked = shiftReport.IsDamaged478;
                cb479.Checked = shiftReport.IsDamaged479;
                cb480.Checked = shiftReport.IsDamaged480;
                cb443.Checked = shiftReport.IsDamaged443;
                nuSoinAuCentre.Value = (decimal)shiftReport.SoinAuCentre;
                nuRescuerNumber.Value = (decimal)shiftReport.NumberOfRescuers;
                nuTeamNumber.Value = (decimal)shiftReport.NumberOfTeams;
                bool teamLeaderFound = false;
                foreach (Rescuer teamLeader in _TeamLeaders)
                {
                    if (teamLeader.Id == (int)shiftReport.IdTeamLeader)
                        teamLeaderFound = true;
                }

                if (teamLeaderFound)
                    ddlTeamLeader.SelectedValue = (int)shiftReport.IdTeamLeader;

                txtNotes.Text = shiftReport.Notes;
            }
            else
            {
                cb476.Checked = false;
                cb477.Checked = false;
                cb478.Checked = false;
                cb479.Checked = false;
                cb480.Checked = false;
                cb443.Checked = false;
                nuRescuerNumber.Value = 0;
                nuTeamNumber.Value = 0;
                ddlTeamLeader.SelectedValue = -1;
                txtNotes.Text = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShiftReport shiftReport;
            bool thereIsMissingInfo = false;
            int idTeamLeader = 0, numberOfRescuers = 0, numberOfTeams = 0, soinAuCentre = 0;

            while (thereIsMissingInfo == false)
            {
                int.TryParse(ddlTeamLeader.SelectedValue.ToString(), out idTeamLeader);
                if (idTeamLeader == -1)
                {
                    thereIsMissingInfo = true;
                    break;
                }

                int.TryParse(nuRescuerNumber.Value.ToString(), out numberOfRescuers);
                if (numberOfRescuers < 3)
                {
                    thereIsMissingInfo = true;
                    break;
                }

                int.TryParse(nuTeamNumber.Value.ToString(), out numberOfTeams);
                if (numberOfTeams < 1)
                {
                    thereIsMissingInfo = true;
                    break;
                }

                //Should break by default, so it goes one time through the loop
                break;
            }

            //bkassine - ghabbatieh (youssef naser) - cervical trauma

            int.TryParse(nuSoinAuCentre.Value.ToString(), out soinAuCentre);

            if (thereIsMissingInfo == false)
            {
                //If no missing Info, Add/Update shift report record
                shiftReport = new ShiftReport();
                shiftReport.ShiftDate = _CurrentDateTimeSetter;
                shiftReport.IsDamaged476 = cb476.Checked;
                shiftReport.IsDamaged477 = cb477.Checked;
                shiftReport.IsDamaged478 = cb478.Checked;
                shiftReport.IsDamaged479 = cb479.Checked;
                shiftReport.IsDamaged480 = cb480.Checked;
                shiftReport.IsDamaged443 = cb443.Checked;
                shiftReport.SoinAuCentre = soinAuCentre;
                shiftReport.NumberOfRescuers = numberOfRescuers;
                shiftReport.NumberOfTeams = numberOfTeams;
                shiftReport.IdTeamLeader = idTeamLeader;
                shiftReport.Notes = txtNotes.Text.Trim();

                OperationsBlo.AddOrUpdateShiftReport(shiftReport);

                //Close the form
                this.Close();
            }
            else MessageBox.Show("الرجاء تعبئة كل المعلومات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
