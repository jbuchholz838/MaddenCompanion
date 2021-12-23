using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.IO;

namespace MaddenCompanion
{
    public class MaddenExport : INotifyPropertyChanged
    {
        [JsonProperty("data")]
        public JToken RawData { get; set; }

        string RootNodes = "*";

        public List<MaddenPlayer> Players { get; set; } = new List<MaddenPlayer>();
        public List<MaddenPlayer> FreeAgents { get; set; } = new List<MaddenPlayer>();

        private ObservableCollection<MaddenTeamInfo> _teamInfo = new ObservableCollection<MaddenTeamInfo>();
        public ObservableCollection<MaddenTeamInfo> TeamInfo
        {
            get
            {
                return _teamInfo;
            }

            set
            {
                _teamInfo = value;
                NotifyPropertyChanged("TeamInfo");
            }
        }

        public List<MaddenTeamStandings> TeamStandings { get; set; } = new List<MaddenTeamStandings>();

        public List<MaddenPlayer> TeamPlayers { get; set; } = new List<MaddenPlayer>();

        public List<MaddenSeasonWeek> PreseasonWeeks { get; set; } = new List<MaddenSeasonWeek>();

        public List<MaddenSeasonWeek> RegularSeasonWeeks { get; set; } = new List<MaddenSeasonWeek>();

        public ObservableCollection<MaddenScoutedPlayer> ScoutedPlayers { get; set; } = new ObservableCollection<MaddenScoutedPlayer>();

        public List<MaddenDefenseStats> PlayerDefenseStats { get; set; } = new List<MaddenDefenseStats>();
        public List<MaddenKickingStats> PlayerKickingStats { get; set; } = new List<MaddenKickingStats>();
        public List<MaddenPassingStats> PlayerPassingStats { get; set; } = new List<MaddenPassingStats>();
        public List<MaddenPuntingStats> PlayerPuntingStats { get; set; } = new List<MaddenPuntingStats>();
        public List<MaddenReceivingStats> PlayerReceivingStats { get; set; } = new List<MaddenReceivingStats>();
        public List<MaddenRushingStats> PlayerRushingStats { get; set; } = new List<MaddenRushingStats>();

        public MaddenExport()
        {

        }

        public MaddenExport(JToken rawData)
        {
            RawData = rawData;
        }

