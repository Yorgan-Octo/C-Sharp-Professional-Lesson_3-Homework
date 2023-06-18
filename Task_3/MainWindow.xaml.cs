using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

namespace Task_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] disk = Directory.GetLogicalDrives();
            foreach (var item in disk)
            {
                DriveBox.Items.Add(item);
            }

            DriveBox.SelectedIndex = 0;

        }

        private void DriveBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SubDrirBox.Items.Clear();

            string[] subdir = Directory.GetDirectories(DriveBox.SelectedItem as string);

            SubDrirBox.Items.Add(DriveBox.SelectedItem as string);

            foreach (var item in subdir)
            {
                SubDrirBox.Items.Add(item + @"\");
            }

            SubDrirBox.SelectedIndex = 0;


        }

        private void SkrinButton_Click(object sender, RoutedEventArgs e)
        {

            FileTextBox.Text = null;


            FileInfo file = new FileInfo($"{SubDrirBox.SelectedItem}" + $"{NameFileBox.Text}" + $".{ExtenshFileBox.Text}");



            if (file.Exists)
            {
                FileStream openFile = File.Open(file.FullName, FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader read = new StreamReader(openFile))
                {
                    FileTextBox.Text += read.ReadToEnd();
                }
                openFile.Close();
            }
            else
            {
                FileTextBox.Text = "Тут нем такого файла " + $"{SubDrirBox.SelectedItem}" + $"{NameFileBox.Text}" + $".{ExtenshFileBox.Text}";
            }

        }


        private void CompressedButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = $"{SubDrirBox.SelectedItem}" + $"{NameFileBox.Text}" + $".{ExtenshFileBox.Text}"; 

            if (File.Exists(filePath))
            {
                CompressFile(filePath);
            }
            else
            {
                MessageBox.Show("Файл не найден.");
            }
        }

        void CompressFile(string filePath)
        {
            string compressedFilePath = filePath + ".gz";

            using (var inputFileStream = new FileStream(filePath, FileMode.Open))
            using (var compressedFileStream = new FileStream(compressedFilePath, FileMode.Create))
            {
                using (var gzipStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                {
                    inputFileStream.CopyTo(gzipStream);
                }
            }

            MessageBox.Show("Файл успешно сжат. Путь к сжатому файлу: " + compressedFilePath);
        }
    }
}
