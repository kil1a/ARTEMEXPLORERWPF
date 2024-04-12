using System.Windows;
using System.IO;
using System;
using WpfApp1.Model;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            GetFilesInDirectory();
        }
        int margin = 10;
        public void GetFilesInDirectory()
        {
            Wrap.Children.Clear();
            FileSystemService.GetFilesInDirectory();
        }



        public void ShowMenu(object sender, EventArgs e)
        {
            Menu.Visibility = Visibility.Visible;
        }

        public void ShowCreateMenu(object sender, EventArgs e)
        {
            Menu.Visibility = Visibility.Hidden;
            CreateMenu.Visibility = Visibility.Visible;

        }


        public void GoToParentDirectory(object sender, EventArgs e)
        {
            FileSystemService.GoToParentDirectory();
        }

        public void AddToWrap(string name, string type)
        {
            if (type == "file")
            {
                var userControl = new UCFile(name);
                userControl.Margin = new Thickness(margin);
                Wrap.Children.Add(userControl);
            }   
            if (type == "folder")
            {
                var userControl = new UCFolder(name);
                userControl.Margin = new Thickness(margin);
                Wrap.Children.Add(userControl);
            }
            else if (type == "drive")
            {
                var userControl = new UCDrive(name);
                userControl.Margin = new Thickness(margin);
                Wrap.Children.Add(userControl);
            }
        }

        public void Cancel(object sender, EventArgs E)
        {
            CreateMenu.Visibility = Visibility.Hidden;
        }

        public void CreateNewFolder(object sender, EventArgs e)
        {
            FileSystemService.CreateFolder(NewFolderName.Text);
        }
    }
}
