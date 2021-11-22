using System;
using System.Collections.Generic;
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
using System.IO;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool key = false;
        private void ButStop(object sender, RoutedEventArgs e)
        {
            TimeTextLog("Таймер остановлен", DateTime.Now.ToString("mm.ss"));
            Zotext.Text = "";
            Potext.Text = "";
            Ootext.Text = DateTime.Now.ToString("mm.ss");
            key = false;
        }
        private void ButZ(object sender, RoutedEventArgs e)
        {
            TimeTextLog("Запуск таймера", DateTime.Now.ToString("mm.ss"));
            Zotext.Text = DateTime.Now.ToString("mm.ss");
            key = true;
        }
        private void ButP(object sender, RoutedEventArgs e)
        {
            TimeTextLog("Таймер поставлен на паузу", DateTime.Now.ToString("mm.ss"));
            if (key == true) 
            {
                Potext.Text = DateTime.Now.ToString("mm.ss");
            } 
        }
        private void TimeTextLog(string DET, string TimeT)
        {
            DateTime Time = DateTime.Now;
            using (FileStream fstream = new FileStream($"TimeLog.txt", FileMode.Append))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes($"{Time} {DET} {TimeT}\n");
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
