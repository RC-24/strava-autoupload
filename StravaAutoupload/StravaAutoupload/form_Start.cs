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
    public partial class Form_Start : Form {

        private DriveInfo _selectedDevice;
        private IList<FileInfo> _allNewActivities;
        private IList<FileInfo> _activitiesToUpload;

        public Form_Start() {
            InitializeComponent();

            FileUtils.CreateDirectoryInMyDocuments();
            ConfigureForm();
        }

        private void ConfigureForm() {
            this.Text = "Strava Autoupload";
            this.Height = 800;
            this.Width = 600;

            ConfigureSearchForDevicesButton();

            lbl_ActivityCount.Visible = false;
            lbl_NewActivitiesCount.Visible = false;
            lbl_SelectActivity.Visible = false;
            btn_UploadAll.Visible = false;
            btn_SelectActivities.Visible = false;
        }

        private void ConfigureSearchForDevicesButton() {
            btn_SearchForDevices.Text = "Search For Connected Devices";
            btn_SearchForDevices.Font = new Font("Arial", 10f);

            btn_SearchForDevices.Width = 220;
            btn_SearchForDevices.Height = 30;

            btn_SearchForDevices.Top = (int)(this.Height * 1.0 / 10.0);
            btn_SearchForDevices.Left = (this.Width / 2) - (btn_SearchForDevices.Width / 2);
        }

        private void ConfigureUploadAllButton() {
            btn_UploadAll.Text = "Upload All New Activities";
            btn_UploadAll.Font = new Font("Arial", 10f);

            btn_UploadAll.Top = lbl_SelectActivity.Top - ((lbl_SelectActivity.Bottom - lbl_SelectActivity.Top) / 2);
            btn_UploadAll.Left = lbl_SelectActivity.Right + 10;
            btn_UploadAll.Visible = true;
            btn_UploadAll.Click += Btn_UploadAll_Click;
        }

        private void Btn_UploadAll_Click(object sender, EventArgs e) {
            if (_activitiesToUpload != null) {
                _activitiesToUpload.Clear();
            }
            _activitiesToUpload = _allNewActivities;
        }

        private void ConfigureSelectActivitiesButton() {
            btn_SelectActivities.Text = "Select Activities to Upload";
            btn_SelectActivities.Font = new Font("Arial", 10f);

            btn_SelectActivities.Top = lbl_SelectActivity.Top - ((lbl_SelectActivity.Bottom - lbl_SelectActivity.Top)/2);
            btn_SelectActivities.Left = btn_UploadAll.Right + 10;
            btn_SelectActivities.Visible = true;
        }

        private void btn_SearchForDevices_Click(object sender, EventArgs e) {
            var connectedDevices = FileUtils.GetListOfConnectedDevices();

            // Prompt user to select device
            if (connectedDevices == null || connectedDevices.Count < 1) {
                MessageBox.Show("No devices detected.", "Strava Autoupload - Search for Connected Devices",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {
                ShowSelectDeviceForm(connectedDevices);
            }

            // Retrieve the activities from the device
            var allActivitiesOnDevice = GetActivitiesFromDevice();
            if (allActivitiesOnDevice == null || connectedDevices.Count < 1) {
                MessageBox.Show("No activities detected on device .", "Strava Autoupload - Search for Activities",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {
                lbl_ActivityCount.Text = String.Format("{0} ({1}) - {2} activities on device.", _selectedDevice.VolumeLabel,
                    _selectedDevice.Name, allActivitiesOnDevice.Count);
                lbl_ActivityCount.Top = (int)(this.Height * 2.0 / 10.0);
                lbl_ActivityCount.Left = (this.Width / 2) - (lbl_ActivityCount.Width / 2);
                lbl_ActivityCount.Visible = true;
            }

            // Identify all of the new activities (activities that have not been uploaded to Strava previously)
            var allNewActivities = GetNewActivitiesFromDevice(allActivitiesOnDevice);
            if (allNewActivities == null || allNewActivities.Count < 1) {
                lbl_NewActivitiesCount.Text = "No new activities detected";
                lbl_NewActivitiesCount.Top = (int)(this.Height * 3.0 / 10.0);
                lbl_NewActivitiesCount.Left = (this.Width / 2) - (lbl_NewActivitiesCount.Width / 2);
                lbl_NewActivitiesCount.Visible = true;
                return;
            }
            else {
                _allNewActivities = allNewActivities;
                lbl_NewActivitiesCount.Text = String.Format("{0} new activities detected", allNewActivities.Count);
                lbl_NewActivitiesCount.Top = (int)(this.Height * 3.0 / 10.0);
                lbl_NewActivitiesCount.Left = (this.Width / 2) - (lbl_NewActivitiesCount.Width / 2);
                lbl_NewActivitiesCount.Visible = true;
            }

            // Prompt user to either upload some activities or all activities
            lbl_SelectActivity.Text = "Select Upload Type:";
            lbl_SelectActivity.Top = (int)(this.Height * 4.0 / 10.0);
            lbl_SelectActivity.Left = (this.Width / 6) - (lbl_SelectActivity.Width / 2);
            lbl_SelectActivity.Visible = true;

            ConfigureUploadAllButton();
            ConfigureSelectActivitiesButton();
        }

        private void ShowSelectDeviceForm(IList<DriveInfo> connectedDevices) {
            Form_SelectDevice selectDeviceForm = new Form_SelectDevice(connectedDevices);
            selectDeviceForm.ShowDialog();
            _selectedDevice = selectDeviceForm.GetSelectedDevice();
            selectDeviceForm.Dispose();
        }

        private void ShowSelectActivitiesForm() {
            Form_SelectActivities selectActivitiesForm = new Form_SelectActivities(_allNewActivities);
            selectActivitiesForm.ShowDialog();
            if(_activitiesToUpload != null) {
                _activitiesToUpload.Clear();
            }
            _activitiesToUpload = selectActivitiesForm.GetActivitiesToUpload();
            selectActivitiesForm.Dispose();
        }

        private IList<FileInfo> GetActivitiesFromDevice() {
            switch (_selectedDevice.VolumeLabel.ToLower()) {
                case "garmin":
                    return FileUtils.GetAllActivitiesFromGarminDevice(_selectedDevice);
                default:
                    return null;
            }
        }

        private IList<FileInfo> GetNewActivitiesFromDevice(IList<FileInfo> allActivities) {
            switch (_selectedDevice.VolumeLabel.ToLower()) {
                case "garmin":
                    return FileUtils.GetAllNewActivitiesFromGarminDevice(allActivities);
                default:
                    return null;
            }
        }

        private void btn_SelectActivities_Click(object sender, EventArgs e) {
            ShowSelectActivitiesForm();
        }
    }
}
