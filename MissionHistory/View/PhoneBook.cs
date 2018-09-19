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
using MissionHistory.Helper;
using MissionHistory.BusinessLogicLayer;

namespace MissionHistory.View
{
    public partial class PhoneBook : Form
    {
        #region Constructors
        public PhoneBook()
        {
            InitializeComponent();
            LoadValues();
        }
        #endregion

        #region GlobalVariables
        List<Rescuer> _Rescuers;
        List<Station> _Stations;
        List<Hospital> _Hospitals;
        List<NursingHome> _NursingHomes;
        List<BtsCenter> _BtsCenter;
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadValues();
        }

        private void LoadValues()
        {
            string nameValue = string.Empty;
            if (!txtNameSearch.Text.Trim().Equals(string.Empty))
                nameValue = txtNameSearch.Text.Trim();

            switch (tcCategories.SelectedIndex)
            {
                case (int)Enumeration.PhoneBookTabPages.Rescuers:
                    LoadRescuers(nameValue);
                    break;
                case (int)Enumeration.PhoneBookTabPages.Stations:
                    LoadStations(nameValue);
                    break;
                case (int)Enumeration.PhoneBookTabPages.Hospitals:
                    LoadHospitals(nameValue);
                    break;
                case (int)Enumeration.PhoneBookTabPages.NursingHomes:
                    LoadNursingHomes(nameValue);
                    break;
                case (int)Enumeration.PhoneBookTabPages.Bts:
                    LoadBloodTransfusionServiceCenters(nameValue);
                    break;
            }
        }

        private void LoadRescuers(string value)
        {
            List<Rescuer> rescuerList;
            
            if (_Rescuers == null)
                _Rescuers = OperationsBlo.GetActiveRescuers();

            if (_Rescuers.Count > 0)
            {
                if (!value.Equals(string.Empty))
                {
                    rescuerList = _Rescuers.Where(a => a.Name.ToLower().Contains(value.ToLower())
                                                         || a.LastName.ToLower().Contains(value.ToLower())
                                                         || a.Nickname.ToLower().Contains(value.ToLower())).ToList();
                }
                else
                    rescuerList = _Rescuers;

                grdRescuers.DataSource = rescuerList.Select(o => new
                        {
                            Id = o.Id,
                            الإسم = o.Name + " " + o.LastName,
                            اللقب = o.Nickname,
                            رقم_الهاتف = o.PhoneNumber == string.Empty ? "-" : o.PhoneNumber,
                            رقم_الخليوي = o.MobileNumber == string.Empty ? "-" : o.MobileNumber
                        }).ToList();

                grdRescuers.Columns[0].Visible = false;
            }
        }

        private void LoadStations(string value)
        {
            List<Station> stationList;

            if (_Stations == null)
                _Stations = OperationsBlo.GetAllStations();

            if (_Stations.Count > 0)
            {
                if (!value.Equals(string.Empty))
                    stationList = _Stations.Where(a => a.Code.ToLower().Contains(value.ToLower())
                                                               || a.Name.ToLower().Contains(value.ToLower())).ToList();
                else
                    stationList  = _Stations;

                grdStations.DataSource = stationList.Select(o => new
                {
                    Id = o.ID,
                    الإسم = o.Name,
                    الرقم = o.Code,
                    رقم_الهاتف = o.PhoneNumber == string.Empty ? "-" : o.PhoneNumber
                }).ToList();

                grdStations.Columns[0].Visible = false;
            }
        }

        private void LoadHospitals(string value)
        {
            List<Hospital> hospitalList;

            if (_Hospitals == null)
                _Hospitals = OperationsBlo.GetAllHospitals();

            if (_Hospitals.Count > 0)
            {
                if (!value.Equals(string.Empty))
                    hospitalList = _Hospitals.Where(a => a.Name.ToLower().Contains(value.ToLower())
                                                                || a.NameArabic.ToLower().Contains(value.ToLower())
                                                                || a.Code.ToLower().Contains(value.ToLower())).ToList();
                else
                    hospitalList = _Hospitals;

                grdHospitals.DataSource = hospitalList.Select(o => new
                {
                    Id = o.Id,
                    الإسم = o.Name + " - " + o.NameArabic,
                    اللقب = o.Code,
                    رقم_الهاتف = o.PhoneNumber1 == string.Empty ? "" : o.PhoneNumber1 + o.PhoneNumber2 == string.Empty ? "" : " - " + o.PhoneNumber2
                }).ToList();

                grdHospitals.Columns[0].Visible = false;
            }
        }

        private void LoadNursingHomes(string value)
        {
            List<NursingHome> nursingHomeList;

            if (_NursingHomes == null)
                _NursingHomes = OperationsBlo.GetAllNursingHomes();

            if (_NursingHomes.Count > 0)
            {
                if (!value.Equals(string.Empty))
                    nursingHomeList = _NursingHomes.Where(a => a.Name.ToLower().Contains(value.ToLower())).ToList();
                else
                    nursingHomeList = _NursingHomes;

                grdNursingHomes.DataSource = nursingHomeList.Select(o => new
                {
                    Id = o.Id,
                    الإسم = o.Name,
                    رقم_الهاتف = o.PhoneNumber == string.Empty ? "-" : o.PhoneNumber
                }).ToList();

                grdNursingHomes.Columns[0].Visible = false;
            }
        }

        private void LoadBloodTransfusionServiceCenters(string value)
        {
            List<BtsCenter> btsCenterList;

            if (_BtsCenter == null)
                _BtsCenter = OperationsBlo.GetAllBtsCenters();

            if (_BtsCenter.Count > 0)
            {
                if (!value.Equals(string.Empty))
                    btsCenterList = _BtsCenter.Where(a => a.Name.ToLower().Contains(value.ToLower())
                                                           || a.Code.ToLower().Contains(value.ToLower())).ToList();
                else
                    btsCenterList = _BtsCenter;

                grdBts.DataSource = btsCenterList.Select(o => new
                {
                    Id = o.ID,
                    الإسم = o.Name,
                    الرقم = o.Code == string.Empty ? "-" : o.Code,
                    رقم_الهاتف = o.PhoneNumber == string.Empty ? "-" : o.PhoneNumber
                }).ToList();

                grdBts.Columns[0].Visible = false;
            }
        }

        private void txtNameSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                LoadValues();
        }

        private void tcCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNameSearch.Text = string.Empty;
            LoadValues();
        }

        private void grdHospitals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex, idHospital;
            DataGridView grdHospitals = (DataGridView)sender;
            selectedRowIndex = grdHospitals.SelectedRows[0].Index;
            int.TryParse(grdHospitals.Rows[selectedRowIndex].Cells["ID"].FormattedValue.ToString(), out idHospital);

            var selectedHospital = _Hospitals.Where(a => a.Id == idHospital).First();

            if (selectedHospital.Latitude != string.Empty && selectedHospital.Latitude != null)
            {
                Map mapForm = new Map(selectedHospital);
                mapForm.Show();
            }
            else
                MessageBox.Show(MessageConstants.MapCoordinatesNotAvailable, "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
