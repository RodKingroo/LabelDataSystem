using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Models
{
    public class Expens : INotifyPropertyChanged
    {
        private int _expensID;
        public int ExpensID
        {
            get => _expensID;
            set
            {
                if (value == _expensID) return;
                _expensID = value;
                OnPropertyChanged();
            }
        }

        private int _countExpens;
        public int CountExpens
        {
            get => _countExpens;
            set
            {
                if (value == _countExpens) return;
                _countExpens = value;
                OnPropertyChanged();
            }
        }

        private string _purch;
        public string Purch
        {
            get => _purch;
            set
            {
                if (value == _purch) return;
                _purch = value;
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
