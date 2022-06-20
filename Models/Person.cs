using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Model
{
    public class Person : INotifyPropertyChanged
    {


        private int _id;
        public int PersonID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _nick;
        public string PersonNickname
        {
            get => _nick;
            set
            {
                _nick = value;
                OnPropertyChanged();
            }
        }

        private string _first;
        public string PersonFirstname
        {
            get => _first;
            set
            {
                _first = value;
                OnPropertyChanged();
            }
        }

        private string _second;
        public string PersonSecondname
        {
            get => _second;
            set
            {
                _second = value;
                OnPropertyChanged();
            }
        }

        private string _contact;
        public string PersonContract
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged();
            }
        }

        private bool _labelmember;
        public bool PersonLabelMember
        {
            get => _labelmember;
            set
            {
                _labelmember = value;
                OnPropertyChanged();
            }
        }

        private ARManager _arManager;
        public ARManager ARManager
        {
            get => _arManager;
            set
            {
                _arManager = value;
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
