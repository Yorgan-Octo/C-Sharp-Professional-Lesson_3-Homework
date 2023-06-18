using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
        IsolatedStorageFileStream userStream;
        private void CrieteFileButtin_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream($"{NameFile.Text}.{ExtensionFile.Text}", FileMode.Create, userStorage);

            using (StreamWriter userWriter = new StreamWriter(userStream))
            {
                userWriter.WriteLine(ContentFile.Text);
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {

            string[] files = userStorage.GetFileNames($"{NameFile.Text}.{ExtensionFile.Text}");

            if (files.Length == 0)
            {
                ContentFile.Text = "No data saved for this user";
            }
            else
            {
                // Прочитати дані з потоку.
                userStream = new IsolatedStorageFileStream($"{NameFile.Text}.{ExtensionFile.Text}", FileMode.Open, userStorage);

                using (StreamReader userReader = new StreamReader(userStream))
                {
                    ContentFile.Text = userReader.ReadToEnd();
                }

            }

        }

    }
}
