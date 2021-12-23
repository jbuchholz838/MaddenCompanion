using Infragistics.Windows.DataPresenter;
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

namespace MaddenCompanion
{
    /// <summary>
    /// Interaction logic for ActionsGrid.xaml
    /// </summary>
    public partial class ActionsDataGrid : UserControl
    {
        public ActionsDataGrid()
        {
            InitializeComponent();
        }

        public void Setup(object dataContext)
        {
            DataGrid.DataContext = dataContext;

            Binding bindSource = new Binding(".");
            DataGrid.SetBinding(XamDataGrid.DataSourceProperty, bindSource);
        }
    }
}
