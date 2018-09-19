namespace MissionHistory.View
{
    partial class NewMission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMission));
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlVehicle = new System.Windows.Forms.ComboBox();
            this.ddlFrom = new System.Windows.Forms.ComboBox();
            this.ddlMissionDirection = new System.Windows.Forms.ComboBox();
            this.ddlMissionCategory = new System.Windows.Forms.ComboBox();
            this.btnAddNewMission = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(296, 9);
            this.lblTo.Name = "lblTo";
            this.lblTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTo.Size = new System.Drawing.Size(110, 24);
            this.lblTo.TabIndex = 35;
            this.lblTo.Text = "سيارة رقم";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblFrom.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(296, 129);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFrom.Size = new System.Drawing.Size(110, 24);
            this.lblFrom.TabIndex = 33;
            this.lblFrom.Text = "من";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(296, 89);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(110, 24);
            this.label11.TabIndex = 31;
            this.label11.Text = "توجه السيارة";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 50);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "نوع المهمة";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlVehicle
            // 
            this.ddlVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlVehicle.DropDownWidth = 250;
            this.ddlVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlVehicle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlVehicle.FormattingEnabled = true;
            this.ddlVehicle.Location = new System.Drawing.Point(13, 9);
            this.ddlVehicle.Name = "ddlVehicle";
            this.ddlVehicle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlVehicle.Size = new System.Drawing.Size(277, 25);
            this.ddlVehicle.TabIndex = 26;
            // 
            // ddlFrom
            // 
            this.ddlFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFrom.DropDownWidth = 300;
            this.ddlFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlFrom.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlFrom.FormattingEnabled = true;
            this.ddlFrom.Location = new System.Drawing.Point(13, 129);
            this.ddlFrom.Name = "ddlFrom";
            this.ddlFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlFrom.Size = new System.Drawing.Size(277, 25);
            this.ddlFrom.TabIndex = 29;
            // 
            // ddlMissionDirection
            // 
            this.ddlMissionDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlMissionDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMissionDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlMissionDirection.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMissionDirection.FormattingEnabled = true;
            this.ddlMissionDirection.Location = new System.Drawing.Point(13, 89);
            this.ddlMissionDirection.Name = "ddlMissionDirection";
            this.ddlMissionDirection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlMissionDirection.Size = new System.Drawing.Size(277, 25);
            this.ddlMissionDirection.TabIndex = 28;
            this.ddlMissionDirection.SelectedIndexChanged += new System.EventHandler(this.ddlMissionDirection_SelectedIndexChanged);
            // 
            // ddlMissionCategory
            // 
            this.ddlMissionCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlMissionCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMissionCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlMissionCategory.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMissionCategory.FormattingEnabled = true;
            this.ddlMissionCategory.Location = new System.Drawing.Point(13, 49);
            this.ddlMissionCategory.Name = "ddlMissionCategory";
            this.ddlMissionCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlMissionCategory.Size = new System.Drawing.Size(277, 25);
            this.ddlMissionCategory.TabIndex = 27;
            this.ddlMissionCategory.SelectedIndexChanged += new System.EventHandler(this.ddlMissionCategory_SelectedIndexChanged);
            // 
            // btnAddNewMission
            // 
            this.btnAddNewMission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewMission.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAddNewMission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewMission.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddNewMission.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewMission.Location = new System.Drawing.Point(13, 178);
            this.btnAddNewMission.Name = "btnAddNewMission";
            this.btnAddNewMission.Size = new System.Drawing.Size(88, 34);
            this.btnAddNewMission.TabIndex = 42;
            this.btnAddNewMission.Text = "جدولة";
            this.btnAddNewMission.UseVisualStyleBackColor = false;
            this.btnAddNewMission.Click += new System.EventHandler(this.btnAddNewMission_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(115, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 34);
            this.btnCancel.TabIndex = 52;
            this.btnCancel.Text = "رجوع";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(418, 230);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewMission);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.ddlMissionCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ddlMissionDirection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlFrom);
            this.Controls.Add(this.ddlVehicle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewMission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جدولة مهمة جديدة";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlVehicle;
        private System.Windows.Forms.ComboBox ddlFrom;
        private System.Windows.Forms.ComboBox ddlMissionDirection;
        private System.Windows.Forms.ComboBox ddlMissionCategory;
        private System.Windows.Forms.Button btnAddNewMission;
        private System.Windows.Forms.Button btnCancel;
    }
}