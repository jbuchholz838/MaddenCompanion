using Infragistics.Windows.Controls;
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
    /// Interaction logic for PlayerDataGrid.xaml
    /// </summary>
    public partial class PlayerDataGrid : UserControl
    {

        public string TeamNameFilter { get; set; } = "";

        public PlayerDataGrid()
        {
            InitializeComponent();
        }

        public void Setup(object dataContext)
        {
            DataGrid.DataContext = dataContext;

            Binding bindSource = new Binding("Players");
            DataGrid.SetBinding(XamDataGrid.DataSourceProperty, bindSource);

            if (!String.IsNullOrEmpty(TeamNameFilter))
            {
                RecordFilter filter = new RecordFilter();
                filter.FieldName = "TeamName";

                ComparisonCondition condition = new ComparisonCondition();
                condition.Operator = ComparisonOperator.Equals;
                condition.Value = TeamNameFilter;

                filter.Conditions.Add(condition);

                DataGrid.DefaultFieldLayout.RecordFilters.Add(filter);
            }
        }
    }
}
