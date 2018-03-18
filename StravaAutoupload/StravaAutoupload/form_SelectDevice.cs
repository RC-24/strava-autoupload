using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StravaAutoupload {
    public partial class Form_SelectDevice : Form {
        private IList<DriveInfo> _connectedDevices;
        private DriveInfo _selectedDevice;

        public Form_SelectDevice(IList<DriveInfo> connectedDevices) {
            InitializeComponent();

            this._connectedDevices = connectedDevices;
            this.Text = "Strava Autoupload - Select Device";
            this.Height = 400;
            this.Width = 300;

            label.Text = "Select your Device:";
            label.Left = (this.Width / 2) - (label.Width / 2);

            AddButtonsWithDeviceNames();
        }

        private void AddButtonsWithDeviceNames() {
            int currentIndex = 0;

            foreach(DriveInfo connectedDevice in _connectedDevices) {
                Button b = new Button();
                b.Text = String.Format("{0} ({1})", connectedDevice.VolumeLabel, connectedDevice.Name);
                b.Width = 100;
                b.Height = 20;
                b.Top = 30 + (30 * currentIndex);
                b.Left = (this.Width / 2) - (label.Width / 2);
                b.Click += deviceButton_Click;
                this.Controls.Add(b);
                currentIndex++;
            }
        }

        public DriveInfo GetSelectedDevice() {
            return _selectedDevice;
        }

        private void deviceButton_Click(object sender, EventArgs e) {
            Button selectedButton = (Button)sender;
            string driveName = selectedButton.Text.Substring(selectedButton.Text.Length - 4, 3);

            _selectedDevice = _connectedDevices.First(d => d.Name == driveName);
            this.Dispose();
        }
    }
}
