using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Model
{
    public class ContractWithLabel : INotifyPropertyChanged
    {

        private int _id;
        public int ContractWithLabelID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private bool _enable;
        public bool ContractWithLabelEnableContract
        {
            get => _enable;
            set
            {
                _enable = value;
                OnPropertyChanged();
            }
        }

        private string _namela;
        public string NameLabel
        {
            get => _namela;
            set
            {
                _namela = value;
                OnPropertyChanged();
            }
        }

        private double _prcontract;
        public double PriceContract
        {
            get => _prcontract;
            set
            {
                _prcontract = value;
                OnPropertyChanged();
            }
        }

        private Nullable<DateTime> _single = null;
        public Nullable<DateTime> ContractWithLabelDataOfSingle
        {
            get
            {
                if (_single == null) _single = DateTime.Today;
                return _single;
            }
            set
            {
                _single = value;
                OnPropertyChanged();
            }
        }

        private Nullable<DateTime> _deadline = null;
        public Nullable<DateTime> ContractWithLabelDataDeadline
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
