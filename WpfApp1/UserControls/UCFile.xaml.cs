using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using WpfApp1.Model;
using WpfApp1.UserControls;
namespace WpfApp1
{
    public partial class UCFile : System.Windows.Controls.UserControl, INotifyPropertyChanged, IUserControl
    {
        private string _labelText = "";
        public string LabelFileName
        {
            get { return _labelText; }
            set
            {
                if (_labelText != value)
                {
                    _labelText = value;
                    OnPropertyChanged("LabelText");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Open(object o, EventArgs e)
        {
            FileSystemService.OpenFile(LabelFileName);
        }

        public void MouseEnterGridBG(object o, EventArgs e)
        {
            Color background = Color.FromArgb(24, 99, 233, 219);
            grid.Background = new SolidColorBrush(background);
        }

        public void MouseLeaveGridBG(object o, EventArgs e)
        {
            Color myColor = Color.FromArgb(0, 0, 0, 0);
            grid.Background = new SolidColorBrush(myColor);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UCFile()
        {
            InitializeComponent();
            DataContext = this;
        }

        public UCFile(string FileName)
        {
            InitializeComponent();
            DataContext = this;
            LabelFileName = FileName;
        }


    }
}
