namespace MissionHistory.View
{
    partial class DailyReportEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyReportEdit));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.ddlTeamLeader = new System.Windows.Forms.ComboBox();
            this.nuRescuerNumber = new System.Windows.Forms.NumericUpDown();
            this.nuTeamNumber = new System.Windows.Forms.NumericUpDown();
            this.cb477 = new System.Windows.Forms.CheckBox();
            this.cb478 = new System.Windows.Forms.CheckBox();
            this.cb479 = new System.Windows.Forms.CheckBox();
            this.cb480 = new System.Windows.Forms.CheckBox();
            this.cb443 = new System.Windows.Forms.CheckBox();
            this.cb476 = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtCurrentDay = new System.Windows.Forms.TextBox();
            this.btnPreviousDayMissions = new System.Windows.Forms.Button();
            this.btnNextDayMissions = new System.Windows.Forms.Button();
            this.nuSoinAuCentre = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuRescuerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTeamNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoinAuCentre)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(111, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 34);
            this.btnCancel.TabIndex = 97;
            this.btnCancel.Text = "رجوع";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.LightBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(12, 450);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 34);
            this.btnSave.TabIndex = 96;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nuSoinAuCentre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.ddlTeamLeader);
            this.groupBox1.Controls.Add(this.nuRescuerNumber);
            this.groupBox1.Controls.Add(this.nuTeamNumber);
            this.groupBox1.Controls.Add(this.cb477);
            this.groupBox1.Controls.Add(this.cb478);
            this.groupBox1.Controls.Add(this.cb479);
            this.groupBox1.Controls.Add(this.cb480);
            this.groupBox1.Controls.Add(this.cb443);
            this.groupBox1.Controls.Add(this.cb476);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(335, 347);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إدخال تقرير الدوام";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Font = new System.Drawing.Font("Arial", 11F);
            this.txtNotes.Location = new System.Drawing.Point(7, 280);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNotes.Size = new System.Drawing.Size(236, 51);
            this.txtNotes.TabIndex = 105;
            // 
            // ddlTeamLeader
            // 
            this.ddlTeamLeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlTeamLeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTeamLeader.Font = new System.Drawing.Font("Arial", 11F);
            this.ddlTeamLeader.FormattingEnabled = true;
            this.ddlTeamLeader.Location = new System.Drawing.Point(7, 242);
            this.ddlTeamLeader.Name = "ddlTeamLeader";
            this.ddlTeamLeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlTeamLeader.Size = new System.Drawing.Size(236, 25);
            this.ddlTeamLeader.TabIndex = 104;
            // 
            // nuRescuerNumber
            // 
            this.nuRescuerNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuRescuerNumber.Font = new System.Drawing.Font("Arial", 11F);
            this.nuRescuerNumber.Location = new System.Drawing.Point(9, 165);
            this.nuRescuerNumber.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nuRescuerNumber.Name = "nuRescuerNumber";
            this.nuRescuerNumber.Size = new System.Drawing.Size(42, 24);
            this.nuRescuerNumber.TabIndex = 102;
            // 
            // nuTeamNumber
            // 
            this.nuTeamNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuTeamNumber.Font = new System.Drawing.Font("Arial", 11F);
            this.nuTeamNumber.Location = new System.Drawing.Point(9, 202);
            this.nuTeamNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuTeamNumber.Name = "nuTeamNumber";
            this.nuTeamNumber.Size = new System.Drawing.Size(42, 24);
            this.nuTeamNumber.TabIndex = 103;
            // 
            // cb477
            // 
            this.cb477.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb477.AutoSize = true;
            this.cb477.Font = new System.Drawing.Font("Arial", 11F);
            this.cb477.Location = new System.Drawing.Point(134, 56);
            this.cb477.Name = "cb477";
            this.cb477.Size = new System.Drawing.Size(51, 21);
            this.cb477.TabIndex = 97;
            this.cb477.Text = "٤٧٧";
            this.cb477.UseVisualStyleBackColor = true;
            // 
            // cb478
            // 
            this.cb478.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb478.AutoSize = true;
            this.cb478.Font = new System.Drawing.Font("Arial", 11F);
            this.cb478.Location = new System.Drawing.Point(0, 56);
            this.cb478.Name = "cb478";
            this.cb478.Size = new System.Drawing.Size(51, 21);
            this.cb478.TabIndex = 98;
            this.cb478.Text = "٤٧٨";
            this.cb478.UseVisualStyleBackColor = true;
            // 
            // cb479
            // 
            this.cb479.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb479.AutoSize = true;
            this.cb479.Font = new System.Drawing.Font("Arial", 11F);
            this.cb479.Location = new System.Drawing.Point(277, 79);
            this.cb479.Name = "cb479";
            this.cb479.Size = new System.Drawing.Size(51, 21);
            this.cb479.TabIndex = 99;
            this.cb479.Text = "٤٧٩";
            this.cb479.UseVisualStyleBackColor = true;
            // 
            // cb480
            // 
            this.cb480.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb480.AutoSize = true;
            this.cb480.Font = new System.Drawing.Font("Arial", 11F);
            this.cb480.Location = new System.Drawing.Point(134, 79);
            this.cb480.Name = "cb480";
            this.cb480.Size = new System.Drawing.Size(51, 21);
            this.cb480.TabIndex = 100;
            this.cb480.Text = "٤٨٠";
            this.cb480.UseVisualStyleBackColor = true;
            // 
            // cb443
            // 
            this.cb443.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb443.AutoSize = true;
            this.cb443.Font = new System.Drawing.Font("Arial", 11F);
            this.cb443.Location = new System.Drawing.Point(0, 79);
            this.cb443.Name = "cb443";
            this.cb443.Size = new System.Drawing.Size(51, 21);
            this.cb443.TabIndex = 101;
            this.cb443.Text = "٤٤٣";
            this.cb443.UseVisualStyleBackColor = true;
            // 
            // cb476
            // 
            this.cb476.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb476.AutoSize = true;
            this.cb476.Font = new System.Drawing.Font("Arial", 11F);
            this.cb476.Location = new System.Drawing.Point(277, 56);
            this.cb476.Name = "cb476";
            this.cb476.Size = new System.Drawing.Size(51, 21);
            this.cb476.TabIndex = 96;
            this.cb476.Text = "٤٧٦";
            this.cb476.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label33.Font = new System.Drawing.Font("Arial", 11F);
            this.label33.Location = new System.Drawing.Point(249, 279);
            this.label33.Name = "label33";
            this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label33.Size = new System.Drawing.Size(82, 20);
            this.label33.TabIndex = 110;
            this.label33.Text = "ملاحظات";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label32.Font = new System.Drawing.Font("Arial", 11F);
            this.label32.Location = new System.Drawing.Point(249, 242);
            this.label32.Name = "label32";
            this.label32.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label32.Size = new System.Drawing.Size(82, 21);
            this.label32.TabIndex = 109;
            this.label32.Text = "مسؤول الدوام";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label31.Font = new System.Drawing.Font("Arial", 11F);
            this.label31.Location = new System.Drawing.Point(57, 202);
            this.label31.Name = "label31";
            this.label31.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label31.Size = new System.Drawing.Size(274, 20);
            this.label31.TabIndex = 108;
            this.label31.Text = "عدد الفرق";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label30.Font = new System.Drawing.Font("Arial", 11F);
            this.label30.Location = new System.Drawing.Point(57, 165);
            this.label30.Name = "label30";
            this.label30.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label30.Size = new System.Drawing.Size(274, 20);
            this.label30.TabIndex = 107;
            this.label30.Text = "عدد المسعفين";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label29.Font = new System.Drawing.Font("Arial", 11F);
            this.label29.Location = new System.Drawing.Point(9, 32);
            this.label29.Name = "label29";
            this.label29.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label29.Size = new System.Drawing.Size(323, 21);
            this.label29.TabIndex = 106;
            this.label29.Text = "السيارات الغير صالحة للسير";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrentDay
            // 
            this.txtCurrentDay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCurrentDay.Enabled = false;
            this.txtCurrentDay.Font = new System.Drawing.Font("Arial", 15F);
            this.txtCurrentDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCurrentDay.Location = new System.Drawing.Point(52, 12);
            this.txtCurrentDay.Multiline = true;
            this.txtCurrentDay.Name = "txtCurrentDay";
            this.txtCurrentDay.Size = new System.Drawing.Size(256, 34);
            this.txtCurrentDay.TabIndex = 101;
            this.txtCurrentDay.TabStop = false;
            this.txtCurrentDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPreviousDayMissions
            // 
            this.btnPreviousDayMissions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPreviousDayMissions.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnPreviousDayMissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousDayMissions.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnPreviousDayMissions.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreviousDayMissions.Location = new System.Drawing.Point(314, 12);
            this.btnPreviousDayMissions.Name = "btnPreviousDayMissions";
            this.btnPreviousDayMissions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPreviousDayMissions.Size = new System.Drawing.Size(34, 34);
            this.btnPreviousDayMissions.TabIndex = 99;
            this.btnPreviousDayMissions.Text = "<";
            this.btnPreviousDayMissions.UseVisualStyleBackColor = false;
            this.btnPreviousDayMissions.Click += new System.EventHandler(this.btnPreviousDayMissions_Click);
            // 
            // btnNextDayMissions
            // 
            this.btnNextDayMissions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNextDayMissions.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnNextDayMissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextDayMissions.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnNextDayMissions.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNextDayMissions.Location = new System.Drawing.Point(12, 12);
            this.btnNextDayMissions.Name = "btnNextDayMissions";
            this.btnNextDayMissions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNextDayMissions.Size = new System.Drawing.Size(34, 34);
            this.btnNextDayMissions.TabIndex = 100;
            this.btnNextDayMissions.Text = ">";
            this.btnNextDayMissions.UseVisualStyleBackColor = false;
            this.btnNextDayMissions.Click += new System.EventHandler(this.btnNextDayMissions_Click);
            // 
            // nuSoinAuCentre
            // 
            this.nuSoinAuCentre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuSoinAuCentre.Font = new System.Drawing.Font("Arial", 11F);
            this.nuSoinAuCentre.Location = new System.Drawing.Point(10, 127);
            this.nuSoinAuCentre.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nuSoinAuCentre.Name = "nuSoinAuCentre";
            this.nuSoinAuCentre.Size = new System.Drawing.Size(42, 24);
            this.nuSoinAuCentre.TabIndex = 111;
            this.nuSoinAuCentre.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Arial", 11F);
            this.label1.Location = new System.Drawing.Point(58, 127);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(274, 20);
            this.label1.TabIndex = 112;
            this.label1.Text = "اسعاف مركز";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DailyReportEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 496);
            this.Controls.Add(this.txtCurrentDay);
            this.Controls.Add(this.btnPreviousDayMissions);
            this.Controls.Add(this.btnNextDayMissions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DailyReportEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Daily Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuRescuerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTeamNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSoinAuCentre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox ddlTeamLeader;
        private System.Windows.Forms.NumericUpDown nuRescuerNumber;
        private System.Windows.Forms.NumericUpDown nuTeamNumber;
        private System.Windows.Forms.CheckBox cb477;
        private System.Windows.Forms.CheckBox cb478;
        private System.Windows.Forms.CheckBox cb479;
        private System.Windows.Forms.CheckBox cb480;
        private System.Windows.Forms.CheckBox cb443;
        private System.Windows.Forms.CheckBox cb476;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtCurrentDay;
        private System.Windows.Forms.Button btnPreviousDayMissions;
        private System.Windows.Forms.Button btnNextDayMissions;
        private System.Windows.Forms.NumericUpDown nuSoinAuCentre;
        private System.Windows.Forms.Label label1;
    }
}