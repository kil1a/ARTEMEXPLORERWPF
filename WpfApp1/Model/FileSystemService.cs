using System.Windows;
using System.IO;
using System;
using System.Diagnostics;

namespace WpfApp1.Model
{
    internal class FileSystemService
    {
        static UCDrive UserControlDrive = new UCDrive();

        static public string CurrentDirectory = "";
        static public bool SelectDrive = false;
        static public void GetFilesInDirectory()
        {
            if (SelectDrive == false)
            {
                foreach (DriveInfo drive in UserControlDrive.getDrive())
                    ((MainWindow)Application.Current.MainWindow).AddToWrap(drive.Name, "drive");
                SelectDrive = true;
            }
            else
            {
                string[] directories = Directory.GetDirectories(CurrentDirectory);
                foreach (string directory in directories)
                {
                    string directoryName = Path.GetFileName(directory);
                    ((MainWindow)Application.Current.MainWindow).AddToWrap(directoryName, "folder");
                }

                string[] files = Directory.GetFiles(CurrentDirectory);
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    ((MainWindow)Application.Current.MainWindow).AddToWrap(fileName, "file");
                }
            }
        }

        static public void GoToParentDirectory()
        {
            ((MainWindow)Application.Current.MainWindow).Wrap.Children.Clear();
            string parentDirectoryPath = Directory.GetParent(CurrentDirectory)?.FullName;

            if (parentDirectoryPath != null)
            {
                CurrentDirectory = parentDirectoryPath;
                GetFilesInDirectory();
            }
            else
            {
                SelectDrive = false;
                GetFilesInDirectory();
            }
        }

        static public void OpenDirectory(string Name)
        {
            SelectDrive = true;
            try
            {

            ((MainWindow)Application.Current.MainWindow).Wrap.Children.Clear();
            string folderName = Name;
            string currentPath = CurrentDirectory;
            string newFolderPath = Path.Combine(currentPath, folderName);
            CurrentDirectory = newFolderPath;
            ((MainWindow)Application.Current.MainWindow).GetFilesInDirectory();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GetFilesInDirectory();
            }
            }

        static public void OpenFile(string Name)
        {
            try
            {
                Process.Start("notepad.exe", CurrentDirectory += $@"\{Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при открытии файла: {ex.Message}");
            }
        }

        static public void CreateFile(string Name)
        {
            File.Create($@"{CurrentDirectory}\{Name}.txt");
            ((MainWindow)Application.Current.MainWindow).Wrap.Children.Clear();
            GetFilesInDirectory();
        }

        static public void CreateFolder(string Name)
        {
            Directory.CreateDirectory($@"{CurrentDirectory}\{Name}");
            ((MainWindow)Application.Current.MainWindow).Wrap.Children.Clear();
            GetFilesInDirectory();
        }
    }
}
