using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Model
{
    public class ContractWithPerson : INotifyPropertyChanged
    {

        private int _id;
        public int ContractWithPersonID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private Person _personID;
        public Person Person
        {
            get => _personID;
            set
            {
                _personID = value;
                OnPropertyChanged();
            }
        }

        private bool _enable;
        public bool ContractWithPersonEnable
        {
            get => _enable;
            set
            {
                _enable = value;
                OnPropertyChanged();
            }
        }

        private Nullable<DateTime> _dateOfSingle = null;
        public Nullable<DateTime> ContractWithPersonDateOfSingle
        {
            get
            {
                if (_dateOfSingle == null) _dateOfSingle = DateTime.Today;
                return _dateOfSingle;
            }
            set
            {
                _dateOfSingle = value;
                OnPropertyChanged();
            }
        }


        private int _countundertrack;
        public int ContractWithPersonCountTrackUnder
        {
            get => _countundertrack;
            set
            {
                _countundertrack = value;
                OnPropertyChanged();
            }
        }

        private int _countreadytrack;
        public int CountrackWithPersonCountReadyTrack
        {
            get => _countreadytrack;
            set
            {
                _countreadytrack = value;
                OnPropertyChanged();
            }
        }

        private double _price;
        public double ContractWithPersonPrice
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        private Nullable<DateTime> _deadline = null;
        public Nullable<DateTime> DateDeadLine
        {
            get
            {
                if (_deadline == null) _deadline = DateTime.Today;
                return _deadline;
            }
            set
            {
                _deadline = value;
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
