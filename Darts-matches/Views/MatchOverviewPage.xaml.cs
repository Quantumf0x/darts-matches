using Darts_matches.Controllers;
using System.Diagnostics;
using System.Windows.Controls;

namespace Darts_matches
{
    public partial class MatchOverviewPage : Page
    {
        public MatchOverviewPage()
        {
            InitializeComponent();


            DatabaseController dbc = DatabaseController.GetInstance();
            object[] data = dbc.PullOneFromDatabase(1);

            foreach (var item in data)
            {
                Debug.WriteLine(item);
            }
        }
    }
}
