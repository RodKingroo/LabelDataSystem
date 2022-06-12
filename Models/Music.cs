using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelBaseSys.Models
{
    public class Music : INotifyPropertyChanged
    {
        private int _musicID;
        public int MusicID
        {
            get => _musicID;
            set
            {
                if (value ==_musicID) return;
                _musicID = value;
                OnPropertyChanged();
            }
        }

        private int _personID;
        public int MusicPersonID
        {
            get => _personID;
            set
            {
                if (value == _personID) return;
                _personID = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public string MusicTitle
        {
            get => _title;
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        private int _price;
        public int MusicPrice
        {
            get => _price;
            set
            {
                if (value == _price) return;
                _price = value;
                OnPropertyChanged();
            }
        }

        private int _countAudition;
        public int MusicCountAudition
        {
            get => _countAudition;
            set
            {
                if (value == _countAudition) return;
                _countAudition = value;
                OnPropertyChanged();
            }
        }

        private int _countSell;
        public int MusicCountSell
        {
            get => _countSell;
            set
            {
                if (value == _countSell) return;
                _countSell = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataRec;
        public DateTime MusicDataRec
        {
            get => _dataRec;
            set
            {
                if (value == _dataRec) return;
                _dataRec = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataRealise;
        public DateTime MusicDataRealise
        {
            get => _dataRealise;
            set
            {
                if (value == _dataRealise) return;
                _dataRealise = value;
                OnPropertyChanged();
            }
        }

        private bool _enableRadio;
        public bool MusicEnableRadio
        {
            get => _enableRadio;
            set
            {
                if (value == _enableRadio) return;
                _enableRadio = value;
                OnPropertyChanged();
            }
        }

        private bool _presenceInStores;
        public bool MusicPresenceInStores
        {
            get => _presenceInStores;
            set
            {
                if (value == _presenceInStores) return;
                _presenceInStores = value;
                OnPropertyChanged();
            }
        }

        private int _addContract;
        public int MusicAddContract
        {
            get => _addContract;
            set
            {
                if (value == _addContract) return;
                _addContract = value;
                OnPropertyChanged();
            }
        }


        private int _expens;
        public int MusicExpens
        {
            get => _expens;
            set
            {
                if (value == _expens) return;
                _expens = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
