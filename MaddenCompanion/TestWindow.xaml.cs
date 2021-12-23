using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Infragistics.Windows.DockManager;
using Firebase.Database;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MaddenCompanion
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window, INotifyPropertyChanged
    {
        private MaddenExport _currentExport;
        public MaddenExport CurrentExport
        {
            get
            {
                return _currentExport;
            }
            set
            {
                _currentExport = value;
                NotifyPropertyChanged("CurrentExport");
            }
        }

        public ObservableCollection<MaddenExport> Exports = new ObservableCollection<MaddenExport>();

        public ObservableCollection<MaddenPlayerTrade> PlayerTrades = new ObservableCollection<MaddenPlayerTrade>();

        public ObservableCollection<MaddenAction> Actions = new ObservableCollection<MaddenAction>();

        public ObservableCollection<MaddenPositionStatus> PositionStatuses = new ObservableCollection<MaddenPositionStatus>();

        CollectionViewSource _teamInfoViewSource;
        CollectionViewSource _playerTradesViewSource;
        CollectionViewSource _actionsViewSource;
        CollectionViewSource _positionStatusesViewSource;

        // Load Companion Settings
        CompanionSettings settings = new CompanionSettings();
        string companionSettingsFile = @".\CompanionSettings.json";

        string firebaseURL = "";
        string firebaseSecret = "";
        string tradesFile = "";
        string actionsFile = "";
        string positionsFile = "";

        int myPlayersTabCount = 0;
        int freeAgentsTabCount = 0;
        int playersTabCount = 0;
        int tradesTabCount = 0;
        int actionsTabCount = 0;
        int positionStatusesTabCount = 0;

        string[] myUsernames = { "Domin16", "Oogrum" };
        string teamName = "Colts";

        public TestWindow()
        {
            InitializeComponent();
            LoadCompanionSettings();

            //MaddenTeamInfo info = new MaddenTeamInfo();
            //info.TeamAbbreviation = "HELLO";
            //Export.TeamInfo.Add(info);

            _teamInfoViewSource = ((CollectionViewSource)(this.FindResource("teamInfoViewSource")));
            _playerTradesViewSource = ((CollectionViewSource)(this.FindResource("playerTradesViewSource")));
            _actionsViewSource = ((CollectionViewSource)(this.FindResource("actionsViewSource")));
            _positionStatusesViewSource = ((CollectionViewSource)(this.FindResource("positionStatusesViewSource")));

            //Binding bind = new Binding("TeamInfo");
            //bind.Source = Export;

            //SetBinding(CollectionViewSource.SourceProperty, bind);
            //_teamInfoViewSource.Source = Export.TeamInfo;



            this.DataContext = this;
        }

        private void LoadCompanionSettings()
        {
            if (File.Exists(companionSettingsFile))
            {
                string settingsJSON = File.ReadAllText(companionSettingsFile);
                settings = JsonConvert.DeserializeObject<CompanionSettings>(settingsJSON);

                firebaseURL = settings.FirebaseUrl;
                firebaseSecret = settings.FirebaseSecret;
                tradesFile = settings.TradesFilePath;
                actionsFile = settings.ActionsFilePath;
                positionsFile = settings.PositionsFilePath;
            }
        }

        private async Task<JToken> DownloadData()
        {
            FirebaseClient firebase = new FirebaseClient(firebaseURL);
            var tmp = await firebase.Child("data").OnceAsync<object>();
            string json = tmp.First().Object.ToString();

            return JToken.Parse(json);
        }

        private async void LoadData()
        {
            if (CurrentExport != null)
            {
                SaveActions();
                SavePlayerTrades();
                SavePositionStatuses();
            }

            JToken rawData = await DownloadData();
            CurrentExport = new MaddenExport(rawData);

            CurrentExport.PrepareData();

            grpTabPane.Items.Clear();
            Exports.Clear();
            Exports.Add(CurrentExport);

            NotifyPropertyChanged("CurrentExport");

            LoadPlayerTrades();
            LoadActions();
            LoadPositionStatuses();
            GeneratePositionStatuses();

            _teamInfoViewSource.Source = Exports;
            _playerTradesViewSource.Source = PlayerTrades;
            _actionsViewSource.Source = Actions;
            _positionStatusesViewSource.Source = PositionStatuses;

            AddInitialGrids();
        }

        private void LoadPlayerTrades()
        {
            if (File.Exists(tradesFile))
            {
                string tradesJSON = File.ReadAllText(tradesFile);
                PlayerTrades = JsonConvert.DeserializeObject<ObservableCollection<MaddenPlayerTrade>>(tradesJSON);
            }

            if (PlayerTrades == null)
            {
                PlayerTrades = new ObservableCollection<MaddenPlayerTrade>();
            }
        }

        private void LoadActions()
        {
            if (File.Exists(actionsFile))
            {
                string actionsJSON = File.ReadAllText(actionsFile);
                Actions = JsonConvert.DeserializeObject<ObservableCollection<MaddenAction>>(actionsJSON);
            }

            if (Actions == null)
            {
                Actions = new ObservableCollection<MaddenAction>();
            }
        }

        private void LoadPositionStatuses()
        {
            if (File.Exists(positionsFile))
            {
                string positionsJSON = File.ReadAllText(positionsFile);
                PositionStatuses = JsonConvert.DeserializeObject<ObservableCollection<MaddenPositionStatus>>(positionsJSON);
            }

            if (PositionStatuses == null)
            {
                PositionStatuses = new ObservableCollection<MaddenPositionStatus>();
            }
        }

        private void GeneratePositionStatuses()
        {
            List<MaddenPlayer> players = Exports[0].Players;

            string[] positions = { "C", "CB 1", "CB 2", "DT 1", "DT 2", "FB", "FS", "HB", "K", "LE", "LG", "LOLB", "LT", "MLB", "P", "QB", "RE", "RG", "ROLB", "RT", "SS", "TE", "WR 1", "WR 2", "WR 3" };


            foreach(string position in positions)
            {
                //MaddenPositionStatus positionStatus = new MaddenPositionStatus();
                MaddenPositionStatus positionStatus = PositionStatuses.Where(ps => ps.Position == position).FirstOrDefault();

                if (positionStatus == null)
                {
                    positionStatus = new MaddenPositionStatus();
                    positionStatus.Position = position;
                    PositionStatuses.Add(positionStatus);
                }

                string actualPosition = position.Replace(" 1", "").Replace(" 2", "").Replace(" 3", "");

                positionStatus.PositionPlayers = players.Where(p => p.TeamName == teamName && p.Position == actualPosition).OrderByDescending(p => p.PlayerSchemeOvr).ToList();
                positionStatus.ProcessPlayers();
            }
        }

        private ContentPane GetPlayerGrid(string teamNameFilter = "")
        {
            PlayerDataGrid grid = new PlayerDataGrid();

            if (!String.IsNullOrEmpty(teamName))
            {
                grid.TeamNameFilter = teamNameFilter;
            }

            grid.Setup(_teamInfoViewSource);

            ContentPane pane = new ContentPane();
            pane.Content = grid;

            grpTabPane.Items.Add(pane);

            return pane;
        }

        private void AddInitialGrids()
        {
            ResetGridCounters();

            AddMyPlayersGrid();
            AddFreeAgentsGrid();
            AddPlayerGrid(2);
            AddTradesGrid();
            AddActionsGrid();
            AddPositionStatusesGrid();
        }

        private void ResetGridCounters()
        {
            myPlayersTabCount = 0;
            freeAgentsTabCount = 0;
            playersTabCount = 0;
            tradesTabCount = 0;
            actionsTabCount = 0;
            positionStatusesTabCount = 0;
        }

        private void AddMyPlayersGrid(int count = 1)
        {
            if (myPlayersTabCount == 0) myPlayersTabCount = 1;

            for (; myPlayersTabCount <= count; myPlayersTabCount++)
            {
                ContentPane pane = GetPlayerGrid(teamName);
                pane.Header = "My Players";

                if (count > 1)
                {
                    pane.Header += " " + myPlayersTabCount;
                }
            }
        }

        private void AddPlayerGrid(int count = 1)
        {
            if (playersTabCount == 0) playersTabCount = 1;

            for (; playersTabCount <= count; playersTabCount++)
            {
                ContentPane pane = GetPlayerGrid();
                pane.Header = "Players";

                if (count > 1)
                {
                    pane.Header += " " + playersTabCount;
                }
            }
        }

        private void AddFreeAgentsGrid(int count = 1)
        {
            if (freeAgentsTabCount == 0) freeAgentsTabCount = 1;

            for (; freeAgentsTabCount <= count; freeAgentsTabCount++)
            {
                ContentPane pane = GetPlayerGrid("Free Agent");
                pane.Header = "Free Agents";

                if (count > 1)
                {
                    pane.Header += " " + freeAgentsTabCount;
                }
            }
        }

        private void AddTradesGrid(int count = 1)
        {
            if (tradesTabCount == 0) tradesTabCount = 1;

            for (; tradesTabCount <= count; tradesTabCount++)
            {
                TradesDataGrid grid = new TradesDataGrid();
                grid.Setup(_playerTradesViewSource);

                ContentPane pane = new ContentPane();

                tradesTabCount++;
                pane.Header = "Trades";

                if (count > 1)
                {
                    pane.Header += " " + tradesTabCount;
                }

                pane.Content = grid;
                grpTabPane.Items.Add(pane);
            }
        }

        private void AddActionsGrid(int count = 1)
        {
            if (actionsTabCount == 0) actionsTabCount = 1;

            for (; actionsTabCount <= count; actionsTabCount++)
            {
                ActionsDataGrid grid = new ActionsDataGrid();
                grid.Setup(_actionsViewSource);

                ContentPane pane = new ContentPane();
                pane.Header = "Actions";

                if (count > 1)
                {
                    pane.Header += " " + actionsTabCount;
                }

                pane.Content = grid;
                grpTabPane.Items.Add(pane);
            }
        }

        private void AddPositionStatusesGrid(int count = 1)
        {
            if (positionStatusesTabCount == 0) positionStatusesTabCount = 1;

            for (; positionStatusesTabCount <= count; positionStatusesTabCount++)
            {
                PositionStatusesGrid grid = new PositionStatusesGrid();
                grid.Setup(_positionStatusesViewSource);

                ContentPane pane = new ContentPane();
                pane.Header = "Roster Statuses";

                if (count > 1)
                {
                    pane.Header += " " + positionStatusesTabCount;
                }

                pane.Content = grid;
                grpTabPane.Items.Add(pane);
            }
        }

        private void SavePlayerTrades()
        {
            // Export the player trades to a JSON file
            if (PlayerTrades.Count > 0)
            {
                string tradesJSON = JsonConvert.SerializeObject(PlayerTrades);

                File.WriteAllText(tradesFile, tradesJSON);
            }
        }

        private void SaveActions()
        {
            // Export the actions to a JSON file
            if (Actions.Count > 0)
            {
                string actionsJSON = JsonConvert.SerializeObject(Actions);

                File.WriteAllText(actionsFile, actionsJSON);
            }
        }

        private void SavePositionStatuses()
        {
            // Export the position statuses to a JSON file
            if (PositionStatuses.Count > 0)
            {
                string positionsJSON = JsonConvert.SerializeObject(PositionStatuses);

                File.WriteAllText(positionsFile, positionsJSON);
            }
        }

        private void menAddGrid_Click(object sender, EventArgs e)
        {
            AddPlayerGrid();
        }

        private void menLoadData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void MenDownloadData_Click(object sender, EventArgs e)
        {
            //DownloadData();
        }

        private void menPositionStatuses_Click(object sender, EventArgs e)
        {
            GeneratePositionStatuses();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SavePlayerTrades();
            SaveActions();
            SavePositionStatuses();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
