using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
        private void date_DateValidationError(object sender, DatePickerDateValidationErrorEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Visible;
            ErrorTextBlock.Text = "Date got reverted to previous value.";

            var automationPeer = UIElementAutomationPeer.CreatePeerForElement(ErrorTextBlock);
            if (automationPeer != null)
            {
                automationPeer.RaiseAutomationEvent(AutomationEvents.LiveRegionChanged);
            }

            automationPeer?.RaiseAutomationEvent(AutomationEvents.LiveRegionChanged);
        }

        private void date_CalendarOpened(object sender, RoutedEventArgs e)
        {
            if (ErrorTextBlock != null)
            {
                ErrorTextBlock.Text = string.Empty;
                ErrorTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ErrorTextBlock != null)
            {
                ErrorTextBlock.Text = string.Empty;
                ErrorTextBlock.Visibility = Visibility.Collapsed;
            }
        }
    }
}
