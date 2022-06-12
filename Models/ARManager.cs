using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelBaseSys.Models
{
    public class ARManager : INotifyPropertyChanged
    {

        private int _arManagerID;
        public int ARManagerID
        {
            get => _arManagerID;
            set
            {
                if (value == _arManagerID) return;
                _arManagerID = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;
        public string ARManagerFirstname
        {
            get => _firstName;
            set
            {
                if(value == _firstName) return;
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _secondName;
        public string ARManagerSecondname
        {
            get => _secondName;
            set
            {
                if (value == _secondName) return;
                _secondName = value;
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
