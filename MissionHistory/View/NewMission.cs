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
using static MissionHistory.Helper.Enumeration;

namespace MissionHistory.View
{
    public partial class NewMission : Form
    {
        #region Constructor
        public NewMission()
        {
            InitializeComponent();
            FillDdlVehicles();
            FillDdlMissionCategory();
        }

        public NewMission(List<Mission> CurrentMissions)
        {
            _CurrentMissions = CurrentMissions;
            InitializeComponent();
            FillDdlVehicles();
            FillDdlMissionCategory();
        }
        #endregion

        #region Global Variables
        List<ComboBoxItem> _Items;
        List<Vehicle> _Vehicles;
        List<MissionCategory> _MissionCategories;
        List<MissionDirection> _MissionDirections;
        List<Area> _Areas;
        List<Hospital> _Hospitals;
        List<NursingHome> _NursingHomes;
        #endregion

        #region Properties
        private List<Mission> _CurrentMissions { get; set; }
        #endregion

        private void FillDdlVehicles()
        {
            ComboBoxItem item;
            if (_Vehicles == null)
                _Vehicles = OperationsBlo.GetAllVehicles();

            if (_Vehicles.Count > 0)
            {
                foreach (Vehicle vehicle in _Vehicles)
                {
                    item = new ComboBoxItem();
                    item.Text = vehicle.PlateNumber;
                    item.Value = vehicle.Id;
                    ddlVehicle.Items.Add(item);
                }
                ddlVehicle.SelectedIndex = 0;
            }
        }

        private void FillDdlMissionCategory()
        {
            ComboBoxItem item;
            if (_MissionCategories == null)
                _MissionCategories = OperationsBlo.GetMissionCategories();

            if (_MissionCategories.Count > 0)
            {
                foreach (MissionCategory missionCategory in _MissionCategories)
                {
                    item = new ComboBoxItem();
                    item.Text = missionCategory.DescriptionEnglish + " - " + missionCategory.DescriptionArabic;
                    item.Value = missionCategory.Id;
                    ddlMissionCategory.Items.Add(item);
                }
                ddlMissionCategory.SelectedIndex = 0;
            }
        }

        private void ddlMissionCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox missionCategoryComboBox = (ComboBox)sender;
            ComboBoxItem selectedmissionCategory = (ComboBoxItem)missionCategoryComboBox.SelectedItem;
            int missionCategoryId;
            int.TryParse(selectedmissionCategory.Value.ToString(), out missionCategoryId);

            FillDdlMissionDirection(missionCategoryId);
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

        private void ddlMissionDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMissionDirection;
            int directionFlag = 0;

            if (_Areas == null)
                _Areas = OperationsBlo.GetAllAreas();

            if (_Hospitals == null)
                _Hospitals = OperationsBlo.GetAllHospitals();

            if (_NursingHomes == null)
                _NursingHomes = OperationsBlo.GetAllNursingHomes();

            ComboBox selectedDirectionCategory = (ComboBox)sender;
            int.TryParse(selectedDirectionCategory.SelectedValue.ToString(), out idMissionDirection);

            var missionDirection = _MissionDirections.Where(a => a.Id == idMissionDirection).First();
            directionFlag = missionDirection.DirectionFlag;

            DirectionFlagEnum directionFlagEnum = (DirectionFlagEnum)directionFlag;

            switch (directionFlagEnum)
            {
                case DirectionFlagEnum.FromAreaToHospital:
                    FillDdlFrom(_Areas);
                    break;
                case DirectionFlagEnum.FromHospitalToHospital:
                    FillDdlFrom(_Hospitals);
                    break;
                case DirectionFlagEnum.FromHospitalToArea:
                    FillDdlFrom(_Hospitals);
                    break;
                case DirectionFlagEnum.FromAreaToArea:
                    FillDdlFrom(_Areas);
                    break;
                case DirectionFlagEnum.FromAreaToNull:
                    FillDdlFrom(_Areas);
                    break;
                case DirectionFlagEnum.FromNursingHomeToHospital:
                    FillDdlFrom(_NursingHomes);
                    break;
                case DirectionFlagEnum.FromAreaToNursingHome:
                    FillDdlFrom(_Areas);
                    break;
                case DirectionFlagEnum.FromHospitalToNursingHome:
                    FillDdlFrom(_Hospitals);
                    break;
                case DirectionFlagEnum.FromNursingHomeToNursingHome:
                    FillDdlFrom(_NursingHomes);
                    break;
            }
        }

        private void FillDdlFrom(List<Area> Areas)
        {
            if (ddlFrom.Items.Count > 0)
                ddlFrom.Items.Clear();

            ComboBoxItem item;
            if (Areas.Count > 0)
            {
                foreach (Area area in Areas)
                {
                    item = new ComboBoxItem();
                    item.Text = area.Name + " - " + area.NameArabic;
                    item.Value = area.Id;
                    ddlFrom.Items.Add(item);
                }
                ddlFrom.SelectedIndex = 0;
            }
        }

