using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaddenCompanion
{
    public class MaddenAction : INotifyPropertyChanged
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

        private string _action = "";
        public string Action
        {
            get
            {
                return _action;
            }

            set
            {
                _action = value;
                NotifyPropertyChanged("Action");
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
