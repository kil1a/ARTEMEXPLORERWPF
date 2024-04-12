using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp1.Model;
using WpfApp1.UserControls;

namespace WpfApp1
{
    public partial class UCDrive : UserControl, INotifyPropertyChanged, IUserControl
    {
        public string CurrentPath = @"";

        private string _driveName;
        public string LabelDriveName
        {
            get { return _driveName; }
            set
            {
                _driveName = value;
                OnPropertyChanged("LabelDriveName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UCDrive()
        {
            InitializeComponent();
            DataContext = this;
        }

        public UCDrive(string driveName)
        {
            InitializeComponent();
            DataContext = this;
            LabelDriveName = driveName;
        }

        public void Open(object sender, EventArgs e)
        {
            FileSystemService.OpenDirectory(LabelDriveName);
        }

        public DriveInfo[] getDrive()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            return drives;
        }

        public void MouseEnterGridBG(object sender, EventArgs e)
        {
            Color background = Color.FromArgb(24, 99, 233, 219);
            grid.Background = new SolidColorBrush(background);
        }

        public void MouseLeaveGridBG(object sender, EventArgs e)
        {
            Color myColor = Color.FromArgb(0, 0, 0, 0);
            grid.Background = new SolidColorBrush(myColor);
        }
    }
}
