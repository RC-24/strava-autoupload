namespace StravaAutoupload {
    partial class Form1 {
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
            this.components = new System.ComponentModel.Container();
            this.btn_SearchForDevices = new System.Windows.Forms.Button();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 550);
            this.Controls.Add(this.btn_SearchForDevices);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_SearchForDevices;
    }
}

