using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

namespace LaunchElevated
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                Debug.WriteLine("arg: " + args[i]);

                switch (args[i])
                {
                    case "-HandleElevatedStuff":
                        //Do stuff
                        DoElevatedStuff();

                        //Suicide
                        Application.Current.Shutdown();
                        break;

                    default:
                        break;
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Relaunch the current EXE as an elevated process and pass it some argument to denote that
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Assembly.GetExecutingAssembly().Location;
            start.Arguments = "-HandleElevatedStuff";

            //The following forces the app to "run as administrator"
            start.Verb = "runas"; 

            Debug.WriteLine(start.FileName);
            Process.Start(start);
        }

        private void DoElevatedStuff()
        {
            //Microsoft.Win32.RegistryKey key;
            //string root = "Software\\DeleteMe";
            //key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(root);
            //key.SetValue("SomeString", "It worked!");
            //key.Close();
            Debug.WriteLine("Elevated stuff is do'd");
        }
    }
}