        public void PrepareData()
        {
            //string rootNodes = "xbox.*";
            

            if (RawData == null)
                return;

            // Get Free Agents
            List<JToken> tokFreeAgents = RawData.SelectTokens(RootNodes + ".freeagents.*").ToList();
            foreach (JToken tokFreeAgent in tokFreeAgents)
            {
                using (JsonReader read = tokFreeAgent.CreateReader())
                {
                    MaddenPlayer freeAgent = new MaddenPlayer();
                    JsonSerializer.CreateDefault().Populate(read, freeAgent);

                    Players.Add(freeAgent);
                }
            }

            // Get League Teams
            List<JToken> tokLeagueTeams = RawData.SelectTokens(RootNodes + ".teams.*").ToList();
            foreach(JToken tokLeagueTeam in tokLeagueTeams)
            {
                using (JsonReader read = tokLeagueTeam.CreateReader())
                {
                    MaddenTeamInfo leagueTeam = new MaddenTeamInfo();
                    JsonSerializer.CreateDefault().Populate(read, leagueTeam);

                    TeamInfo.Add(leagueTeam);
                }
            }

            // Get Standings
            JToken tokTeamStandings = RawData.SelectToken(RootNodes + ".standings.teamStandingInfoList");
            if (tokTeamStandings != null)
                TeamStandings = tokTeamStandings.ToObject<List<MaddenTeamStandings>>();

            // Get Team Players
            List<JToken> tokTeamPlayers = RawData.SelectTokens(RootNodes + ".teams.*.roster.*").ToList();
            foreach (JToken tokTeamPlayer in tokTeamPlayers)
            {
                using (JsonReader read = tokTeamPlayer.CreateReader())
                {
                    //JsonSerializer.CreateDefault().Populate(read, Players);
                    string tmp = tokTeamPlayer.ToString();
                    MaddenPlayer teamPlayer = new MaddenPlayer();
                    JsonSerializer.CreateDefault().Populate(read, teamPlayer);

                    Players.Add(teamPlayer);
                }
            }
            NotifyPropertyChanged("Players");

            // Get Preseason Week Stats
            List<JToken> tokAllPreseasonWeeks = RawData.SelectTokens(RootNodes + ".week.pre.[*]").ToList();
            foreach (JToken tokPreseasonWeek in tokAllPreseasonWeeks)
            {
                if (tokPreseasonWeek.HasValues == false)
                    continue;

                MaddenSeasonWeek week = new MaddenSeasonWeek();
                week.WeekData = tokPreseasonWeek;
                week.PrepareData();
                PreseasonWeeks.Add(week);
            }

            // Get Regular Season Week Stats
            List<JToken> tokAllRegularSeasonWeeks = RawData.SelectTokens(RootNodes + ".week.reg.[*]").ToList();
            foreach (JToken tokRegularSeasonWeek in tokAllRegularSeasonWeeks)
            {
                if (tokRegularSeasonWeek.HasValues == false)
                    continue;

                MaddenSeasonWeek week = new MaddenSeasonWeek();
                week.WeekData = tokRegularSeasonWeek;
                week.PrepareData();
                RegularSeasonWeeks.Add(week);
            }

            // Get Regular Season Defense Stats
            List<JToken> tokAllRegularDefense = RawData.SelectTokens(RootNodes + ".week.reg.[*].defense.playerDefensiveStatInfoList").ToList();
            foreach (JToken tokRegularDefense in tokAllRegularDefense)
            {
                using (JsonReader read = tokRegularDefense.CreateReader())
                {
                    JsonSerializer.CreateDefault().Populate(read, PlayerDefenseStats);
                }
            }

            // Get Regular Season Kicking Stats
            List<JToken> tokAllRegularKicking = RawData.SelectTokens(RootNodes + ".week.reg.[*].kicking.playerKickingStatInfoList").ToList();
            foreach (JToken tokRegularKicking in tokAllRegularKicking)
            {
                using (JsonReader read = tokRegularKicking.CreateReader())
                {
                    JsonSerializer.CreateDefault().Populate(read, PlayerKickingStats);
                }
            }

            // Get Regular Season Passing Stats
            List<JToken> tokAllRegularPassing = RawData.SelectTokens(RootNodes + ".week.reg.[*].passing.playerPassingStatInfoList").ToList();
            foreach (JToken tokRegularPassing in tokAllRegularPassing)
            {
                using (JsonReader read = tokRegularPassing.CreateReader())
                {
                    JsonSerializer.CreateDefault().Populate(read, PlayerPassingStats);
                }
            }

            // Get Regular Season Punting Stats
            List<JToken> tokAllRegularPunting = RawData.SelectTokens(RootNodes + ".week.reg.[*].punting.playerPuntingStatInfoList").ToList();
            foreach (JToken tokRegularPunting in tokAllRegularPunting)
            {
                using (JsonReader read = tokRegularPunting.CreateReader())
                {
                    JsonSerializer.CreateDefault().Populate(read, PlayerPuntingStats);
                }
            }

            // Get Regular Season Receiving Stats
            List<JToken> tokAllRegularReceiving = RawData.SelectTokens(RootNodes + ".week.reg.[*].receiving.playerReceivingStatInfoList").ToList();
            foreach (JToken tokRegularReceiving in tokAllRegularReceiving)
            {
                using (JsonReader read = tokRegularReceiving.CreateReader())
                {
                    JsonSerializer.CreateDefault().Populate(read, PlayerReceivingStats);
                }
            }

            // Get Regular Season Rushing Stats
            List<JToken> tokAllRegularRushing = RawData.SelectTokens(RootNodes + ".week.reg.[*].rushing.playerRushingStatInfoList").ToList();
            foreach (JToken tokRegularRushing in tokAllRegularRushing)
            {
                using (JsonReader read = tokRegularRushing.CreateReader())
                {
                    JsonSerializer.CreateDefault().Populate(read, PlayerRushingStats);
                }
            }

            // Get Player's Team Name and Stats
            foreach (MaddenPlayer player in Players)
            {
                // Team Name
                MaddenTeamInfo team = TeamInfo.SingleOrDefault(t => t.TeamId == player.TeamId);

                if (team != null)
                {
                    player.TeamName = team.DisplayName;
                }
                else
                {
                    player.TeamName = "Free Agent";
                }

                // Player Stats
                player.DefenseStats = PlayerDefenseStats.Where(s => s.RosterId == player.RosterId).ToList();
                player.KickingStats = PlayerKickingStats.Where(s => s.RosterId == player.RosterId).ToList();
                player.PassingStats = PlayerPassingStats.Where(s => s.RosterId == player.RosterId).ToList();
                player.PuntingStats = PlayerPuntingStats.Where(s => s.RosterId == player.RosterId).ToList();
                player.ReceivingStats = PlayerReceivingStats.Where(s => s.RosterId == player.RosterId).ToList();
                player.RushingStats = PlayerRushingStats.Where(s => s.RosterId == player.RosterId).ToList();

            }

            // Clear Raw Data
            RawData = null;

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

    public class MaddenTeamInfo : INotifyPropertyChanged
    {
        
        private string _teamAbbreviation = "";
        [JsonProperty("abbrName")]
        public string TeamAbbreviation
        {
            get
            {
                return _teamAbbreviation;
            }

            set
            {
                _teamAbbreviation = value;
                NotifyPropertyChanged("TeamAbbreviation");
            }
        }

        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("defScheme")]
        public long DefenseScheme { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("divName")]
        public string DivisonName { get; set; }

        [JsonProperty("injuryCount")]
        public long InjuryCount { get; set; }

        [JsonProperty("logoId")]
        public long LogoId { get; set; }

        [JsonProperty("nickName")]
        public string NickName { get; set; }

        [JsonProperty("offScheme")]
        public long OffenseScheme { get; set; }

        [JsonProperty("ovrRating")]
        public long OvrRating { get; set; }

        [JsonProperty("primaryColor")]
        public long PrimaryColor { get; set; }

        [JsonProperty("secondaryColor")]
        public long SecondaryColor { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }

    public class MaddenTeamStandings
    {
        //
        // Losses, Ties and Wins
        //
        [JsonProperty("awayLosses")]
        public long LossesAway { get; set; }

        [JsonProperty("confLosses")]
        public long LossesConf { get; set; }

        [JsonProperty("divLosses")]
        public long LossesDiv { get; set; }

        [JsonProperty("homeLosses")]
        public long LossesHome { get; set; }

        [JsonProperty("totalLosses")]
        public long LossesTotal { get; set; }

        [JsonProperty("awayTies")]
        public long TiesAway { get; set; }

        [JsonProperty("confTies")]
        public long TiesConf { get; set; }

        [JsonProperty("divTies")]
        public long TiesDiv { get; set; }

        [JsonProperty("homeTies")]
        public long TiesHome { get; set; }

        [JsonProperty("totalTies")]
        public long TiesTotal { get; set; }

        [JsonProperty("awayWins")]
        public long WinsAway { get; set; }        

        [JsonProperty("confWins")]
        public long WinsConf { get; set; }

        [JsonProperty("divWins")]
        public long WinsDiv { get; set; }

        [JsonProperty("homeWins")]
        public long WinsHome { get; set; }        

        [JsonProperty("totalWins")]
        public long WinsTotal { get; set; }

        //
        //  
        //
        [JsonProperty("calendarYear")]
        public long CalendarYear { get; set; }

        [JsonProperty("capAvailable")]
        public long CapAvailable { get; set; }

        [JsonProperty("capRoom")]
        public long CapTotal { get; set; }

        [JsonProperty("capSpent")]
        public long CapSpent { get; set; }

        [JsonProperty("conferenceId")]
        public long ConferenceId { get; set; }

        [JsonProperty("conferenceName")]
        public string ConferenceName { get; set; }

        [JsonProperty("defPassYds")]
        public long DefPassYds { get; set; }

        [JsonProperty("defPassYdsRank")]
        public long DefPassYdsRank { get; set; }

        [JsonProperty("defRushYds")]
        public long DefRushYds { get; set; }

        [JsonProperty("defRushYdsRank")]
        public long DefRushYdsRank { get; set; }

        [JsonProperty("defTotalYds")]
        public long DefTotalYds { get; set; }

        [JsonProperty("defTotalYdsRank")]
        public long DefTotalYdsRank { get; set; }

        [JsonProperty("divisionId")]
        public long DivisionId { get; set; }

        [JsonProperty("divisionName")]
        public string DivisionName { get; set; }

        [JsonProperty("netPts")]
        public long NetPts { get; set; }

        [JsonProperty("offPassYds")]
        public long OffPassYdsTotal { get; set; }

        [JsonProperty("offPassYdsRank")]
        public long OffPassYdsRank { get; set; }

        [JsonProperty("offRushYds")]
        public long OffRushYdsTotal { get; set; }

        [JsonProperty("offRushYdsRank")]
        public long OffRushYdsRank { get; set; }

        [JsonProperty("offTotalYds")]
        public long OffYdsTotal { get; set; }

        [JsonProperty("offTotalYdsRank")]
        public long OffYdsRank { get; set; }

        [JsonProperty("playoffStatus")]
        public long PlayoffStatus { get; set; }

        [JsonProperty("prevRank")]
        public long PrevRank { get; set; }

        [JsonProperty("ptsAgainst")]
        public long PtsAgainstAvg { get; set; }

        [JsonProperty("ptsAgainstRank")]
        public long PtsAgainstRank { get; set; }

        [JsonProperty("ptsFor")]
        public long PtsForAvg { get; set; }

        [JsonProperty("ptsForRank")]
        public long PtsForRank { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("seasonIndex")]
        public long SeasonIndex { get; set; }

        [JsonProperty("seed")]
        public long Seed { get; set; }

        [JsonProperty("stageIndex")]
        public long StageIndex { get; set; }

        [JsonProperty("tODiff")]
        public long TurnoverDiff { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("teamName")]
        public string TeamName { get; set; }

        [JsonProperty("teamOvr")]
        public long TeamOvrRating { get; set; }

        [JsonProperty("weekIndex")]
        public long WeekIndex { get; set; }

        [JsonProperty("winLossStreak")]
        public long WinLossStreak { get; set; }

        [JsonProperty("winPct")]
        public double WinPct { get; set; }

    }

    public class MaddenSeasonWeek
    {
        public JToken WeekData { get; set; }

        public List<MaddenGame> Games { get; set; } = new List<MaddenGame>();
        public List<MaddenTeamStats> TeamStats { get; set; } = new List<MaddenTeamStats>();
        public List<MaddenDefenseStats> DefenseStats { get; set; } = new List<MaddenDefenseStats>();
        public List<MaddenKickingStats> KickingStats { get; set; } = new List<MaddenKickingStats>();
        public List<MaddenPassingStats> PassingStats { get; set; } = new List<MaddenPassingStats>();
        public List<MaddenPuntingStats> PuntingStats { get; set; } = new List<MaddenPuntingStats>();
        public List<MaddenReceivingStats> ReceivingStats { get; set; } = new List<MaddenReceivingStats>();
        public List<MaddenRushingStats> RushingStats { get; set; } = new List<MaddenRushingStats>();

        public void PrepareData()
        {

            // Get Games
            JToken tokGames = WeekData.SelectToken("schedules.gameScheduleInfoList");
            if (tokGames != null)
                Games = tokGames.ToObject<List<MaddenGame>>();

            // Get Team Stats
            JToken tokTeamStats = WeekData.SelectToken("teamstats.teamStatInfoList");
            if (tokTeamStats != null)
                TeamStats = tokTeamStats.ToObject<List<MaddenTeamStats>>();

            // Get Defense Stats
            JToken tokDefenseStats = WeekData.SelectToken("defense.playerDefensiveStatInfoList");
            if (tokDefenseStats != null)
                DefenseStats = tokDefenseStats.ToObject<List<MaddenDefenseStats>>();

            // Get Kicking Stats
            JToken tokKickingStats = WeekData.SelectToken("kicking.playerKickingStatInfoList");
            if (tokKickingStats != null)
                KickingStats = tokKickingStats.ToObject<List<MaddenKickingStats>>();

            // Get Passing Stats
            JToken tokPassingStatus = WeekData.SelectToken("passing.playerPassingStatInfoList");
            if (tokPassingStatus != null)
                PassingStats = tokPassingStatus.ToObject<List<MaddenPassingStats>>();

            // Get Punting Stats
            JToken tokPuntingStats = WeekData.SelectToken("punting.playerPuntingStatInfoList");
            if (tokPuntingStats != null)
                PuntingStats = tokPuntingStats.ToObject<List<MaddenPuntingStats>>();

            // Get Receiving Stats
            JToken tokReceivingStats = WeekData.SelectToken("receiving.playerReceivingStatInfoList");
            if (tokReceivingStats != null)
                ReceivingStats = tokReceivingStats.ToObject<List<MaddenReceivingStats>>();

            // Get Rushing Stats
            JToken tokRushingStats = WeekData.SelectToken("rushing.playerRushingStatInfoList");
            if (tokRushingStats != null)
                RushingStats = tokRushingStats.ToObject<List<MaddenRushingStats>>();

            WeekData = null;
            
        }
        
    }

    public class MaddenDefenseStats
    {
        [JsonProperty("defCatchAllowed")]
        public long CatchesAllowed { get; set; }

        [JsonProperty("defDeflections")]
        public long Deflections { get; set; }

        [JsonProperty("defForcedFum")]
        public long FumblesForc { get; set; }

        [JsonProperty("defFumRec")]
        public long FumblesRec { get; set; }

        [JsonProperty("defIntReturnYds")]
        public long IntReturnYards { get; set; }

        [JsonProperty("defInts")]
        public long Interceptions { get; set; }

        [JsonProperty("defPts")]
        public long Points { get; set; }

        [JsonProperty("defSacks")]
        public long Sacks { get; set; }

        [JsonProperty("defSafeties")]
        public long Safeties { get; set; }

        [JsonProperty("defTDs")]
        public long Touchdowns { get; set; }

        [JsonProperty("defTotalTackles")]
        public long TotalTackles { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("rosterId")]
        public long RosterId { get; set; }

        [JsonProperty("scheduleId")]
        public long ScheduleId { get; set; }

        [JsonProperty("seasonIndex")]
        public long SeasonNum { get; set; }

        [JsonProperty("stageIndex")]
        public long StateNum { get; set; }

        [JsonProperty("statId")]
        public long StatId { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("weekIndex")]
        public long WeekNum { get; set; }

    }

    public class MaddenKickingStats
    {
        [JsonProperty("fG50PlusAtt")]
        public long FG50PlusAttempts { get; set; }

        [JsonProperty("fG50PlusMade")]
        public long FG50PlusMade { get; set; }

        [JsonProperty("fGAtt")]
        public long FGTotalAttempts { get; set; }

        [JsonProperty("fGCompPct")]
        public double FGTotalPercent { get; set; }

        [JsonProperty("fGLongest")]
        public long FGLongest { get; set; }

        [JsonProperty("fGMade")]
        public long FGTotalMade { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("kickPts")]
        public long FGTotalPoints { get; set; }

        [JsonProperty("kickoffAtt")]
        public long KOAttempts { get; set; }

        [JsonProperty("kickoffTBs")]
        public long KOTouchbacks { get; set; }

        [JsonProperty("rosterId")]
        public long RosterId { get; set; }

        [JsonProperty("scheduleId")]
        public long ScheduleId { get; set; }

        [JsonProperty("seasonIndex")]
        public long SeasonNum { get; set; }

        [JsonProperty("stageIndex")]
        public long StageNum { get; set; }

        [JsonProperty("statId")]
        public long StatId { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("weekIndex")]
        public long WeekNum { get; set; }

        [JsonProperty("xPAtt")]
        public long PATotalAttempts { get; set; }

        [JsonProperty("xPCompPct")]
        public long PATotalPercent { get; set; }

        [JsonProperty("xPMade")]
        public long PATotalMade { get; set; }

    }

    public class MaddenPassingStats
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("passAtt")]
        public long TotalAttempts { get; set; }

