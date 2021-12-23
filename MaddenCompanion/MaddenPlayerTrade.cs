using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaddenCompanion
{
    public class MaddenPlayerTrade: INotifyPropertyChanged
    {
        private string _playerName = "";
        public string PlayerName
        {
            get
            {
                return _playerName;
            }

            set
            {
                _playerName = value;
                NotifyPropertyChanged("PlayerName");
            }
        }

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

        private int _overall = 0;
        public int Overall
        {
            get
            {
                return _overall;
            }

            set
            {
                _overall = value;
                NotifyPropertyChanged("Overall");
            }
        }



        private string _bearsDesire = "";
        public string BearsDesire
        {
            get
            {
                return _bearsDesire;
            }

            set
            {
                _bearsDesire = value;
                NotifyPropertyChanged("BearsDesire");
            }
        }

        private string _bengalsDesire = "";
        public string BengalsDesire
        {
            get
            {
                return _bengalsDesire;
            }

            set
            {
                _bengalsDesire = value;
                NotifyPropertyChanged("BengalsDesire");
            }
        }

        private string _billsDesire = "";
        public string BillsDesire
        {
            get
            {
                return _billsDesire;
            }

            set
            {
                _billsDesire = value;
                NotifyPropertyChanged("BillsDesire");
            }
        }

        private string _broncosDesire = "";
        public string BroncosDesire
        {
            get
            {
                return _broncosDesire;
            }

            set
            {
                _broncosDesire = value;
                NotifyPropertyChanged("BroncosDesire");
            }
        }

        private string _brownsDesire = "";
        public string BrownsDesire
        {
            get
            {
                return _brownsDesire;
            }

            set
            {
                _brownsDesire = value;
                NotifyPropertyChanged("BrownsDesire");
            }
        }

        private string _bucaneersDesire = "";
        public string BucaneersDesire
        {
            get
            {
                return _bucaneersDesire;
            }

            set
            {
                _bucaneersDesire = value;
                NotifyPropertyChanged("BucaneersDesire");
            }
        }

        private string _cardinalsDesire = "";
        public string CardinalsDesire
        {
            get
            {
                return _cardinalsDesire;
            }

            set
            {
                _cardinalsDesire = value;
                NotifyPropertyChanged("CardinalsDesire");
            }
        }

        private string _chargersDesire = "";
        public string ChargersDesire
        {
            get
            {
                return _chargersDesire;
            }

            set
            {
                _chargersDesire = value;
                NotifyPropertyChanged("ChargersDesire");
            }
        }

        private string _cheifsDesire = "";
        public string CheifsDesire
        {
            get
            {
                return _cheifsDesire;
            }

            set
            {
                _cheifsDesire = value;
                NotifyPropertyChanged("CheifsDesire");
            }
        }

        private string _coltsDesire = "";
        public string ColtsDesire
        {
            get
            {
                return _coltsDesire;
            }

            set
            {
                _coltsDesire = value;
                NotifyPropertyChanged("ColtsDesire");
            }
        }

        private string _cowboysDesire = "";
        public string CowboysDesire
        {
            get
            {
                return _cowboysDesire;
            }

            set
            {
                _cowboysDesire = value;
                NotifyPropertyChanged("CowboysDesire");
            }
        }

        private string _dolphinsDesire = "";
        public string DolphinsDesire
        {
            get
            {
                return _dolphinsDesire;
            }

            set
            {
                _dolphinsDesire = value;
                NotifyPropertyChanged("DolphinsDesire");
            }
        }

        private string _eaglesDesire = "";
        public string EaglesDesire
        {
            get
            {
                return _eaglesDesire;
            }

            set
            {
                _eaglesDesire = value;
                NotifyPropertyChanged("EaglesDesire");
            }
        }

        private string _falconsDesire = "";
        public string FalconsDesire
        {
            get
            {
                return _falconsDesire;
            }

            set
            {
                _falconsDesire = value;
                NotifyPropertyChanged("FalconsDesire");
            }
        }

        private string _fortyNinersDesire = "";
        public string FortyNinersDesire
        {
            get
            {
                return _fortyNinersDesire;
            }

            set
            {
                _fortyNinersDesire = value;
                NotifyPropertyChanged("FortyNinersDesire");
            }
        }

        private string _giantsDesire = "";
        public string GiantsDesire
        {
            get
            {
                return _giantsDesire;
            }

            set
            {
                _giantsDesire = value;
                NotifyPropertyChanged("GiantsDesire");
            }
        }

        private string _jaguarsDesire = "";
        public string JaguarsDesire
        {
            get
            {
                return _jaguarsDesire;
            }

            set
            {
                _jaguarsDesire = value;
                NotifyPropertyChanged("JaguarsDesire");
            }
        }

        private string _jetsDesire = "";
        public string JetsDesire
        {
            get
            {
                return _jetsDesire;
            }

            set
            {
                _jetsDesire = value;
                NotifyPropertyChanged("JetsDesire");
            }
        }

        private string _lionsDesire = "";
        public string LionsDesire
        {
            get
            {
                return _lionsDesire;
            }

            set
            {
                _lionsDesire = value;
                NotifyPropertyChanged("LionsDesire");
            }
        }

        private string _packersDesire = "";
        public string PackersDesire
        {
            get
            {
                return _packersDesire;
            }

            set
            {
                _packersDesire = value;
                NotifyPropertyChanged("PackersDesire");
            }
        }

        private string _panthersDesire = "";
        public string PanthersDesire
        {
            get
            {
                return _panthersDesire;
            }

            set
            {
                _panthersDesire = value;
                NotifyPropertyChanged("PanthersDesire");
            }
        }

        private string _patriotsDesire = "";
        public string PatriotsDesire
        {
            get
            {
                return _patriotsDesire;
            }

            set
            {
                _patriotsDesire = value;
                NotifyPropertyChanged("PatriotsDesire");
            }
        }

        private string _raidersDesire = "";
        public string RaidersDesire
        {
            get
            {
                return _raidersDesire;
            }

            set
            {
                _raidersDesire = value;
                NotifyPropertyChanged("RaidersDesire");
            }
        }

        private string _ramsDesire = "";
        public string RamsDesire
        {
            get
            {
                return _ramsDesire;
            }

            set
            {
                _ramsDesire = value;
                NotifyPropertyChanged("RamsDesire");
            }
        }

        private string _ravensDesire = "";
        public string RavensDesire
        {
            get
            {
                return _ravensDesire;
            }

            set
            {
                _ravensDesire = value;
                NotifyPropertyChanged("RavensDesire");
            }
        }

        private string _redskinsDesire = "";
        public string RedskinsDesire
        {
            get
            {
                return _redskinsDesire;
            }

            set
            {
                _redskinsDesire = value;
                NotifyPropertyChanged("RedskinsDesire");
            }
        }

        private string _saintsDesire = "";
        public string SaintsDesire
        {
            get
            {
                return _saintsDesire;
            }

            set
            {
                _saintsDesire = value;
                NotifyPropertyChanged("SaintsDesire");
            }
        }

        private string _seahawksDesire = "";
        public string SeahawksDesire
        {
            get
            {
                return _seahawksDesire;
            }

            set
            {
                _seahawksDesire = value;
                NotifyPropertyChanged("SeahawksDesire");
            }
        }

        private string _steelersDesire = "";
        public string SteelersDesire
        {
            get
            {
                return _steelersDesire;
            }

            set
            {
                _steelersDesire = value;
                NotifyPropertyChanged("SteelersDesire");
            }
        }

        private string _texansDesire = "";
        public string TexansDesire
        {
            get
            {
                return _texansDesire;
            }

            set
            {
                _texansDesire = value;
                NotifyPropertyChanged("TexansDesire");
            }
        }

        private string _titansDesire = "";
        public string TitansDesire
        {
            get
            {
                return _titansDesire;
            }

            set
            {
                _titansDesire = value;
                NotifyPropertyChanged("TitansDesire");
            }
        }

        private string _vikingsDesire = "";
        public string VikingsDesire
        {
            get
            {
                return _vikingsDesire;
            }

            set
            {
                _vikingsDesire = value;
                NotifyPropertyChanged("VikingsDesire");
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
