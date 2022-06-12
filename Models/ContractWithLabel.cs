using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Models
{
    public class ContractWithLabel : INotifyPropertyChanged
    {
        private int _contractLabelID;
        public int ContractLabelID
        {
            get => _contractLabelID;
            set
            {
                if (value == _contractLabelID) return;
                _contractLabelID = value;
                OnPropertyChanged();
            }
        }

        private bool _enableContract;
        public bool EnableContract
        {
            get => _enableContract;
            set
            {
                if (value == _enableContract) return;
                _enableContract = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataOfSingle;
        public DateTime DataOfSingle
        {
            get => _dataOfSingle;
            set
            {
                if (value == _dataOfSingle) return;
                _dataOfSingle = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateDeadline;
        public DateTime DateDeadline
        {
            get => _dateDeadline;
            set
            {
                if (value == _dateDeadline) return;
                _dateDeadline = value;
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
