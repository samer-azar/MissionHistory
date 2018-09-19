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
    public partial class PostInjuries : Form
    {
        #region GLOBAL_VARIABLES

        int _MissionId;

        #endregion

        #region CONSTRUCTORS

        public PostInjuries()
        {
            InitializeComponent();
        }

        public PostInjuries(Mission CurrentMission)
        {
            InitializeComponent();
            nuNumberOfInjured.Value = (decimal)CurrentMission.NumberOfInjuries;
            _MissionId = CurrentMission.ID;
        }

        #endregion

        #region METHODS
                
        private void btnAddNumberOfInjured_Click(object sender, EventArgs e)
        {
            OperationsBlo.UpdateNumberOfInjured(_MissionId, (int)nuNumberOfInjured.Value);
            this.Close();
        }

        #endregion

    }
}
