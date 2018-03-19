namespace StravaAutoupload {
    partial class Form_SelectActivities {
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
            this.list_Activities = new System.Windows.Forms.ListView();
            this.lbl_SelectActivities = new System.Windows.Forms.Label();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_Activities
            // 
            this.list_Activities.Location = new System.Drawing.Point(12, 96);
            this.list_Activities.Name = "list_Activities";
            this.list_Activities.Size = new System.Drawing.Size(421, 345);
            this.list_Activities.TabIndex = 0;
            this.list_Activities.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_SelectActivities
            // 
            this.lbl_SelectActivities.AutoSize = true;
            this.lbl_SelectActivities.Location = new System.Drawing.Point(72, 31);
            this.lbl_SelectActivities.Name = "lbl_SelectActivities";
            this.lbl_SelectActivities.Size = new System.Drawing.Size(131, 13);
            this.lbl_SelectActivities.TabIndex = 1;
            this.lbl_SelectActivities.Text = "Select Activities to Upload";
            // 
            // btn_Upload
            // 
            this.btn_Upload.Location = new System.Drawing.Point(171, 447);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(75, 23);
            this.btn_Upload.TabIndex = 2;
            this.btn_Upload.Text = "Upload Activities";
            this.btn_Upload.UseVisualStyleBackColor = true;
            // 
            // Form_SelectActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 488);
            this.Controls.Add(this.btn_Upload);
            this.Controls.Add(this.lbl_SelectActivities);
            this.Controls.Add(this.list_Activities);
            this.Name = "Form_SelectActivities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_SelectActivities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list_Activities;
        private System.Windows.Forms.Label lbl_SelectActivities;
        private System.Windows.Forms.Button btn_Upload;
    }
}