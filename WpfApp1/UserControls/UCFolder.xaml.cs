using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp1.UserControls;
using WpfApp1.Model;

namespace WpfApp1
{
    public partial class UCFolder : UserControl, INotifyPropertyChanged, IUserControl
    {
        private string _folderName;
        public string LabelFolderName
        {
            get { return _folderName; }
            set
            {
                _folderName = value;
                OnPropertyChanged("LabelFolderName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Open(object sender, EventArgs e)
        {
            FileSystemService.OpenDirectory(LabelFolderName);
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UCFolder()
        {
            InitializeComponent();
            DataContext = this;
        }

        public UCFolder(string folderName)
        {
            InitializeComponent();
            DataContext = this;
            LabelFolderName = folderName; 
        }
    }
}
