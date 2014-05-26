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
using System.Windows.Shapes;

namespace PrimeNumber
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window

    {
        public Info()
        {
            InitializeComponent();
        }

        private void Close_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.Title = MainWindow.Labels[11];
            Closes.Content = MainWindow.Labels[28];
            if (MainWindow.Labels[0][0].Equals('P'))
                this.FlowDirection = System.Windows.FlowDirection.LeftToRight;
            else
                this.FlowDirection = System.Windows.FlowDirection.RightToLeft;
        }

    }
}
