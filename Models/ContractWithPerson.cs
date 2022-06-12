using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Models
{
    public class ContractWithPerson : INotifyPropertyChanged
    {

        private int _contractID;
        public int ContractWithPersonID
        {
            get=> _contractID;
            set
            {
                if (value == _contractID) return;
                _contractID = value;
                OnPropertyChanged();
            }
        }

        private bool _enableContract;
        public bool EnableContractWithPerson
        {
            get => _enableContract;
            set
            {
                if(value==_enableContract) return;
                _enableContract = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataOfSign;
        public DateTime DataOfSignContractWithPerson
        {
            get => _dataOfSign;
            set
            {
                if (value == _dataOfSign) return;
                _dataOfSign = value;
                OnPropertyChanged();
            }
        }

        private int _countTrackUnderContract;
        public int CountTrackUnderContractWithPerson
        {
            get => _countTrackUnderContract;
            set
            {
                if (value == _countTrackUnderContract) return;
                _countTrackUnderContract = value;
                OnPropertyChanged();
            }
        }

        private int _countTrackReady;
        public int CountTrackFinishContractWithPerson
        {
            get => _countTrackReady;
            set
            {
                if (value == _countTrackReady) return;
                _countTrackReady = value;
                OnPropertyChanged();
            }
        }

        private int _price;
        public int PriceContractWithPerson
        {
            get => _price;
            set
            {
                if(value==_price) return;
                _price = value;
                OnPropertyChanged();
            }
        }

        private int _dataDeadline;
        public int DataDeadlineContractWithPerson
        {
            get => _dataDeadline;
            set
            {
                if (value == _dataDeadline) return;
                _dataDeadline = value;
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
