namespace MissionHistory.View
{
    partial class PhoneBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoneBook));
            this.tcCategories = new System.Windows.Forms.TabControl();
            this.tpRescuers = new System.Windows.Forms.TabPage();
            this.grdRescuers = new System.Windows.Forms.DataGridView();
            this.tpStations = new System.Windows.Forms.TabPage();
            this.grdStations = new System.Windows.Forms.DataGridView();
            this.tpHospitals = new System.Windows.Forms.TabPage();
            this.grdHospitals = new System.Windows.Forms.DataGridView();
            this.tpNursingHomes = new System.Windows.Forms.TabPage();
            this.grdNursingHomes = new System.Windows.Forms.DataGridView();
            this.tpBts = new System.Windows.Forms.TabPage();
            this.grdBts = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tcCategories.SuspendLayout();
            this.tpRescuers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRescuers)).BeginInit();
            this.tpStations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStations)).BeginInit();
            this.tpHospitals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHospitals)).BeginInit();
            this.tpNursingHomes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNursingHomes)).BeginInit();
            this.tpBts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBts)).BeginInit();
            this.SuspendLayout();
            // 
            // tcCategories
            // 
            this.tcCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcCategories.Controls.Add(this.tpRescuers);
            this.tcCategories.Controls.Add(this.tpStations);
            this.tcCategories.Controls.Add(this.tpHospitals);
            this.tcCategories.Controls.Add(this.tpNursingHomes);
            this.tcCategories.Controls.Add(this.tpBts);
            this.tcCategories.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcCategories.Location = new System.Drawing.Point(18, 77);
            this.tcCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcCategories.Name = "tcCategories";
            this.tcCategories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tcCategories.RightToLeftLayout = true;
            this.tcCategories.SelectedIndex = 0;
            this.tcCategories.Size = new System.Drawing.Size(880, 514);
            this.tcCategories.TabIndex = 33;
            this.tcCategories.SelectedIndexChanged += new System.EventHandler(this.tcCategories_SelectedIndexChanged);
            // 
            // tpRescuers
            // 
            this.tpRescuers.Controls.Add(this.grdRescuers);
            this.tpRescuers.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpRescuers.Location = new System.Drawing.Point(4, 36);
            this.tpRescuers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpRescuers.Name = "tpRescuers";
            this.tpRescuers.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpRescuers.Size = new System.Drawing.Size(872, 474);
            this.tpRescuers.TabIndex = 0;
            this.tpRescuers.Text = "مسعفين";
            this.tpRescuers.UseVisualStyleBackColor = true;
            // 
            // grdRescuers
            // 
            this.grdRescuers.AllowUserToAddRows = false;
            this.grdRescuers.AllowUserToDeleteRows = false;
            this.grdRescuers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRescuers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdRescuers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdRescuers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRescuers.Location = new System.Drawing.Point(9, 9);
            this.grdRescuers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdRescuers.MultiSelect = false;
            this.grdRescuers.Name = "grdRescuers";
            this.grdRescuers.ReadOnly = true;
            this.grdRescuers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdRescuers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRescuers.Size = new System.Drawing.Size(850, 448);
            this.grdRescuers.TabIndex = 1;
            // 
            // tpStations
            // 
            this.tpStations.Controls.Add(this.grdStations);
            this.tpStations.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpStations.Location = new System.Drawing.Point(4, 36);
            this.tpStations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpStations.Name = "tpStations";
            this.tpStations.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpStations.Size = new System.Drawing.Size(872, 474);
            this.tpStations.TabIndex = 1;
            this.tpStations.Text = "مراكز";
            this.tpStations.UseVisualStyleBackColor = true;
            // 
            // grdStations
            // 
            this.grdStations.AllowUserToAddRows = false;
            this.grdStations.AllowUserToDeleteRows = false;
            this.grdStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdStations.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStations.Location = new System.Drawing.Point(9, 9);
            this.grdStations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdStations.MultiSelect = false;
            this.grdStations.Name = "grdStations";
            this.grdStations.ReadOnly = true;
            this.grdStations.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStations.Size = new System.Drawing.Size(850, 448);
            this.grdStations.TabIndex = 2;
            // 
            // tpHospitals
            // 
            this.tpHospitals.Controls.Add(this.grdHospitals);
            this.tpHospitals.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHospitals.Location = new System.Drawing.Point(4, 36);
            this.tpHospitals.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpHospitals.Name = "tpHospitals";
            this.tpHospitals.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpHospitals.Size = new System.Drawing.Size(872, 474);
            this.tpHospitals.TabIndex = 2;
            this.tpHospitals.Text = "مستشفيات";
            this.tpHospitals.UseVisualStyleBackColor = true;
            // 
            // grdHospitals
            // 
            this.grdHospitals.AllowUserToAddRows = false;
            this.grdHospitals.AllowUserToDeleteRows = false;
            this.grdHospitals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdHospitals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdHospitals.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdHospitals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHospitals.Location = new System.Drawing.Point(9, 9);
            this.grdHospitals.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdHospitals.MultiSelect = false;
            this.grdHospitals.Name = "grdHospitals";
            this.grdHospitals.ReadOnly = true;
            this.grdHospitals.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdHospitals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdHospitals.Size = new System.Drawing.Size(850, 448);
            this.grdHospitals.TabIndex = 2;
            this.grdHospitals.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHospitals_CellDoubleClick);
            // 
            // tpNursingHomes
            // 
            this.tpNursingHomes.Controls.Add(this.grdNursingHomes);
            this.tpNursingHomes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpNursingHomes.Location = new System.Drawing.Point(4, 36);
            this.tpNursingHomes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpNursingHomes.Name = "tpNursingHomes";
            this.tpNursingHomes.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpNursingHomes.Size = new System.Drawing.Size(872, 474);
            this.tpNursingHomes.TabIndex = 3;
            this.tpNursingHomes.Text = "دور عجزة";
            this.tpNursingHomes.UseVisualStyleBackColor = true;
            // 
            // grdNursingHomes
            // 
            this.grdNursingHomes.AllowUserToAddRows = false;
            this.grdNursingHomes.AllowUserToDeleteRows = false;
            this.grdNursingHomes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdNursingHomes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdNursingHomes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdNursingHomes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNursingHomes.Location = new System.Drawing.Point(9, 9);
            this.grdNursingHomes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdNursingHomes.MultiSelect = false;
            this.grdNursingHomes.Name = "grdNursingHomes";
            this.grdNursingHomes.ReadOnly = true;
            this.grdNursingHomes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdNursingHomes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdNursingHomes.Size = new System.Drawing.Size(850, 448);
            this.grdNursingHomes.TabIndex = 2;
            // 
            // tpBts
            // 
            this.tpBts.Controls.Add(this.grdBts);
            this.tpBts.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpBts.Location = new System.Drawing.Point(4, 36);
            this.tpBts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpBts.Name = "tpBts";
            this.tpBts.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpBts.Size = new System.Drawing.Size(872, 474);
            this.tpBts.TabIndex = 4;
            this.tpBts.Text = "مراكز نقل دم";
            this.tpBts.UseVisualStyleBackColor = true;
            // 
            // grdBts
            // 
            this.grdBts.AllowUserToAddRows = false;
            this.grdBts.AllowUserToDeleteRows = false;
            this.grdBts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdBts.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdBts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBts.Location = new System.Drawing.Point(9, 9);
            this.grdBts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdBts.MultiSelect = false;
            this.grdBts.Name = "grdBts";
            this.grdBts.ReadOnly = true;
            this.grdBts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdBts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBts.Size = new System.Drawing.Size(850, 448);
            this.grdBts.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(734, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 37);
            this.label3.TabIndex = 300;
            this.label3.Text = "الاسم";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(207, 18);
            this.txtNameSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNameSearch.Size = new System.Drawing.Size(516, 33);
            this.txtNameSearch.TabIndex = 11;
            this.txtNameSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNameSearch_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.LightBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(24, 18);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 38);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // PhoneBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 609);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNameSearch);
            this.Controls.Add(this.tcCategories);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PhoneBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhoneBook";
            this.tcCategories.ResumeLayout(false);
            this.tpRescuers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRescuers)).EndInit();
            this.tpStations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStations)).EndInit();
            this.tpHospitals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHospitals)).EndInit();
            this.tpNursingHomes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNursingHomes)).EndInit();
            this.tpBts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcCategories;
        private System.Windows.Forms.TabPage tpRescuers;
        private System.Windows.Forms.TabPage tpStations;
        private System.Windows.Forms.TabPage tpHospitals;
        private System.Windows.Forms.TabPage tpNursingHomes;
        private System.Windows.Forms.TabPage tpBts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grdRescuers;
        private System.Windows.Forms.DataGridView grdStations;
        private System.Windows.Forms.DataGridView grdHospitals;
        private System.Windows.Forms.DataGridView grdNursingHomes;
        private System.Windows.Forms.DataGridView grdBts;
    }
}