        [JsonProperty("passComp")]
        public long TotalCompletions { get; set; }

        [JsonProperty("passCompPct")]
        public double TotalPercent { get; set; }

        [JsonProperty("passInts")]
        public long TotalInterceptions { get; set; }

        [JsonProperty("passLongest")]
        public long LongestPass { get; set; }

        [JsonProperty("passPts")]
        public long TotalPoints { get; set; }

        [JsonProperty("passSacks")]
        public long TotalSacks { get; set; }

        [JsonProperty("passTDs")]
        public long TotalTouchdowns { get; set; }

        [JsonProperty("passYds")]
        public long TotalYards { get; set; }

        [JsonProperty("passYdsPerAtt")]
        public long YardsPerAttempt { get; set; }

        [JsonProperty("passYdsPerGame")]
        public double YardsPerGame { get; set; }

        [JsonProperty("passerRating")]
        public double PasserRating { get; set; }

        [JsonProperty("rosterId")]
        public long RosterId { get; set; }

        [JsonProperty("scheduleId")]
        public long ScheduleId { get; set; }

        [JsonProperty("seasonIndex")]
        public long SeasonNum { get; set; }

        [JsonProperty("stageIndex")]
        public long StageNum { get; set; }

        [JsonProperty("statId")]
        public long StatId { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("weekIndex")]
        public long WeekNum { get; set; }

    }

