using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PathGDE.View_model;

namespace PathGDE
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {





            MainWindow view = new MainWindow();

            View_Model_Index viewModel = new View_Model_Index();
            viewModel.End = new Action(view.End);
            viewModel.Stop = new Action(view.Stop);
            view.DataContext = viewModel;



            view.ShowDialog();

        }
    }
}
