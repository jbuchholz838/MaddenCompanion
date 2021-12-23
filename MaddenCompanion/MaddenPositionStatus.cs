using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaddenCompanion
{
    public class MaddenPositionStatus : INotifyPropertyChanged
    {
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

        private string _starterName = "";
        public string StarterName
        {
            get
            {
                return _starterName;
            }
            set
            {
                _starterName = value;
                NotifyPropertyChanged("StarterName");
            }
        }

        private long _starterAge = 0;
        public long StarterAge
        {
            get
            {
                return _starterAge;
            }
            set
            {
                _starterAge = value;
                NotifyPropertyChanged("StarterAge");
            }
        }

        private long _starterOVR = 0;
        public long StarterOVR
        {
            get
            {
                return _starterOVR;
            }
            set
            {
                _starterOVR = value;
                NotifyPropertyChanged("StarterOVR");
            }
        }

        private long _starterYearsRemain = 0;
        public long StarterYearsRemain
        {
            get
            {
                return _starterYearsRemain;
            }
            set
            {
                _starterYearsRemain = value;
                NotifyPropertyChanged("StarterYearsRemain");
            }
        }

        private long _starterSalary = 0;
        public long StarterSalary
        {
            get
            {
                return _starterSalary;
            }
            set
            {
                _starterSalary = value;
                NotifyPropertyChanged("StarterSalary");
            }
        }

        private long _starterBonus = 0;
        public long StarterBonus
        {
            get
            {
                return _starterBonus;
            }
            set
            {
                _starterBonus = value;
                NotifyPropertyChanged("StarterBonus");
            }
        }

        private int _numBackups = 0;
        public int NumBackups
        {
            get
            {
                return _numBackups;
            }
            set
            {
                _numBackups = value;
                NotifyPropertyChanged("NumBackups");
            }
        }

        private string _backupOVRs = "";
        public string BackupOVRs
        {
            get
            {
                return _backupOVRs;
            }
            set
            {
                _backupOVRs = value;
                NotifyPropertyChanged("BackupOVRs");
            }
        }

        private bool _target = false;
        public bool Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
                NotifyPropertyChanged("Target");
            }
        }

        private string _notes = "";
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                NotifyPropertyChanged("Notes");
            }
        }

        public List<MaddenPlayer> PositionPlayers { get; set; }

        public void ProcessPlayers()
        {
            Reset();

            if (PositionPlayers == null)
            {
                PositionPlayers = new List<MaddenPlayer>();
            }

            int startIndex = 0;

            if (Position.EndsWith("2"))
            {
                startIndex = 1;
            }
            else if (Position.EndsWith("3"))
            {
                startIndex = 2;
            }

            for(int i = startIndex; i < PositionPlayers.Count; i++)
            {
                MaddenPlayer player = PositionPlayers[i];

                // Populate starter information
                if (String.IsNullOrEmpty(StarterName))
                {
                    StarterName = player.FirstName + " " + player.LastName;
                    StarterAge = player.Age;
                    StarterOVR = player.PlayerSchemeOvr;
                    StarterYearsRemain = player.ContractYearsLeft;
                    StarterSalary = player.ContractSalary;
                    StarterBonus = player.ContractBonus;

                    // Jump forward to skip the other starters if necessary
                    if (Position.StartsWith("CB"))
                    {
                        i += 1;
                    }
                    else if (Position.StartsWith("DT"))
                    {
                        i += 1;
                    }
                    else if (Position.StartsWith("WR"))
                    {
                        i += 2;
                    }

                    continue;
                }

                // Populate backup information
                NumBackups++;
                AppendBackupOVR(player.PlayerSchemeOvr);
            }
        }

        private void Reset()
        {
            // Reset all fields, excluding Target and Notes, back to their default values;
            StarterName = "";
            StarterAge = 0;
            StarterOVR = 0;
            StarterYearsRemain = 0;
            StarterSalary = 0;
            NumBackups = 0;
            BackupOVRs = "";
        }

        private void AppendBackupOVR(long ovr)
        {
            if (!String.IsNullOrEmpty(BackupOVRs))
            {
                BackupOVRs += ", " + ovr.ToString();
            }
            else
            {
                BackupOVRs = ovr.ToString();
            }
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
