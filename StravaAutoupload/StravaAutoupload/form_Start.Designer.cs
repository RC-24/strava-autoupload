namespace StravaAutoupload {
    partial class Form_Start {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn_SearchForDevices = new System.Windows.Forms.Button();
            this.lbl_ActivityCount = new System.Windows.Forms.Label();
            this.lbl_NewActivitiesCount = new System.Windows.Forms.Label();
            this.lbl_SelectActivity = new System.Windows.Forms.Label();
            this.btn_UploadAll = new System.Windows.Forms.Button();
            this.btn_SelectActivities = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_SearchForDevices
            // 
            this.btn_SearchForDevices.Location = new System.Drawing.Point(189, 48);
            this.btn_SearchForDevices.Name = "btn_SearchForDevices";
            this.btn_SearchForDevices.Size = new System.Drawing.Size(183, 23);
            this.btn_SearchForDevices.TabIndex = 0;
            this.btn_SearchForDevices.Text = "Search for connected devices";
            this.btn_SearchForDevices.UseVisualStyleBackColor = true;
            this.btn_SearchForDevices.Click += new System.EventHandler(this.btn_SearchForDevices_Click);
            // 
            // lbl_ActivityCount
            // 
            this.lbl_ActivityCount.AutoSize = true;
            this.lbl_ActivityCount.Location = new System.Drawing.Point(186, 88);
            this.lbl_ActivityCount.Name = "lbl_ActivityCount";
            this.lbl_ActivityCount.Size = new System.Drawing.Size(106, 13);
            this.lbl_ActivityCount.TabIndex = 1;
            this.lbl_ActivityCount.Text = "X Activities Detected";
            this.lbl_ActivityCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_NewActivitiesCount
            // 
            this.lbl_NewActivitiesCount.AutoSize = true;
            this.lbl_NewActivitiesCount.Location = new System.Drawing.Point(186, 129);
            this.lbl_NewActivitiesCount.Name = "lbl_NewActivitiesCount";
            this.lbl_NewActivitiesCount.Size = new System.Drawing.Size(131, 13);
            this.lbl_NewActivitiesCount.TabIndex = 2;
            this.lbl_NewActivitiesCount.Text = "X New Activities Detected";
            this.lbl_NewActivitiesCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_SelectActivity
            // 
            this.lbl_SelectActivity.AutoSize = true;
            this.lbl_SelectActivity.Location = new System.Drawing.Point(21, 205);
            this.lbl_SelectActivity.Name = "lbl_SelectActivity";
            this.lbl_SelectActivity.Size = new System.Drawing.Size(104, 13);
            this.lbl_SelectActivity.TabIndex = 3;
            this.lbl_SelectActivity.Text = "Select Upload Type:";
            this.lbl_SelectActivity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_UploadAll
            // 
            this.btn_UploadAll.Location = new System.Drawing.Point(134, 200);
            this.btn_UploadAll.Name = "btn_UploadAll";
            this.btn_UploadAll.Size = new System.Drawing.Size(183, 23);
            this.btn_UploadAll.TabIndex = 4;
            this.btn_UploadAll.Text = "Upload All New Activities";
            this.btn_UploadAll.UseVisualStyleBackColor = true;
            // 
            // btn_SelectActivities
            // 
            this.btn_SelectActivities.Location = new System.Drawing.Point(323, 200);
            this.btn_SelectActivities.Name = "btn_SelectActivities";
            this.btn_SelectActivities.Size = new System.Drawing.Size(183, 23);
            this.btn_SelectActivities.TabIndex = 5;
            this.btn_SelectActivities.Text = "Select Activities to Upload";
            this.btn_SelectActivities.UseVisualStyleBackColor = true;
            this.btn_SelectActivities.Click += new System.EventHandler(this.btn_SelectActivities_Click);
            // 
            // Form_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 550);
            this.Controls.Add(this.btn_SelectActivities);
            this.Controls.Add(this.btn_UploadAll);
            this.Controls.Add(this.lbl_SelectActivity);
            this.Controls.Add(this.lbl_NewActivitiesCount);
            this.Controls.Add(this.lbl_ActivityCount);
            this.Controls.Add(this.btn_SearchForDevices);
            this.Name = "Form_Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SearchForDevices;
        private System.Windows.Forms.Label lbl_ActivityCount;
        private System.Windows.Forms.Label lbl_NewActivitiesCount;
        private System.Windows.Forms.Label lbl_SelectActivity;
        private System.Windows.Forms.Button btn_UploadAll;
        private System.Windows.Forms.Button btn_SelectActivities;
    }
}

