using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelBaseSys.Models
{
    public class Person : INotifyPropertyChanged
    {

        private int _personID;
        public int PersonPersonID
        {
            get => _personID;
            set
            {
                if (value == _personID) return;
                _personID = value;
                OnPropertyChanged();
            }
        }

        private string _nickname;
        public string PersonNickname
        {
            get => _nickname;
            set
            {
                if (value == _nickname) return;
                _nickname = value;
                OnPropertyChanged();
            }
        }

        private string _firstname;
        public string PersonFirstname
        {
            get => _firstname;
            set
            {
                if (value == _firstname) return;
                _firstname = value;
                OnPropertyChanged();
            }
        }

        private string _secondname;
        public string PersonSecondname
        {
            get => _secondname;
            set
            {
                if (value == _secondname) return;
                _secondname = value;
                OnPropertyChanged();
            }
        }

        private string _contact;
        public string PersonContact
        {
            get => _contact;
            set
            {
                if (value == _contact) return;
                _contact = value;
                OnPropertyChanged();
            }
        }

        private bool _labelMember;
        public bool PersonLabelMember
        {
            get => _labelMember;
            set
            {
                if (value == _labelMember) return;
                _labelMember = value;
                OnPropertyChanged();
            }
        }

        private int _foundByWhom;
        public int PersonFoundByWhom
        {
            get => _foundByWhom;
            set
            {
                if (value == _foundByWhom) return;
                _foundByWhom = value;
                OnPropertyChanged();
            }
        }

        private int _contract;
        public int PersonContract
        {
            get => _contract;
            set
            {
                if (value == _contract) return;
                _contract = value;
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
