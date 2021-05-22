using Flyer.Bot;
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

namespace Flyer.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlyerBot courier;

        public MainWindow()
        {
            InitializeComponent();

            courier = new FlyerBot();
            Debug.WriteLine("Info: Requested Bot to login (async)");
            Task.Run(courier.Login);
        }
    }
}
