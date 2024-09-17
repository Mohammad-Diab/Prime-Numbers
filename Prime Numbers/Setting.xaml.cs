using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Primary_Number
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Save_Setting(object sender, RoutedEventArgs e)
        {
            if (Languages.SelectedIndex == 0)
            {
                MainWindow.Labels = MainWindow.ArLabels;
                Properties.Settings.Default.Language = false;
            }
            else
            {
                MainWindow.Labels = MainWindow.EnLabels;
                Properties.Settings.Default.Language = true;
            }
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.Title = MainWindow.Labels[9];
            Label1.Content = MainWindow.Labels[25];
            Save_Set.Content = MainWindow.Labels[26];
            Cancel1.Content = MainWindow.Labels[27];
            if (MainWindow.Labels[0][0].Equals('P'))
            {
                this.FlowDirection = FlowDirection.LeftToRight;
                Languages.SelectedIndex = 1;
            }
            else
            {
                this.FlowDirection = FlowDirection.RightToLeft;
                Languages.SelectedIndex = 0;
            }
        }
    }
}
