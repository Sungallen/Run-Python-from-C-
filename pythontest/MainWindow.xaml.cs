using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace pythontest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ans = Option1();
            Pytext.Text = ans;
        }
        static string Option1()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"D:\Pycharm_file\Scripts\python.exe";

            var script = @"D:\pythonProject\Hello.py";
            var x = 5;
            var y = 1;
            psi.Arguments = $"\"{script}\" \"{x}\" \"{y}\"";

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            var error = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                error = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }
            return results;

        }
    }


}
