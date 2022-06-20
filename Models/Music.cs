using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Model
{
    public class Music : INotifyPropertyChanged
    {
        private int _id;
        public int TrackID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public string TrackTitle
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private Price _priceID;
        public Price Price
        {
            get => _priceID;
            set
            {
                _priceID = value;
                OnPropertyChanged();
            }
        }

        private ContractWithPerson _Cwp;
        public ContractWithPerson CWP
        {
            get => _Cwp;
            set
            {
                _Cwp = value;
                OnPropertyChanged();
            }
        }

        private double _expens;
        public double Expens
        {
            get => _expens;
            set
            {
                _expens = value;
                OnPropertyChanged();
            }
        }

        private int _audition;
        public int TrackCountAudition
        {
            get => _audition;
            set
            {
                _audition = value;
                OnPropertyChanged();
            }
        }

        private int _sell;
        public int TrackCountSell
        {
            get => _sell;
            set
            {
                _sell = value;
                OnPropertyChanged();
            }
        }

        private Nullable<DateTime> _rec = null;
        public Nullable<DateTime> TrackDataRec
        {
            get
            {
                if (_rec == null) _rec = DateTime.Today;
                return _rec;
            }
            set
            {
                _rec = value;
                OnPropertyChanged();
            }
        }

        private Nullable<DateTime> _realise = null;
        public Nullable<DateTime> TrackDataRealise
        {
            get
            {
                if (_realise == null) _realise = DateTime.Today;
                return _realise;
            }
            set
            {
                _realise = value;
                OnPropertyChanged();
            }
        }

        private bool _radio;
        public bool EnableRadio
        {
            get => _radio;
            set
            {
                _radio = value;
                OnPropertyChanged();
            }
        }

        private bool _sellintstore;
        public bool PresenceInStore
        {
            get => _sellintstore;
            set
            {
                _sellintstore = value;
                OnPropertyChanged();
            }
        }

        private ContractWithLabel _labelcontrackid;
        public ContractWithLabel CWL
        {
            get => _labelcontrackid;
            set
            {
                _labelcontrackid = value;
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
