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
    public partial class Form_SelectActivities : Form {

        private IList<FileInfo> _allNewActivities;
        private IList<FileInfo> _activitiesToUpload = new List<FileInfo>();

        public Form_SelectActivities(IList<FileInfo> allNewActivities) {
            InitializeComponent();
            ConfigureForm();

            _allNewActivities = allNewActivities.OrderByDescending(a => a.CreationTime).ToList();
            PopulateList();
        }

        private void ConfigureForm() {
            this.Text = "Strava Autoupload - Select Activities to Upload:";

            lbl_SelectActivities.Top = (int)(this.Height * 1.0 / 10.0);
            lbl_SelectActivities.Left = (this.Width / 2) - (lbl_SelectActivities.Width / 2);

            list_Activities.Left = 0;
            list_Activities.Width = this.Width;
            list_Activities.View = View.Details;
            list_Activities.CheckBoxes = true;
            list_Activities.ItemChecked += List_Activities_ItemChecked;
            list_Activities.Columns.Add("Filename");
            list_Activities.Columns.Add("Created Date");
            list_Activities.Columns.Add("Filesize");
            list_Activities.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            list_Activities.Font = new Font("Arial", 10f);
            list_Activities.FullRowSelect = true;
            list_Activities.ItemSelectionChanged += List_Activities_ItemSelectionChanged;

            btn_Upload.Enabled = false;
            btn_Upload.Text = "Upload Activities";
            btn_Upload.Click += Btn_Upload_Click;
        }

        private void Btn_Upload_Click(object sender, EventArgs e) {
            var checkedItems = list_Activities.CheckedItems.GetEnumerator();
            while (checkedItems.MoveNext()) {
                var item = (ListViewItem) checkedItems.Current;
                _activitiesToUpload.Add(_allNewActivities.First(a => a.Name.Equals(item.Text)));
            }
            this.Close();
        }

        private void List_Activities_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.Item.Selected) {
                e.Item.Checked = !e.Item.Checked;
            }
        }

        private void List_Activities_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if(list_Activities.CheckedItems.Count == 0) {
                btn_Upload.Enabled = false;
            }
            else {
                btn_Upload.Enabled = true;
            }
        }

        private void PopulateList() {
            foreach (FileInfo file in _allNewActivities) {
                ListViewItem item = new ListViewItem(new String[] { file.Name, file.CreationTime.ToString(),
                    Math.Round(file.Length/(1024.0 * 1024), 2).ToString() + " MB" });
                list_Activities.Items.Add(item);
            }
            list_Activities.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            list_Activities.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public IList<FileInfo> GetActivitiesToUpload() {
            return _activitiesToUpload;
        }
    }
}
