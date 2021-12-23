using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaddenCompanion
{
    public class MaddenScoutedPlayer : INotifyPropertyChanged
    {
        #region Properties

        private string _position = "";
        public string Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
                NotifyPropertyChanged("Position");
            }
        }

        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string _projRound = "";
        public string ProjRound
        {
            get
            {
                return _projRound;
            }

            set
            {
                _projRound = value;
                NotifyPropertyChanged("ProjRound");
            }
        }

        private string _talentRound = "";
        public string TalentRound
        {
            get
            {
                return _talentRound;
            }

            set
            {
                _talentRound = value;
                NotifyPropertyChanged("TalentRound");
            }
        }

        private int _age = 0;
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
                NotifyPropertyChanged("Age");
            }
        }

        private string _height = "";
        public string Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                NotifyPropertyChanged("Height");
            }
        }

        private string _draftStory = "";
        public string DraftStory
        {
            get
            {
                return _draftStory;
            }

            set
            {
                _draftStory = value;
                NotifyPropertyChanged("DraftStory");
            }
        }

        private string _scoutedSkill1 = "";
        public string ScoutedSkill1
        {
            get
            {
                return _scoutedSkill1;
            }

            set
            {
                _scoutedSkill1 = value;
                NotifyPropertyChanged("ScoutedSkill1");
            }
        }

        private string _scoutedSkill2 = "";
        public string ScoutedSkill2
        {
            get
            {
                return _scoutedSkill2;
            }

            set
            {
                _scoutedSkill2 = value;
                NotifyPropertyChanged("ScoutedSkill2");
            }
        }

        private string _scoutedSkill3 = "";
        public string ScoutedSkill3
        {
            get
            {
                return _scoutedSkill3;
            }

            set
            {
                _scoutedSkill3 = value;
                NotifyPropertyChanged("ScoutedSkill3");
            }
        }

        private string _scoutedGrade1 = "";
        public string ScoutedGrade1
        {
            get
            {
                return _scoutedGrade1;
            }

            set
            {
                _scoutedGrade1 = value;
                NotifyPropertyChanged("ScoutedGrade1");
            }
        }

        private string _scoutedGrade2 = "";
        public string ScoutedGrade2
        {
            get
            {
                return _scoutedGrade2;
            }

            set
            {
                _scoutedGrade2 = value;
                NotifyPropertyChanged("ScoutedGrade2");
            }
        }

        private string _scoutedGrade3 = "";
        public string ScoutedGrade3
        {
            get
            {
                return _scoutedGrade3;
            }

            set
            {
                _scoutedGrade3 = value;
                NotifyPropertyChanged("ScoutedGrade3");
            }
        }

        private double? _combine40;
        public double? Combine40
        {
            get
            {
                return _combine40;
            }

            set
            {
                _combine40 = value;
                NotifyPropertyChanged("Combine40");
            }
        }

        private double? _combineVertical;
        public double? CombineVertical
        {
            get
            {
                return _combineVertical;
            }

            set
            {
                _combineVertical = value;
                NotifyPropertyChanged("CombineVertical");
            }
        }

        private double? _combineCone;
        public double? CombineCone
        {
            get
            {
                return _combineCone;
            }

            set
            {
                _combineCone = value;
                NotifyPropertyChanged("CombineCone");
            }
        }

        private double? _combineShuttle;
        public double? CombineShuttle
        {
            get
            {
                return _combineShuttle;
            }

            set
            {
                _combineShuttle = value;
                NotifyPropertyChanged("CombineShuttle");
            }
        }

        private double? _combineBench;
        public double? CombineBench
        {
            get
            {
                return _combineBench;
            }

            set
            {
                _combineBench = value;
                NotifyPropertyChanged("CombineBench");
            }
        }

        private string _draftStatus = "";
        public string DraftStatus
        {
            get
            {
                return _draftStatus;
            }

            set
            {
                _draftStatus = value;
                NotifyPropertyChanged("DraftStatus");
            }
        }

        private double _slowDevChance;
        public double SlowDevChance
        {
            get
            {
                return _slowDevChance;
            }

            set
            {
                _slowDevChance = value;
                NotifyPropertyChanged("SlowDevChance");
            }
        }

        private double? _normalDevChance;
        public double? NormalDevChance
        {
            get
            {
                return _normalDevChance;
            }

            set
            {
                _normalDevChance = value;
                NotifyPropertyChanged("NormalDevChance");
            }
        }

        private double? _quickDevChance;
        public double? QuickDevChance
        {
            get
            {
                return _quickDevChance;
            }

            set
            {
                _quickDevChance = value;
                NotifyPropertyChanged("QuickDevChance");
            }
        }

        private double? _superDevChance;
        public double? SuperDevChance
        {
            get
            {
                return _superDevChance;
            }

            set
            {
                _superDevChance = value;
                NotifyPropertyChanged("SuperDevChance");
            }
        }

        private double? _trueValue;
        public double? TrueValue
        {
            get
            {
                return _trueValue;
            }

            set
            {
                _trueValue = value;
                NotifyPropertyChanged("TrueValue");
            }
        }

        private int? _draftBoardRank;
        public int? DraftBoardRank
        {
            get
            {
                return _draftBoardRank;
            }

            set
            {
                _draftBoardRank = value;
                NotifyPropertyChanged("DraftBoardRank");
            }
        }

        private bool _draftPlayerTaken = false;
        public bool DraftPlayerTaken
        {
            get
            {
                return _draftPlayerTaken;
            }

            set
            {
                _draftPlayerTaken = value;
                NotifyPropertyChanged("DraftPlayerTaken");
            }
        }

        private int? _postDraftOvr;
        public int? PostDraftOvr
        {
            get
            {
                return _postDraftOvr;
            }

            set
            {
                _postDraftOvr = value;
                NotifyPropertyChanged("PostDraftOvr");
            }
        }

        #endregion

        private void UpdateDraftStatus()
        {
            // Called when the following fields are changed: 
            //      Position, ScoutedSkill1, ScoutedGrade1, ScoutedSkill2, ScoutedGrade2, ScoutedSkill3, ScoutedGrade3,
            //      Combine40, CombineVertical, CombineCone, CombineShuttle, CombineBench

            // Get Draft Grade ("Blue Chip", "Red Chip", "Risky Pick", "")
            string playerGrade = GetPlayerGrade();

            // Get Recommended Action ("Scout Further", "Draft", "Do Not Draft", "")
            string recAction = "";

            if (playerGrade == "Risky Pick" || playerGrade == "" || playerGrade == "Do Not Draft")
            {
                recAction = "";

            }else if (IsFullyScouted() == false)
            {
                recAction = "Scout Further: ";
            }
            else if (IsFullyScouted() == true)
            {
                recAction = "Draft: ";
            }

            DraftStatus = recAction + playerGrade;
        }

        #region Position Draft Statuses

        private string GetPlayerGrade()
        {
            string playerGrade = "";

            int topGrade = GetTopGradeNum();
            int minGrade = GetBottomGradeNum();

            if (topGrade == -1)
            {
                playerGrade = "";
                return playerGrade;
            }

            switch (Position)
            {
                case "QB":
                    playerGrade = GetPlayerGradeQB();
                    break;

                case "HB":
                    playerGrade = GetPlayerGradeHB();
                    break;

                case "FB":
                    playerGrade = GetPlayerGradeFB();
                    break;

                case "WR":
                    playerGrade = GetPlayerGradeWR();
                    break;

                case "TE":
                    playerGrade = GetPlayerGradeTE();
                    break;

                case "LT":
                    playerGrade = GetPlayerGradeLT();
                    break;

                case "LG":
                    playerGrade = GetPlayerGradeLG();
                    break;

                case "C":
                    playerGrade = GetPlayerGradeC();
                    break;

                case "RG":
                    playerGrade = GetPlayerGradeRG();
                    break;

                case "RT":
                    playerGrade = GetPlayerGradeRT();
                    break;

                case "LE":
                    playerGrade = GetPlayerGradeLE();
                    break;

                case "RE":
                    playerGrade = GetPlayerGradeRE();
                    break;

                case "DT":
                    playerGrade = GetPlayerGradeDT();
                    break;

                case "LOLB":
                    playerGrade = GetPlayerGradeLOLB();
                    break;

                case "ROLB":
                    playerGrade = GetPlayerGradeROLB();
                    break;

                case "MLB":
                    playerGrade = GetPlayerGradeMLB();
                    break;

                case "CB":
                    playerGrade = GetPlayerGradeCB();
                    break;

                case "FS":
                    playerGrade = GetPlayerGradeFS();
                    break;

                case "SS":
                    playerGrade = GetPlayerGradeSS();
                    break;

                case "K":
                    playerGrade = GetPlayerGradeK();
                    break;

                case "P":
                    playerGrade = GetPlayerGradeP();
                    break;

            }

            return playerGrade;
        }

        private string GetPlayerGrade(PlayerGradeRequirements blueChip, PlayerGradeRequirements redChip)
        {
            string playerGrade = "";
            bool blueChipMatch = blueChip.MatchesRequirements(this);
            bool redChipMatch = redChip.MatchesRequirements(this);

            if (blueChipMatch)
            {
                if (IsFullyScouted() && blueChip.MissingRequirement)
                {
                    playerGrade = "Risky Pick";
                }
                else
                {
                    playerGrade = "Blue Chip";
                }
            }
            else if (redChipMatch)
            {
                if (IsFullyScouted() && redChip.MissingRequirement)
                {
                    playerGrade = "Risky Pick";
                }
                else
                {
                    playerGrade = "Red Chip";
                }
            }
            else
            {
                playerGrade = "Do Not Draft";
            }

            return playerGrade;
        }

        private string GetQBDraftGradeOld()
        {
            string playerGrade = "";

            int topGrade = GetTopGradeNum();
            int minGrade = GetBottomGradeNum();
            int powerGrade = GetSkillGradeNum("Throwing Power");

            int shortGrade = GetSkillGradeNum("Short Throw Accuracy");
            int midGrade = GetSkillGradeNum("Mid Throw Accuracy");
            int deepGrade = GetSkillGradeNum("Deep Throw Accuracy");

            int maxAccGrade = new int[] { shortGrade, midGrade, deepGrade }.Max();

            // BLUE CHIP
            // Must have at least one A- (12)
            // Throwing Power at least A- (12)
            // One B (10) from Short Throw Accuracy, Mid Throw Accuracy or Deep Throw Accuracy
            // Minimum Grade B (10)

            if (topGrade >= 12 && minGrade >= 10)
            {
                if (!IsFullyScouted() && (powerGrade >= 12 || powerGrade == -1) && (maxAccGrade >= 10 || maxAccGrade == -1))
                {
                    playerGrade = "Blue Chip";
                }
                else if (IsFullyScouted() && powerGrade >= 12 && maxAccGrade >= 10)
                {
                    playerGrade = "Blue Chip";
                }
            }

            // RED CHIP
            // Must have at least one B+ (11)
            // Throwing Power at least B+ (11)
            // One B- (9) from Short Throw Accuracy, Mid Throw Accuracy or Deep Throw Accuracy
            // Minimum Grade B- (9)

            if (topGrade >= 11 && minGrade >= 9 && playerGrade == "")
            {
                if (!IsFullyScouted() && (powerGrade >= 11 || powerGrade == -1) && (maxAccGrade >= 9 || maxAccGrade == -1))
                {
                    playerGrade = "Red Chip";
                }
                else if (IsFullyScouted() && powerGrade >= 11 && maxAccGrade >= 9)
                {
                    playerGrade = "Red Chip";
                }
            }

            // RISKY PICK
            // Must have at least one B+ (11)
            // Minimum Grade B- (9)
            // Must be fully scouted
            // Missing any of the key skills above while others still meet at least Red Chip criteria

            if (topGrade >= 11 && minGrade >= 9 && playerGrade == "")
            {
                if (IsFullyScouted() && (powerGrade >= 11 || powerGrade == -1) && (maxAccGrade >= 9 || maxAccGrade == -1))
                {
                    playerGrade = "Risky Pick";
                }
            }

            // Return Player Grade
            return playerGrade;
        }

        private string GetPlayerGradeQB()
        {
            string playerGrade = "";

            // BLUE CHIP
            // Must have at least one A-
            // Minimum Grade B
            // Throwing Power at least A-
            // One B from Short Throw Accuracy, Mid Throw Accuracy or Deep Throw Accuracy

            PlayerGradeRequirements blueChip = new PlayerGradeRequirements();
            blueChip.ReqFullyScounted = false;
            blueChip.MaxStrGradeReq = "A-";
            blueChip.MinStrGradeReq = "B";
            blueChip.SkillRequirements.Add(
                new SkillRequirement()
                {
                    SkillNames = { "Throwing Power" },
                    StrGradeReq = "A-"
                }
            );
            blueChip.SkillRequirements.Add(
                new SkillRequirement()
                {
                    SkillNames = { "Short Throw Accuracy", "Mid Throw Accuracy", "Deep Throw Accuracy" }, StrGradeReq = "B"
                }
            );

            // RED CHIP
            // Must have at least one B+
            // Minimum Grade B-
            // Throwing Power at least B+
            // One B- from Short Throw Accuracy, Mid Throw Accuracy or Deep Throw Accuracy       
                 
            PlayerGradeRequirements redChip = new PlayerGradeRequirements();
            redChip.ReqFullyScounted = false;
            redChip.MaxStrGradeReq = "B+";
            redChip.MinStrGradeReq = "B-";
            redChip.SkillRequirements.Add(
                new SkillRequirement()
                {
                    SkillNames = { "Throwing Power" },
                    StrGradeReq = "B+"
                }
            );
            redChip.SkillRequirements.Add(
                new SkillRequirement()
                {
                    SkillNames = { "Short Throw Accuracy", "Mid Throw Accuracy", "Deep Throw Accuracy" },
                    StrGradeReq = "B-"
                }
            );

            // Get Player Grade using Blue Chip and Red Chip requirements
            playerGrade = GetPlayerGrade(blueChip, redChip);

            // Return Player Grade
            return playerGrade;
        }

        private string GetPlayerGradeHB()
        {
            string playerGrade = "";

            // BLUE CHIP
            // Must have at least one A-
            // Minimum Grade B
            // Throwing Power at least A-
            // One B from Short Throw Accuracy, Mid Throw Accuracy or Deep Throw Accuracy

            PlayerGradeRequirements blueChip = new PlayerGradeRequirements();
            blueChip.ReqFullyScounted = false;
            blueChip.MaxStrGradeReq = "B+";
            blueChip.MinStrGradeReq = "B";
            blueChip.SkillRequirements.Add(
                new SkillRequirement()
                {
                    SkillNames = { "Carrying", "Trucking", "Elusiveness", "Ball Carrier Vision" },
                    StrGradeReq = "B"
                }
            );
            blueChip.CombineRequirements.ReqCombine40 = 4.71;
            //blueChip.CombineRequirements.SumRequirements.Add(
            //    new CombineRequirement()
            //    {
            //        SkillNames = { "Throwing Power" },
            //        StrGradeReq = "B+"
            //    }
            //);

            // RED CHIP
            // Must have at least one B+
            // Minimum Grade B-
            // Throwing Power at least B+
            // One B- from Short Throw Accuracy, Mid Throw Accuracy or Deep Throw Accuracy       

            PlayerGradeRequirements redChip = new PlayerGradeRequirements();
            redChip.ReqFullyScounted = false;
            redChip.MaxStrGradeReq = "B+";
            redChip.MinStrGradeReq = "B-";
            redChip.SkillRequirements.Add(
                new SkillRequirement()
                {
                    SkillNames = { "Throwing Power" },
                    StrGradeReq = "B+"
                }
            );
            redChip.SkillRequirements.Add(
                new SkillRequirement()
                {
                    SkillNames = { "Short Throw Accuracy", "Mid Throw Accuracy", "Deep Throw Accuracy" },
                    StrGradeReq = "B-"
                }
            );

            // Return Player Grade
            return playerGrade;
        }

        private string GetPlayerGradeFB()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeWR()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeTE()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeLT()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeLG()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeC()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeRG()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeRT()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeLE()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeRE()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeDT()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeLOLB()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeROLB()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeMLB()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeCB()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeFS()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeSS()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeK()
        {
            string playerGrade = "";



            return playerGrade;
        }

        private string GetPlayerGradeP()
        {
            string playerGrade = "";



            return playerGrade;
        }

        #endregion

        public int GetSkillGradeNum(string skillName)
        {
            string strGrade = "";

            if (skillName == null)
            {
                return -1;
            }

            skillName = skillName.ToUpper();

            if (ScoutedSkill1 != null && ScoutedSkill1.ToUpper() == skillName)
            {
                strGrade = ScoutedGrade1;
            }
            else if(ScoutedSkill2 != null && ScoutedSkill2.ToUpper() == skillName)
            {
                strGrade = ScoutedGrade2;
            }
            else if(ScoutedSkill3 != null && ScoutedSkill3.ToUpper() == skillName)
            {
                strGrade = ScoutedGrade3;
            }

            int gradeNum = GetGradeNumber(strGrade);

            return gradeNum;

        }

        public int GetTopGradeNum()
        {
            int grade1 = GetGradeNumber(ScoutedGrade1);
            int grade2 = GetGradeNumber(ScoutedGrade2);
            int grade3 = GetGradeNumber(ScoutedGrade3);

            int[] grades = { grade1, grade2, grade3 };

            int maxGrade = grades.Max();

            return maxGrade;

        }

        public int GetBottomGradeNum()
        {
            string[] gradesKey = { "F-", "F", "F+", "D-", "D", "D+", "C-", "C", "C+", "B-", "B", "B+", "A-", "A", "A+" };

            int grade1 = Array.IndexOf(gradesKey, ScoutedGrade1);
            int grade2 = Array.IndexOf(gradesKey, ScoutedGrade2);
            int grade3 = Array.IndexOf(gradesKey, ScoutedGrade3);

            if (grade1 == -1)
                grade1 = 99;

            if (grade2 == -1)
                grade2 = 99;

            if (grade3 == -1)
                grade3 = 99;

            int[] grades = { grade1, grade2, grade3 };
            int minGrade = grades.Min();

            return minGrade;

        }

        public int GetGradeNumber(string strGrade)
        {
            int numGrade = -1;
            //                      0     1    2     3     4    5     6     7    8     9    10    11    12   13    14
            string[] gradesKey = { "F-", "F", "F+", "D-", "D", "D+", "C-", "C", "C+", "B-", "B", "B+", "A-", "A", "A+" };
            numGrade = Array.IndexOf(gradesKey, strGrade);

            return numGrade;
        }

        private string GetGradeText(int numGrade)
        {
            string strGrade = "";
            //                      0     1    2     3     4    5     6     7    8     9    10    11    12   13    14
            string[] gradesKey = { "F-", "F", "F+", "D-", "D", "D+", "C-", "C", "C+", "B-", "B", "B+", "A-", "A", "A+" };
            strGrade = gradesKey[numGrade];

            return strGrade;
        }

        public bool IsFullyScouted()
        {
            if (GetSkillGradeNum(ScoutedSkill1) > 0 && GetSkillGradeNum(ScoutedSkill2) > 0 && GetSkillGradeNum(ScoutedSkill3) > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public bool HasStartedScouting()
        {
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            string[] reqDraftStatusUpdate = {
                "Position", "ScoutedSkill1", "ScoutedGrade1", "ScoutedSkill2", "ScoutedGrade2", "ScoutedSkill3", "ScoutedGrade3",
                "Combine40", "CombineVertical", "CombineCone", "CombineShuttle", "CombineBench"
            };

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }

            if (Array.IndexOf(reqDraftStatusUpdate, info) >= 0)
            {
                UpdateDraftStatus();
            }
        }

    }

    public class PlayerGradeRequirements
    {
        public bool MissingRequirement = false;

        public string GradeDescription { get; set; } = "";

        public bool ReqFullyScounted = false;

        public string MaxStrGradeReq { get; set; } = "";
        public string MinStrGradeReq { get; set; } = "";

        private int MaxGradeReq = 0;
        private int MinGradeReq = 0;

        public List<SkillRequirement> SkillRequirements { get; set; } = new List<SkillRequirement>();
        public CombineRequirement CombineRequirements { get; set; } = new CombineRequirement();

        public bool MatchesRequirements(MaddenScoutedPlayer player)
        {
            bool matches = true;

            MaxGradeReq = player.GetGradeNumber(MaxStrGradeReq);
            MinGradeReq = player.GetGradeNumber(MinStrGradeReq);

            int playerMaxGrade = player.GetTopGradeNum();
            int playerMinGrade = player.GetBottomGradeNum();

            // Check Max Grade
            if (playerMaxGrade < MaxGradeReq)
            {
                MissingRequirement = true;
                return false;
            }

            // Check Min Grade
            if (playerMinGrade < MinGradeReq)
            {
                MissingRequirement = true;
                return false;
            }

            // Check Skill Requirements
            foreach (SkillRequirement skillReq in SkillRequirements)
            {
                int maxSkillNum = -1;

                foreach (string skillName in skillReq.SkillNames)
                {
                    int skillNum = player.GetSkillGradeNum(skillName);
                    if (skillNum > maxSkillNum)
                    {
                        maxSkillNum = skillNum;
                    }
                }

                int gradeReq = player.GetGradeNumber(skillReq.StrGradeReq);

                if (ReqFullyScounted)
                {
                    if (maxSkillNum < gradeReq)
                    {
                        MissingRequirement = true;
                        return false;
                    }
                }
                else
                {
                    if (maxSkillNum > -1 && maxSkillNum < gradeReq)
                    {
                        MissingRequirement = true;
                        return false;
                    }
                    else if (maxSkillNum == -1)
                    {   // Valid, but denote missing requirement
                        MissingRequirement = true;
                    }
                }
            }

            // Check Combine Requirements
            double? reqCombine40 = CombineRequirements.ReqCombine40;
            double? reqCombineVertical = CombineRequirements.ReqCombineVertical;
            double? reqCombineCone = CombineRequirements.ReqCombineCone;
            double? reqCombineShuttle = CombineRequirements.ReqCombineShuttle;
            double? reqCombineBench = CombineRequirements.ReqCombineBench;

            if (ReqFullyScounted)
            {
                if (reqCombine40 != null && (player.Combine40 == null || player.Combine40 < reqCombine40))
                {
                    MissingRequirement = true;
                    return false;
                }

                if (reqCombineVertical != null && (player.CombineVertical == null || player.CombineVertical < reqCombineVertical))
                {
                    MissingRequirement = true;
                    return false;
                }

                if (reqCombineCone != null && (player.CombineCone == null || player.CombineCone < reqCombineCone))
                {
                    MissingRequirement = true;
                    return false;
                }

                if (reqCombineShuttle != null && (player.CombineShuttle == null || player.CombineShuttle < reqCombineShuttle))
                {
                    MissingRequirement = true;
                    return false;
                }

                if (reqCombineBench != null && (player.CombineBench == null || player.CombineBench < reqCombineBench))
                {
                    MissingRequirement = true;
                    return false;
                }
            }
            else
            {
                if (reqCombine40 != null && (player.Combine40 != null && player.Combine40 < reqCombine40))
                {
                    return false;
                }
                else if (reqCombine40 != null && player.Combine40 == null)
                {   // Valid, but denote missing requirement
                    MissingRequirement = true;
                }

                if (reqCombineVertical != null && (player.CombineVertical != null && player.CombineVertical < reqCombineVertical))
                {
                    return false;
                }
                else if (reqCombineVertical != null && player.CombineVertical == null)
                {   // Valid, but denote missing requirement
                    MissingRequirement = true;
                }

                if (reqCombineCone != null && (player.CombineCone != null && player.CombineCone < reqCombineCone))
                {
                    return false;
                }
                else if (reqCombineCone != null && player.CombineCone == null)
                {   // Valid, but denote missing requirement
                    MissingRequirement = true;
                }

                if (reqCombineShuttle != null && (player.CombineShuttle != null && player.CombineShuttle < reqCombineShuttle))
                {
                    return false;
                }
                else if (reqCombineShuttle != null && player.CombineShuttle == null)
                {   // Valid, but denote missing requirement
                    MissingRequirement = true;
                }

                if (reqCombineBench != null && (player.CombineBench != null && player.CombineBench < reqCombineBench))
                {
                    return false;
                }
                else if (reqCombineBench != null && player.CombineBench == null)
                {   // Valid, but denote missing requirement
                    MissingRequirement = true;
                }
            }

            return matches;
        }

    }

    public class SkillRequirement
    {
        public List<string> SkillNames { get; set; } = new List<string>();
        public string StrGradeReq { get; set; }
        public bool CanBeMissing { get; set; } = true;
    }

    public class CombineRequirement
    {
        public double? ReqCombine40 { get; set; }
        public double? ReqCombineVertical { get; set; }
        public double? ReqCombineCone { get; set; }
        public double? ReqCombineShuttle { get; set; }
        public double? ReqCombineBench { get; set; }

        public List<CombineRequirement> SumRequirements { get; set; } = new List<CombineRequirement>();
    }

    public class MultiCombineRequirement
    {
        public double? ReqCombine40 { get; set; }
        public double? ReqCombineVertical { get; set; }
        public double? ReqCombineCone { get; set; }
        public double? ReqCombineShuttle { get; set; }
        public double? ReqCombineBench { get; set; }

        public double? ReqSum { get; set; }
        public bool ReqLessThanSum = true;
    }

}
