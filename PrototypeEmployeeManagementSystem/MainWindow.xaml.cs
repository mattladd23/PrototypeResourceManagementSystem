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

namespace PrototypeEmployeeManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instantiate manager class
        private Manager manager = new Manager();
        public MainWindow()
        {
            InitializeComponent();
            statusReport.Text = manager.StatusReport;
        }

        // Event handler for an employee completing a shift
        private void WorkShift_Click(object sender, RoutedEventArgs e)
        {
            manager.WorkNextShift();
            statusReport.Text = manager.StatusReport;
        }

        // Event handler for an employee being assinged a job
        private void AssignJob_Click(object sender, RoutedEventArgs e)
        {
            manager.AssignEmployee(jobSelector.Text);
            statusReport.Text = manager.StatusReport;
        }
    }
}
