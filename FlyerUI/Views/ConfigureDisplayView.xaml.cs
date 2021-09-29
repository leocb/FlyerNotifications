using System.Linq;
using System.Windows;
using WpfScreenHelper;

namespace Flyer.UI.Views
{
    /// <summary>
    /// Interaction logic for ConfigureDisplayView.xaml
    /// </summary>
    public partial class ConfigureDisplayView : Window
    {
        public ConfigureDisplayView()
        {
            InitializeComponent();

            var a = Screen.AllScreens.First();

        }
    }
}
