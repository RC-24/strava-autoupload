using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StravaAutoupload {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            ConfigureForm();
            ConfigureSearchForDevicesButton();
        }

        private void ConfigureForm() {
            this.Text = "Strava Autoupload";
            this.Height = 800;
            this.Width = 600;
        }

        private void ConfigureSearchForDevicesButton() {
            btn_SearchForDevices.Text = "Search For Connected Devices";
            btn_SearchForDevices.Font = new Font("Arial", 10f);

            btn_SearchForDevices.Width = 220;
            btn_SearchForDevices.Height = 30;

            btn_SearchForDevices.Top = (this.Height / 10);
            btn_SearchForDevices.Left = (this.Width / 2) - (btn_SearchForDevices.Width / 2);
        }

        private void btn_SearchForDevices_Click(object sender, EventArgs e) {
            MessageBox.Show("No devices detected", "Strava Autoupload - Search for Connected Devices", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


    }
}