    public class MaddenPuntingStats
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("puntAtt")]
        public long TotalAttempts { get; set; }

        [JsonProperty("puntLongest")]
        public long LongestPunt { get; set; }

        [JsonProperty("puntNetYds")]
        public long TotalNetYards { get; set; }

        [JsonProperty("puntNetYdsPerAtt")]
        public long NetYardsPerAttempt { get; set; }

        [JsonProperty("puntTBs")]
        public long TotalTouchbacks { get; set; }

        [JsonProperty("puntYds")]
        public long TotalYards { get; set; }

        [JsonProperty("puntYdsPerAtt")]
        public long YardsPerAttempt { get; set; }

        [JsonProperty("puntsBlocked")]
        public long TotalBlocked { get; set; }

        [JsonProperty("puntsIn20")]
        public long TotalIn20 { get; set; }

        [JsonProperty("rosterId")]
        public long RosterId { get; set; }

        [JsonProperty("scheduleId")]
        public long ScheduleId { get; set; }

        [JsonProperty("seasonIndex")]
        public long SeasonNum { get; set; }

        [JsonProperty("stageIndex")]
        public long StageNum { get; set; }

        [JsonProperty("statId")]
        public long StatId { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("weekIndex")]
        public long WeekNum { get; set; }

    }

    public class MaddenReceivingStats
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("recCatchPct")]
        public long TotalCatchPercent { get; set; }

        [JsonProperty("recCatches")]
        public long TotalCatches { get; set; }

        [JsonProperty("recDrops")]
        public long TotalDrops { get; set; }

        [JsonProperty("recLongest")]
        public long LongestReception { get; set; }

        [JsonProperty("recPts")]
        public long TotalPoints { get; set; }

        [JsonProperty("recTDs")]
        public long TotalTouchdowns { get; set; }

        [JsonProperty("recToPct")]
        public long RecToPercent { get; set; }

        [JsonProperty("recYacPerCatch")]
        public double YACPerCatch { get; set; }

        [JsonProperty("recYds")]
        public long TotalYards { get; set; }

        [JsonProperty("recYdsAfterCatch")]
        public long YACTotal { get; set; }

        [JsonProperty("recYdsPerCatch")]
        public double YardsPerCatch { get; set; }

        [JsonProperty("recYdsPerGame")]
        public double YardsPerGame { get; set; }

        [JsonProperty("rosterId")]
        public long RosterId { get; set; }

        [JsonProperty("scheduleId")]
        public long ScheduleId { get; set; }

        [JsonProperty("seasonIndex")]
        public long SeasonNum { get; set; }

        [JsonProperty("stageIndex")]
        public long StageNum { get; set; }

        [JsonProperty("statId")]
        public long StatId { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("weekIndex")]
        public long WeekNum { get; set; }

    }

    public class MaddenRushingStats
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("rosterId")]
        public long RosterId { get; set; }

        [JsonProperty("rush20PlusYds")]
        public long Total20Plus { get; set; }

        [JsonProperty("rushAtt")]
        public long TotalAttempts { get; set; }

        [JsonProperty("rushBrokenTackles")]
        public long TotalBrokenTackles { get; set; }

        [JsonProperty("rushFum")]
        public long TotalFumbles { get; set; }

        [JsonProperty("rushLongest")]
        public long LongestRush { get; set; }

        [JsonProperty("rushPts")]
        public long TotalPoints { get; set; }

        [JsonProperty("rushTDs")]
        public long TotalTouchdowns { get; set; }

        [JsonProperty("rushToPct")]
        public long RushToPercent { get; set; }

        [JsonProperty("rushYds")]
        public long TotalYards { get; set; }

        [JsonProperty("rushYdsAfterContact")]
        public long YACTotal { get; set; }

        [JsonProperty("rushYdsPerAtt")]
        public long YardsPerAttempt { get; set; }

        [JsonProperty("rushYdsPerGame")]
        public double YardsPerGame { get; set; }

        [JsonProperty("scheduleId")]
        public long ScheduleId { get; set; }

        [JsonProperty("seasonIndex")]
        public long SeasonNum { get; set; }

        [JsonProperty("stageIndex")]
        public long StageNum { get; set; }

        [JsonProperty("statId")]
        public long StatId { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("weekIndex")]
        public long WeekNum { get; set; }

    }

    public class MaddenGame
    {
        [JsonProperty("awayScore")]
        public long awayScore { get; set; }

        [JsonProperty("awayTeamId")]
        public long awayTeamId { get; set; }

        [JsonProperty("homeScore")]
        public long homeScore { get; set; }

        [JsonProperty("homeTeamId")]
        public long homeTeamId { get; set; }

        [JsonProperty("isGameOfTheWeek")]
        public bool isGameOfTheWeek { get; set; }

        [JsonProperty("scheduleId")]
        public long scheduleId { get; set; }

        [JsonProperty("seasonIndex")]
        public long seasonIndex { get; set; }

        [JsonProperty("stageIndex")]
        public long stageIndex { get; set; }

        [JsonProperty("status")]
        public long status { get; set; }

        [JsonProperty("weekIndex")]
        public long weekIndex { get; set; }

    }

    public class MaddenTeamStats
    {
        [JsonProperty("defForcedFum")]
        public long defForcedFum { get; set; }

        [JsonProperty("defFumRec")]
        public long defFumRec { get; set; }

        [JsonProperty("deflongsRec")]
        public long deflongsRec { get; set; }

        [JsonProperty("defPassYds")]
        public long defPassYds { get; set; }

        [JsonProperty("defPtsPerGame")]
        public double defPtsPerGame { get; set; }

        [JsonProperty("defRedZoneFGs")]
        public long defRedZoneFGs { get; set; }

        [JsonProperty("defRedZonePct")]
        public long defRedZonePct { get; set; }

        [JsonProperty("defRedZoneTDs")]
        public long defRedZoneTDs { get; set; }

        [JsonProperty("defRedZones")]
        public long defRedZones { get; set; }

        [JsonProperty("defRushYds")]
        public long defRushYds { get; set; }

        [JsonProperty("defSacks")]
        public long defSacks { get; set; }

        [JsonProperty("defTotalYds")]
        public long defTotalYds { get; set; }

        [JsonProperty("off1stDowns")]
        public long off1stDowns { get; set; }

        [JsonProperty("off2PtAtt")]
        public long off2PtAtt { get; set; }

        [JsonProperty("off2PtConv")]
        public long off2PtConv { get; set; }

        [JsonProperty("off2PtConvPct")]
        public long off2PtConvPct { get; set; }

        [JsonProperty("off3rdDownAtt")]
        public long off3rdDownAtt { get; set; }

        [JsonProperty("off3rdDownConv")]
        public long off3rdDownConv { get; set; }

        [JsonProperty("off3rdDownConvPct")]
        public long off3rdDownConvPct { get; set; }

        [JsonProperty("off4thDownAtt")]
        public long off4thDownAtt { get; set; }

        [JsonProperty("off4thDownConv")]
        public long off4thDownConv { get; set; }

        [JsonProperty("off4thDownConvPct")]
        public long off4thDownConvPct { get; set; }

        [JsonProperty("offFumLost")]
        public long offFumLost { get; set; }

        [JsonProperty("offlongsLost")]
        public long offlongsLost { get; set; }

        [JsonProperty("offPassTDs")]
        public long offPassTDs { get; set; }

        [JsonProperty("offPassYds")]
        public long offPassYds { get; set; }

        [JsonProperty("offPtsPerGame")]
        public double offPtsPerGame { get; set; }

        [JsonProperty("offRedZoneFGs")]
        public long offRedZoneFGs { get; set; }

        [JsonProperty("offRedZonePct")]
        public double offRedZonePct { get; set; }

        [JsonProperty("offRedZoneTDs")]
        public long offRedZoneTDs { get; set; }

        [JsonProperty("offRedZones")]
        public long offRedZones { get; set; }

        [JsonProperty("offRushTDs")]
        public long offRushTDs { get; set; }

        [JsonProperty("offRushYds")]
        public long offRushYds { get; set; }

        [JsonProperty("offSacks")]
        public long offSacks { get; set; }

        [JsonProperty("offTotalYds")]
        public long offTotalYds { get; set; }

        [JsonProperty("offTotalYdsGained")]
        public long offTotalYdsGained { get; set; }

        [JsonProperty("penalties")]
        public long penalties { get; set; }

        [JsonProperty("penaltyYds")]
        public long penaltyYds { get; set; }

        [JsonProperty("scheduleId")]
        public long scheduleId { get; set; }

        [JsonProperty("seasonIndex")]
        public long seasonIndex { get; set; }

        [JsonProperty("seed")]
        public long seed { get; set; }

        [JsonProperty("stageIndex")]
        public long stageIndex { get; set; }

        [JsonProperty("statId")]
        public long statId { get; set; }

        [JsonProperty("tODiff")]
        public long tODiff { get; set; }

        [JsonProperty("tOGiveaways")]
        public long tOGiveaways { get; set; }

        [JsonProperty("tOTakeaways")]
        public long tOTakeaways { get; set; }

        [JsonProperty("teamId")]
        public long teamId { get; set; }

        [JsonProperty("totalLosses")]
        public long totalLosses { get; set; }

        [JsonProperty("totalTies")]
        public long totalTies { get; set; }

        [JsonProperty("totalWins")]
        public long totalWins { get; set; }

        [JsonProperty("weekIndex")]
        public long weekIndex { get; set; }

    }

    public class MaddenPlayerGoal
    {
        [JsonProperty("experienceAward3")]
        public long experienceAward3 { get; set; }

        [JsonProperty("experienceAward4")]
        public long experienceAward4 { get; set; }

        [JsonProperty("currentLevel")]
        public long currentLevel { get; set; }

        [JsonProperty("goalId")]
        public long goalId { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("completionValue1")]
        public long completionValue1 { get; set; }

        [JsonProperty("completionValue2")]
        public long completionValue2 { get; set; }

        [JsonProperty("experienceAward1")]
        public long experienceAward1 { get; set; }

        [JsonProperty("completionValue3")]
        public long completionValue3 { get; set; }

        [JsonProperty("experienceAward2")]
        public long experienceAward2 { get; set; }

        [JsonProperty("completionValue4")]
        public long completionValue4 { get; set; }

    }

    public class MaddenPlayer
    {

        // Unique Player ID
        [JsonProperty("rosterId")]
        public long RosterId { get; set; }

        #region Player Information

        public string TeamName { get; set; }
        
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("yearsPro")]
        public long YearsPro { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("homeTown")]
        public string HomeTown { get; set; }

        [JsonProperty("homeState")]
        public long HomeState { get; set; }

        [JsonProperty("birthYear")]
        public long BirthYear { get; set; }

        [JsonProperty("birthDay")]
        public long BirthDay { get; set; }

        [JsonProperty("birthMonth")]
        public long BirthMonth { get; set; }

        #endregion

        #region Player Status

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("injuryType")]
        public long InjuryType { get; set; }

        [JsonProperty("isFreeAgent")]
        public bool IsFreeAgent { get; set; }

        [JsonProperty("legacyScore")]
        public long LegacyScore { get; set; }

        [JsonProperty("experiencePoints")]
        public long ExperiencePoints { get; set; }

        [JsonProperty("isOnIR")]
        public bool IsOnIR { get; set; }

        [JsonProperty("jerseyNum")]
        public long JerseyNum { get; set; }

        [JsonProperty("isOnPracticeSquad")]
        public bool IsOnPracticeSquad { get; set; }

        [JsonProperty("injuryLength")]
        public long InjuryLength { get; set; }

        #endregion

        #region Draft Information

        [JsonProperty("draftPick")]
        public long DraftPick { get; set; }

        [JsonProperty("draftRound")]
        public long DraftRound { get; set; }

        [JsonProperty("rookieYear")]
        public long RookieYear { get; set; }

        [JsonProperty("college")]
        public string College { get; set; }

        #endregion

        #region Contract Information

        [JsonProperty("capHit")]
        public long CapHit { get; set; }

        [JsonProperty("desiredLength")]
        public long DesiredContractLength
        {
            get
            {
                return _desiredContractLength;
            }

            set
            {
                _desiredContractLength = value;
                UpdateDesiredYearSalary();
                UpdateDesiredYearBonus();
            }
        }
        private long _desiredContractLength = 0;

        [JsonProperty("desiredSalary")]
        public long DesiredContractSalary
        {
            get
            {
                return _desiredContractSalary;
            }

            set
            {
                _desiredContractSalary = value;
                UpdateDesiredYearSalary();
            }
        }
        private long _desiredContractSalary = 0;

        public long DesiredContractYearSalary { get; set; }

        [JsonProperty("desiredBonus")]
        public long DesiredContractBonus
        {
            get
            {
                return _desiredContractBonus;
            }

            set
            {
                _desiredContractBonus = value;
                UpdateDesiredYearBonus();
            }
        }
        private long _desiredContractBonus = 0;

        public long DesiredContractYearBonus { get; set; }

        [JsonProperty("contractYearsLeft")]
        public long ContractYearsLeft { get; set; }

        [JsonProperty("contractBonus")]
        public long ContractBonus { get; set; }

        [JsonProperty("capReleaseNetSavings")]
        public long CapReleaseNetSavings { get; set; }

        [JsonProperty("capReleasePenalty")]
        public long CapReleasePenalty { get; set; }

        [JsonProperty("contractSalary")]
        public long ContractSalary
        {
            get
            {
                return _contractSalary;
            }

            set
            {
                _contractSalary = value;
                UpdateCurrentYearSalary();
            }
        }
        private long _contractSalary = 0;

        [JsonProperty("contractLength")]
        public long ContractLength
        {
            get
            {
                return _contractLength;
            }

            set
            {
                _contractLength = value;
                UpdateCurrentYearSalary();
            }
        }
        private long _contractLength = 0;

        public long ContractYearSalary { get; set; }

        #endregion

        #region Basic Ratings

        [JsonProperty("playerBestOvr")]
        public long PlayerBestOvr { get; set; }

        [JsonProperty("agilityRating")]
        public long AgilityRating { get; set; }

        [JsonProperty("speedRating")]
        public long SpeedRating { get; set; }

        [JsonProperty("accelRating")]
        public long AccelRating { get; set; }

        [JsonProperty("jumpRating")]
        public long JumpRating { get; set; }

        [JsonProperty("staminaRating")]
        public long StaminaRating { get; set; }

        [JsonProperty("injuryRating")]
        public long InjuryRating { get; set; }

        [JsonProperty("toughRating")]
        public long ToughRating { get; set; }

        private long _devTraitNum = 0;
        [JsonProperty("devTrait")]
        public long DevTraitNum
        {
            get
            {
                return _devTraitNum;
            }
            set
            {
                _devTraitNum = value;
                switch (value)
                {
                    case 0:
                        DevTrait = "Normal";
                        break;

                    case 1:
                        DevTrait = "Star";
                        break;

                    case 2:
                        DevTrait = "Superstar";
                        break;

                    case 3:
                        DevTrait = "X-Factor";
                        break;

                    default:
                        DevTrait = "Unknown";
                        break;
                }
            }
        }

        public string DevTrait { get; set; }

        [JsonProperty("strengthRating")]
        public long StrengthRating { get; set; }

        [JsonProperty("awareRating")]
        public long AwarenessRating { get; set; }

        #endregion

        #region Passing Ratings

        [JsonProperty("throwOnRunRating")]
        public long ThrowOnRunRating { get; set; }

        [JsonProperty("throwAccDeepRating")]
        public long ThrowAccDeepRating { get; set; }

        [JsonProperty("playActionRating")]
        public long ThrowPlayActRating { get; set; }

        [JsonProperty("throwAccMidRating")]
        public long ThrowAccMidRating { get; set; }

        [JsonProperty("throwAccRating")]
        public long ThrowAccRating { get; set; }

        [JsonProperty("throwPowerRating")]
        public long ThrowPowerRating { get; set; }

        [JsonProperty("throwAccShortRating")]
        public long ThrowAccShortRating { get; set; }

        #endregion

        #region Ball Carrier Ratings

        [JsonProperty("elusiveRating")]
        public long ElusivenessRating { get; set; }

        [JsonProperty("spinMoveRating")]
        public long SpinMoveRating { get; set; }

        [JsonProperty("stiffArmRating")]
        public long StiffArmRating { get; set; }

        [JsonProperty("bCVRating")]
        public long BCVRating { get; set; }

        [JsonProperty("jukeMoveRating")]
        public long JukeMoveRating { get; set; }

        [JsonProperty("carryRating")]
        public long CarryRating { get; set; }

        [JsonProperty("truckRating")]
        public long TruckRating { get; set; }

        #endregion

        #region Receiving Ratings

        [JsonProperty("releaseRating")]
        public long ReleaseRating { get; set; }

        [JsonProperty("cITRating")]
        public long CatInTrafficRating { get; set; }

        [JsonProperty("catchRating")]
        public long CatchRating { get; set; }

        [JsonProperty("specCatchRating")]
        public long SpecCatchRating { get; set; }

        [JsonProperty("routeRunRating")]
        public long RouteRunRating { get; set; }

        #endregion

        #region Blocking Ratings

        [JsonProperty("impactBlockRating")]
        public long ImpactBlockRating { get; set; }

        [JsonProperty("passBlockRating")]
        public long PassBlockRating { get; set; }

        [JsonProperty("runBlockRating")]
        public long RunBlockRating { get; set; }

        #endregion

        #region Defense Ratings

        [JsonProperty("pressRating")]
        public long PressRating { get; set; }

        [JsonProperty("zoneCoverRating")]
        public long ZoneCoverRating { get; set; }

        [JsonProperty("tackleRating")]
        public long TackleRating { get; set; }

        [JsonProperty("hitPowerRating")]
        public long HitPowerRating { get; set; }

        [JsonProperty("blockShedRating")]
        public long BlockShedRating { get; set; }

        [JsonProperty("finesseMovesRating")]
        public long FinesseMovesRating { get; set; }

        [JsonProperty("pursuitRating")]
        public long PursuitRating { get; set; }

        [JsonProperty("playRecRating")]
        public long PlayRecRating { get; set; }

        [JsonProperty("powerMovesRating")]
        public long PowerMovesRating { get; set; }

        [JsonProperty("manCoverRating")]
        public long ManCoverRating { get; set; }

        #endregion

        #region Kicking Ratings

        [JsonProperty("kickAccRating")]
        public long KickAccRating { get; set; }

        [JsonProperty("kickRetRating")]
        public long KickRetRating { get; set; }

        [JsonProperty("kickPowerRating")]
        public long KickPowerRating { get; set; }

        #endregion

        #region Composite Ratings
        
        [JsonProperty("physicalGrade")]
        public long PhysicalGrade { get; set; }

        [JsonProperty("confRating")]
        public long ConfidenceRating { get; set; }

        [JsonProperty("importanceGrade")]
        public long ImportanceGrade { get; set; }

        [JsonProperty("personalityRating")]
        public long PersonalityGrade { get; set; }

        [JsonProperty("durabilityGrade")]
        public long DurabilityGrade { get; set; }

        [JsonProperty("intangibleGrade")]
        public long IntangibleGrade { get; set; }

        [JsonProperty("sizeGrade")]
        public long SizeGrade { get; set; }

        [JsonProperty("productionGrade")]
        public long ProductionGrade { get; set; }

        #endregion

        #region Traits

        [JsonProperty("clutchTrait")]
        public long ClutchTrait { get; set; }

        [JsonProperty("dropOpenPassTrait")]
        public long DropOpenPassTrait { get; set; }

        [JsonProperty("dLSplongrait")]
        public long DLSplongrait { get; set; }

        [JsonProperty("penaltyTrait")]
        public long PenaltyTrait { get; set; }

        [JsonProperty("feetInBoundsTrait")]
        public long FeetInBoundsTrait { get; set; }

        [JsonProperty("posCatchTrait")]
        public long PosCatchTrait { get; set; }

        [JsonProperty("fightForYardsTrait")]
        public long FightForYardsTrait { get; set; }

        [JsonProperty("yACCatchTrait")]
        public long YACCatchTrait { get; set; }

        [JsonProperty("qBStyleTrait")]
        public long QBStyleTrait { get; set; }

        [JsonProperty("runStyle")]
        public long RunStyleTrait { get; set; }

        [JsonProperty("forcePassTrait")]
        public long ForcePassTrait { get; set; }

        [JsonProperty("lBStyleTrait")]
        public long LBStyleTrait { get; set; }

        [JsonProperty("predictTrait")]
        public long PredictTrait { get; set; }

        [JsonProperty("stripBallTrait")]
        public long StripBallTrait { get; set; }

        [JsonProperty("coverBallTrait")]
        public long CoverBallTrait { get; set; }

        [JsonProperty("throwAwayTrait")]
        public long ThrowAwayTrait { get; set; }

        [JsonProperty("sensePressureTrait")]
        public long SensePressureTrait { get; set; }

        [JsonProperty("dLBullRushTrait")]
        public long DLBullRushTrait { get; set; }

        [JsonProperty("highMotorTrait")]
        public long HighMotorTrait { get; set; }

        [JsonProperty("playBallTrait")]
        public long PlayBallTrait { get; set; }

        [JsonProperty("hPCatchTrait")]
        public long HPCatchTrait { get; set; }

        [JsonProperty("bigHitTrait")]
        public long BigHitTrait { get; set; }

        [JsonProperty("tightSpiralTrait")]
        public long TightSpiralTrait { get; set; }

        [JsonProperty("dLSwimTrait")]
        public long DLSwimTrait { get; set; }

        #endregion

        #region Other

        [JsonProperty("playerSchemeOvr")]
        public long PlayerSchemeOvr { get; set; }

        [JsonProperty("scheme")]
        public long Scheme { get; set; }

        [JsonProperty("teamSchemeOvr")]
        public long TeamSchemeOvr { get; set; }

        [JsonProperty("portraitId")]
        public long PortraitId { get; set; }

        [JsonProperty("presentationId")]
        public long PresentationId { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("rosterGoalList")]
        public List<MaddenPlayerGoal> RosterGoalList { get; set; }

        #endregion

        #region Player Stats

        private List<MaddenDefenseStats> _defenseStats = new List<MaddenDefenseStats>();
        public List<MaddenDefenseStats> DefenseStats
        {
            get
            {
                return _defenseStats;
            }

            set
            {
                _defenseStats = value;
            }
        }

        private List<MaddenKickingStats> _kickingStats = new List<MaddenKickingStats>();
        public List<MaddenKickingStats> KickingStats
        {
            get
            {
                return _kickingStats;
            }

            set
            {
                _kickingStats = value;
            }
        }

        private List<MaddenPassingStats> _passingStats = new List<MaddenPassingStats>();
        public List<MaddenPassingStats> PassingStats
        {
            get
            {
                return _passingStats;
            }

            set
            {
                _passingStats = value;
            }
        }

        private List<MaddenPuntingStats> _puntingStats = new List<MaddenPuntingStats>();
        public List<MaddenPuntingStats> PuntingStats
        {
            get
            {
                return _puntingStats;
            }

            set
            {
                _puntingStats = value;
            }
        }

        private List<MaddenReceivingStats> _receivingStats = new List<MaddenReceivingStats>();
        public List<MaddenReceivingStats> ReceivingStats
        {
            get
            {
                return _receivingStats;
            }

            set
            {
                _receivingStats = value;
            }
        }

        private List<MaddenRushingStats> _rushingStats = new List<MaddenRushingStats>();
        public List<MaddenRushingStats> RushingStats
        {
            get
            {
                return _rushingStats;
            }

            set
            {
                _rushingStats = value;
            }
        }

        #endregion

        private void UpdateDesiredYearSalary()
        {
            if (DesiredContractLength == 0 || DesiredContractSalary == 0)
            {
                DesiredContractYearSalary = 0;
            }
            else
            {
                DesiredContractYearSalary = DesiredContractSalary / DesiredContractLength;
            }
        }

        private void UpdateDesiredYearBonus()
        {
            if (DesiredContractLength == 0 || DesiredContractBonus == 0)
            {
                DesiredContractYearBonus = 0;
            }
            else
            {
                DesiredContractYearBonus = DesiredContractBonus / DesiredContractLength;
            }
        }

        private void UpdateCurrentYearSalary()
        {
            if (ContractLength == 0 || ContractSalary == 0)
            {
                ContractYearSalary = 0;
            }
            else
            {
                ContractYearSalary = ContractSalary / ContractLength;
            }
        }
    }

    public class MaddenPlayerStats
    {
        public MaddenDefenseStats Defense { get; set; }
        public MaddenKickingStats Kicking { get; set; }
        public MaddenPassingStats Passing { get; set; }
        public MaddenPuntingStats Punting { get; set; }
        public MaddenReceivingStats Receiving { get; set; }
        public MaddenRushingStats Rushing { get; set; }
    }

    public class DevTraitCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            long devX = ConvertDevTrait(x.ToString());
            long devY = ConvertDevTrait(y.ToString());

            if (devX == devY)
                return 0;

            if (devX > devY)
                return 1;

            if (devX < devY)
                return -1;

            return -1;
        }

        private long ConvertDevTrait(string devTrait)
        {
            switch (devTrait)
            {
                case "Slow":
                default:
                    return 0;

                case "Normal":
                    return 1;

                case "Quick":
                    return 2;

                case "Superstar":
                    return 3;
            }
        }
    }

    public class NumColorScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double max = 99;
            double min = 40;

            long val = (long)(value);

            if (val < min)
                val = 40;

            double perRed = 0;
            double perGreen = 0;
            string color = "";
            double ratio = 0;

            ratio = 1 / (max - min);
            var finalValue = (val - min) * ratio;

            if (finalValue == 0.5)
            {
                perRed = 1;
                perGreen = 1;
            }
            else if (finalValue > 0.5)
            {
                perGreen = 1;
                perRed = (1 - finalValue) * 2;
            }
            else
            {
                perRed = 1;
                perGreen = finalValue * 2;
            }

            var red = (long)Math.Round(255.0 * perRed);
            var green = (long)Math.Round(255.0 * perGreen);

            var gString = green.ToString("X");
            var rString = red.ToString("X");

            if (gString.Length == 1)
            {
                gString = '0' + gString;
            }

            if (rString.Length == 1)
            {
                rString = "0" + rString;
            }

            color = "#" + rString + gString + "00";

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class DevColorScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string colXFactor = "#e61c18";        // 127 255  0
            string colSuperstar = "#f4d00c";    //  0  255  0
            string colStar = "#b7b09a";         // 255 127  0
            string colNormal = "#5c4805";       // 255 255  0
            string colUnknown = "#FFFFFF";      // 255  0   0

            string color = colUnknown;

            if (value != null)
            {
                string devTrait = value.ToString();

                switch (devTrait)
                {
                    case "X-Factor":
                        color = colXFactor;
                        break;

                    case "Superstar":
                        color = colSuperstar;
                        break;

                    case "Star":
                        color = colStar;
                        break;

                    case "Normal":
                        color = colNormal;
                        break;

                    default:
                        color = colUnknown;
                        break;
                }

            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class DesireColorScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string colHigh = "#00FF00";    //  0  255  0
            string colMedium = "#FFFF00";       // 255 255  0
            string colLow = "#FF0000";      // 255  0   0
            string colUnknown = "#FFFFFF";

            string color = colUnknown;

            if (value != null)
            {
                string desire = value.ToString();

                switch (desire)
                {
                    case "High":
                        color = colHigh;
                        break;

                    case "Medium":
                        color = colMedium;
                        break;

                    case "Low":
                        color = colLow;
                        break;

                    default:
                        color = colUnknown;
                        break;
                }

            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class SalaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string place = "";
            string result = "";
            double salary = 0;

            if (value != null)
            {
                Double.TryParse(value.ToString(), out salary);
            }            

            if (Math.Abs(salary) >= 1000000)
            {
                place = "M";
                salary = salary / 1000000;
            }
            else if (Math.Abs(salary) >= 1000)
            {
                place = "K";
                salary = salary / 1000;
            }

            result = "$" + salary.ToString("N2") + " " + place;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class HeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            int feet = 0;
            int inches = 0;
            int totalInches = 0;

            string result = "";

            if (value != null)
            {
                Int32.TryParse(value.ToString(), out totalInches);
            }

            if (totalInches > 0)
            {
                //feet = Math.Floor(totalInches / 12);
                //inches = 12 * ((totalInches / 12) - feet);

                feet = totalInches / 12;
                inches = totalInches % 12;

                result = feet + "' " + inches + "\"";
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
