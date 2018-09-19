namespace MissionHistory.View
{
    partial class PostInjuries
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
            this.btnAddNumberOfInjured = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.nuNumberOfInjured = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nuNumberOfInjured)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNumberOfInjured
            // 
            this.btnAddNumberOfInjured.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNumberOfInjured.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAddNumberOfInjured.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNumberOfInjured.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddNumberOfInjured.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNumberOfInjured.Location = new System.Drawing.Point(14, 12);
            this.btnAddNumberOfInjured.Name = "btnAddNumberOfInjured";
            this.btnAddNumberOfInjured.Size = new System.Drawing.Size(88, 34);
            this.btnAddNumberOfInjured.TabIndex = 44;
            this.btnAddNumberOfInjured.Text = "تأكيد";
            this.btnAddNumberOfInjured.UseVisualStyleBackColor = false;
            this.btnAddNumberOfInjured.Click += new System.EventHandler(this.btnAddNumberOfInjured_Click);
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(192, 17);
            this.lblTo.Name = "lblTo";
            this.lblTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTo.Size = new System.Drawing.Size(96, 24);
            this.lblTo.TabIndex = 43;
            this.lblTo.Text = "عدد الإصابات";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nuNumberOfInjured
            // 
            this.nuNumberOfInjured.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuNumberOfInjured.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nuNumberOfInjured.Location = new System.Drawing.Point(134, 17);
            this.nuNumberOfInjured.Name = "nuNumberOfInjured";
            this.nuNumberOfInjured.Size = new System.Drawing.Size(52, 23);
            this.nuNumberOfInjured.TabIndex = 45;
            this.nuNumberOfInjured.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PostInjuries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 61);
            this.Controls.Add(this.nuNumberOfInjured);
            this.Controls.Add(this.btnAddNumberOfInjured);
            this.Controls.Add(this.lblTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(270, 305);
            this.Name = "PostInjuries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حدد عدد الإصابات";
            ((System.ComponentModel.ISupportInitialize)(this.nuNumberOfInjured)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNumberOfInjured;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.NumericUpDown nuNumberOfInjured;
    }
}