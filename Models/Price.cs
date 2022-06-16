using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelSystem.Model
{
    public class Price : INotifyPropertyChanged
    {

        private int _id;
        public int PriceID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private double _size;
        public double PriceSize
        {
            get => _size;
            set
            {
                _size = value;
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
