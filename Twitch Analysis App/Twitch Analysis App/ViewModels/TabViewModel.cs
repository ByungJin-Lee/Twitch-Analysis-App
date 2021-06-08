using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Twitch_Analysis_App.ViewModels.Command;
using Twitch_Analysis_App.Views;

namespace Twitch_Analysis_App.ViewModels
{
    class TabViewModel : INotifyPropertyChanged
    {                                
        public TabViewModel()
        {
            TabCommand = new TabCommand(work, canExcuted);
        }
        public ICommand TabCommand { get; set; }

        private UserControl tab;
        public UserControl Tab
        {
            get { return tab; }
            set { if (tab != value) { tab = value; OnTabChanged("Tab"); } }
        }
        public void OnTabChanged(string property)
        {
            if(PropertyChanged != null)
            {                
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public bool canExcuted(object parmeter)
        {
            return true;
        }
        public void work(object parmeter)
        {
            if(parmeter != null)
            {
                string selected = (parmeter as RadioButton).Content.ToString();                
                switch (selected)
                {
                    case "Twitch":
                        this.Tab = new TwitchView();
                        break;
                    case "Analysis":
                        this.Tab = new AnalysisView();                        
                        break;
                    case "Configuration":
                        this.Tab =  new ConfigurationView();
                        break;
                    case "Download":
                        this.Tab = new DownloadView();
                        break;                        
                }                
            }            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