        private void FillDdlFrom(List<Hospital> Hospitals)
        {
            string hospitalName;
            if (ddlFrom.Items.Count > 0)
                ddlFrom.Items.Clear();

            ComboBoxItem item;
            if (Hospitals.Count > 0)
            {
                foreach (Hospital hospital in Hospitals)
                {
                    item = new ComboBoxItem();
                    if (hospital.Code.Equals(string.Empty))
                        hospitalName = hospital.Name;
                    else
                        hospitalName = hospital.Name + " - " + hospital.Code;
                    item.Text = hospitalName;
                    item.Value = hospital.Id;
                    ddlFrom.Items.Add(item);
                }
                ddlFrom.SelectedIndex = 0;
            }
        }

        private void FillDdlFrom(List<NursingHome> NursingHomes)
        {
            if (ddlFrom.Items.Count > 0)
                ddlFrom.Items.Clear();

            ComboBoxItem item;
            if (NursingHomes.Count > 0)
            {
                foreach (NursingHome nursingHome in NursingHomes)
                {
                    item = new ComboBoxItem();
                    item.Text = nursingHome.Name;
                    item.Value = nursingHome.Id;
                    ddlFrom.Items.Add(item);
                }
                ddlFrom.SelectedIndex = 0;
            }
        }

        private void btnAddNewMission_Click(object sender, EventArgs e)
        {
            bool isDuplicate = false;
            int idVehicle, idMissionCategory, idMissionDirection, fromMissionDirectionFlag, idFrom;

            DialogResult result = MessageBox.Show("هل فعلاً تريد جدولة مهمة جديدة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                ComboBoxItem selectedVehicleItem = (ComboBoxItem)ddlVehicle.SelectedItem;
                int.TryParse(selectedVehicleItem.Value.ToString(), out idVehicle);

                ComboBoxItem selectedMissionCategoryItem = (ComboBoxItem)ddlMissionCategory.SelectedItem;
                int.TryParse(selectedMissionCategoryItem.Value.ToString(), out idMissionCategory);

                ComboBoxItem selectedMissionDirectionItem = (ComboBoxItem)ddlMissionDirection.SelectedItem;
                int.TryParse(selectedMissionDirectionItem.Value.ToString(), out idMissionDirection);

                ComboBoxItem selectedFromItem = (ComboBoxItem)ddlFrom.SelectedItem;
                int.TryParse(selectedFromItem.Value.ToString(), out idFrom);

                fromMissionDirectionFlag = GetFromDirectionFlag(idMissionDirection);

                //Prevent adding duplicate records
                foreach (Mission mission in _CurrentMissions)
                {
                    if (mission.IdVehicle == idVehicle)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    OperationsBlo.AddNewMission(idVehicle, 1, idMissionCategory, idMissionDirection, fromMissionDirectionFlag, idFrom, DateTime.Now);

                    //Close form
                    this.Close();
                }
                else
                    MessageBox.Show(string.Format("هناك مهمة مجدولة للسيارة رقم {0} ", selectedVehicleItem.Text), "إنتباه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private int GetFromDirectionFlag(int IdMissionDirection)
        {
            MissionDirection missionDirection = _MissionDirections.Where(a => a.Id == IdMissionDirection).First();

            switch (missionDirection.DirectionFlag)
            {
                case (int)DirectionFlagEnum.FromAreaToHospital:
                    return (int)FromDirectionFlagEnum.FromArea;
                case (int)DirectionFlagEnum.FromHospitalToHospital:
                    return (int)FromDirectionFlagEnum.FromHospital;
                case (int)DirectionFlagEnum.FromHospitalToArea:
                    return (int)FromDirectionFlagEnum.FromHospital;
                case (int)DirectionFlagEnum.FromAreaToArea:
                    return (int)FromDirectionFlagEnum.FromArea;
                case (int)DirectionFlagEnum.FromAreaToNull:
                    return (int)FromDirectionFlagEnum.FromArea;
                case (int)DirectionFlagEnum.FromNursingHomeToHospital:
                    return (int)FromDirectionFlagEnum.FromNursingHome;
                case (int)DirectionFlagEnum.FromAreaToNursingHome:
                    return (int)FromDirectionFlagEnum.FromArea;
                case (int)DirectionFlagEnum.FromHospitalToNursingHome:
                    return (int)FromDirectionFlagEnum.FromHospital;
                case (int)DirectionFlagEnum.FromNursingHomeToNursingHome:
                    return (int)FromDirectionFlagEnum.FromNursingHome;
                default:
                    return (int)FromDirectionFlagEnum.FromArea;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
