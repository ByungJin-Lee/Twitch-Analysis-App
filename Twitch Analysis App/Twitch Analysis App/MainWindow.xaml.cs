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
using Twitch_Analysis_App.ViewModels;
using Twitch_Analysis_App.Views;

namespace Twitch_Analysis_App
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void clickTabButton(object sender, RoutedEventArgs e)
        {            
            switch((sender as RadioButton).Content)
            {
                case "Twitch Analysis":
                    DataContext = new AnalysisView();
                    break;
                case "Configuration":
                    DataContext = new ConfigurationView();
                    break;
                case "Download":
                    DataContext = new DownloadView();
                    break;
            }            
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimizeClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
