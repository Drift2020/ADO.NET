using Market.CODES;
using Market.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Market
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {





            MainWindow view = new MainWindow();

            View_Model_Index viewModel = new View_Model_Index();
            view.DataContext = viewModel;

           

            view.ShowDialog();
        
        }
    }
}
