namespace MissionHistory
{
    partial class Operations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Operations));
            this.grdCurrentMissions = new System.Windows.Forms.DataGridView();
            this.grdDayMissions = new System.Windows.Forms.DataGridView();
            this.gbDayMissions = new System.Windows.Forms.GroupBox();
            this.txtCurrentDay = new System.Windows.Forms.TextBox();
            this.btnPreviousDayMissions = new System.Windows.Forms.Button();
            this.btnNextDayMissions = new System.Windows.Forms.Button();
            this.btnDailyReport = new System.Windows.Forms.Button();
            this.gbCurrentMissions = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPhoneBook = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddMission = new System.Windows.Forms.Button();
            this.btnUpdateVehicleLocation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentMissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayMissions)).BeginInit();
            this.gbDayMissions.SuspendLayout();
            this.gbCurrentMissions.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCurrentMissions
            // 
            this.grdCurrentMissions.AllowUserToAddRows = false;
            this.grdCurrentMissions.AllowUserToDeleteRows = false;
            this.grdCurrentMissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCurrentMissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCurrentMissions.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdCurrentMissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCurrentMissions.Location = new System.Drawing.Point(6, 19);
            this.grdCurrentMissions.MultiSelect = false;
            this.grdCurrentMissions.Name = "grdCurrentMissions";
            this.grdCurrentMissions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdCurrentMissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCurrentMissions.Size = new System.Drawing.Size(1092, 144);
            this.grdCurrentMissions.TabIndex = 0;
            this.grdCurrentMissions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCurrentMissions_CellDoubleClick);
            // 
            // grdDayMissions
            // 
            this.grdDayMissions.AllowUserToAddRows = false;
            this.grdDayMissions.AllowUserToDeleteRows = false;
            this.grdDayMissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDayMissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdDayMissions.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdDayMissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDayMissions.Location = new System.Drawing.Point(6, 65);
            this.grdDayMissions.Name = "grdDayMissions";
            this.grdDayMissions.ReadOnly = true;
            this.grdDayMissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDayMissions.Size = new System.Drawing.Size(1093, 350);
            this.grdDayMissions.TabIndex = 1;
            this.grdDayMissions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDayMissions_CellDoubleClick);
            // 
            // gbDayMissions
            // 
            this.gbDayMissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDayMissions.Controls.Add(this.txtCurrentDay);
            this.gbDayMissions.Controls.Add(this.btnPreviousDayMissions);
            this.gbDayMissions.Controls.Add(this.btnNextDayMissions);
            this.gbDayMissions.Controls.Add(this.grdDayMissions);
            this.gbDayMissions.Font = new System.Drawing.Font("Arial", 12F);
            this.gbDayMissions.Location = new System.Drawing.Point(11, 300);
            this.gbDayMissions.Name = "gbDayMissions";
            this.gbDayMissions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbDayMissions.Size = new System.Drawing.Size(1105, 421);
            this.gbDayMissions.TabIndex = 3;
            this.gbDayMissions.TabStop = false;
            this.gbDayMissions.Text = "المهمات اليومية";
            // 
            // txtCurrentDay
            // 
            this.txtCurrentDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentDay.Enabled = false;
            this.txtCurrentDay.Font = new System.Drawing.Font("Arial", 15F);
            this.txtCurrentDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCurrentDay.Location = new System.Drawing.Point(719, 25);
            this.txtCurrentDay.Multiline = true;
            this.txtCurrentDay.Name = "txtCurrentDay";
            this.txtCurrentDay.Size = new System.Drawing.Size(340, 34);
            this.txtCurrentDay.TabIndex = 71;
            this.txtCurrentDay.TabStop = false;
            this.txtCurrentDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPreviousDayMissions
            // 
            this.btnPreviousDayMissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousDayMissions.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnPreviousDayMissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousDayMissions.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnPreviousDayMissions.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreviousDayMissions.Location = new System.Drawing.Point(1065, 25);
            this.btnPreviousDayMissions.Name = "btnPreviousDayMissions";
            this.btnPreviousDayMissions.Size = new System.Drawing.Size(34, 34);
            this.btnPreviousDayMissions.TabIndex = 60;
            this.btnPreviousDayMissions.Text = "<";
            this.btnPreviousDayMissions.UseVisualStyleBackColor = false;
            this.btnPreviousDayMissions.Click += new System.EventHandler(this.btnPreviousDayMissions_Click);
            // 
            // btnNextDayMissions
            // 
            this.btnNextDayMissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextDayMissions.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnNextDayMissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextDayMissions.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnNextDayMissions.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNextDayMissions.Location = new System.Drawing.Point(679, 25);
            this.btnNextDayMissions.Name = "btnNextDayMissions";
            this.btnNextDayMissions.Size = new System.Drawing.Size(34, 34);
            this.btnNextDayMissions.TabIndex = 61;
            this.btnNextDayMissions.Text = ">";
            this.btnNextDayMissions.UseVisualStyleBackColor = false;
            this.btnNextDayMissions.Click += new System.EventHandler(this.btnNextDayMissions_Click);
            // 
            // btnDailyReport
            // 
            this.btnDailyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDailyReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDailyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDailyReport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnDailyReport.Image = ((System.Drawing.Image)(resources.GetObject("btnDailyReport.Image")));
            this.btnDailyReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDailyReport.Location = new System.Drawing.Point(703, 12);
            this.btnDailyReport.Name = "btnDailyReport";
            this.btnDailyReport.Size = new System.Drawing.Size(132, 81);
            this.btnDailyReport.TabIndex = 65;
            this.btnDailyReport.Text = "التقرير اليومي";
            this.btnDailyReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDailyReport.UseVisualStyleBackColor = false;
            this.btnDailyReport.Click += new System.EventHandler(this.btnDailyReport_Click);
            // 
            // gbCurrentMissions
            // 
            this.gbCurrentMissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCurrentMissions.Controls.Add(this.grdCurrentMissions);
            this.gbCurrentMissions.Font = new System.Drawing.Font("Arial", 12F);
            this.gbCurrentMissions.Location = new System.Drawing.Point(12, 113);
            this.gbCurrentMissions.Name = "gbCurrentMissions";
            this.gbCurrentMissions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbCurrentMissions.Size = new System.Drawing.Size(1104, 169);
            this.gbCurrentMissions.TabIndex = 1;
            this.gbCurrentMissions.TabStop = false;
            this.gbCurrentMissions.Text = "المهمات الحالية";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.btnPhoneBook);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnDailyReport);
            this.panel1.Controls.Add(this.btnAddMission);
            this.panel1.Controls.Add(this.btnUpdateVehicleLocation);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 107);
            this.panel1.TabIndex = 4;
            // 
            // btnPhoneBook
            // 
            this.btnPhoneBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhoneBook.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPhoneBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhoneBook.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnPhoneBook.Image = ((System.Drawing.Image)(resources.GetObject("btnPhoneBook.Image")));
            this.btnPhoneBook.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPhoneBook.Location = new System.Drawing.Point(562, 13);
            this.btnPhoneBook.Name = "btnPhoneBook";
            this.btnPhoneBook.Size = new System.Drawing.Size(132, 81);
            this.btnPhoneBook.TabIndex = 67;
            this.btnPhoneBook.Text = "دليل";
            this.btnPhoneBook.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPhoneBook.UseVisualStyleBackColor = false;
            this.btnPhoneBook.Click += new System.EventHandler(this.btnPhoneBook_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddMission
            // 
            this.btnAddMission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMission.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddMission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMission.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddMission.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMission.Image")));
            this.btnAddMission.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddMission.Location = new System.Drawing.Point(985, 12);
            this.btnAddMission.Name = "btnAddMission";
            this.btnAddMission.Size = new System.Drawing.Size(132, 81);
            this.btnAddMission.TabIndex = 6;
            this.btnAddMission.Text = "مهمة جديدة";
            this.btnAddMission.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddMission.UseVisualStyleBackColor = false;
            this.btnAddMission.Click += new System.EventHandler(this.btnAddMission_Click);
            // 
            // btnUpdateVehicleLocation
            // 
            this.btnUpdateVehicleLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateVehicleLocation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdateVehicleLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateVehicleLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateVehicleLocation.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVehicleLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateVehicleLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateVehicleLocation.Image")));
            this.btnUpdateVehicleLocation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdateVehicleLocation.Location = new System.Drawing.Point(844, 12);
            this.btnUpdateVehicleLocation.Name = "btnUpdateVehicleLocation";
            this.btnUpdateVehicleLocation.Size = new System.Drawing.Size(132, 81);
            this.btnUpdateVehicleLocation.TabIndex = 7;
            this.btnUpdateVehicleLocation.Text = "تحديث الموقع";
            this.btnUpdateVehicleLocation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdateVehicleLocation.UseVisualStyleBackColor = false;
            this.btnUpdateVehicleLocation.Click += new System.EventHandler(this.btnUpdateVehicleLocation_Click);
            // 
            // Operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbCurrentMissions);
            this.Controls.Add(this.gbDayMissions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Operations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المهمات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentMissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayMissions)).EndInit();
            this.gbDayMissions.ResumeLayout(false);
            this.gbDayMissions.PerformLayout();
            this.gbCurrentMissions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCurrentMissions;
        private System.Windows.Forms.DataGridView grdDayMissions;
        private System.Windows.Forms.Button btnAddMission;
        private System.Windows.Forms.Button btnUpdateVehicleLocation;
        private System.Windows.Forms.GroupBox gbDayMissions;
        private System.Windows.Forms.GroupBox gbCurrentMissions;
        private System.Windows.Forms.Button btnDailyReport;
        private System.Windows.Forms.TextBox txtCurrentDay;
        private System.Windows.Forms.Button btnPreviousDayMissions;
        private System.Windows.Forms.Button btnNextDayMissions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPhoneBook;
    }
}

