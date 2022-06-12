using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Models
{
    public class Music : INotifyPropertyChanged
    {
        private int _musicID;
        public int PK_MusicID
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
        public int AY_PersonID
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
        public string Title
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
        public int Price
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
        public int CountAudition
        {
            get => _countAudition;
            set
            {
                if (value == _countAudition) return;
                _price = value;
                OnPropertyChanged();
            }
        }

        private int _countSell;
        public int CountSell
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
        public DateTime DataRec
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
        public DateTime DataRealise
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
        public bool EnableRadio
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
        public bool PresenceInStores
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
        public int AddContract
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
        public int Expens
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
