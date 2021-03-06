using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Model
{
    public class ARManager : INotifyPropertyChanged
    {

        private int _id;
        public int ARManagerID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _first;
        public string Firstname
        {
            get => _first;
            set
            {
                _first = value;
                OnPropertyChanged();
            }
        }

        private string _second;
        public string Secondname
        {
            get => _second;
            set
            {
                _second = value;
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
