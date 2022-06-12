using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabelBaseSys.Models;

namespace LabelBaseSys
{
    public class ContextView : INotifyPropertyChanged
    {

        ObservableCollection<Person> Persons { get; set; }
        //ObservableCollection<ContractWithPerson> ContractWithPersons { get; set; }
        //ObservableCollection<Music> Musics { get; set; }

        private Person _selectedPersons;
        public Person SelectedPersons
        {
            get { return _selectedPersons; }
            set
            {
                if (value == _selectedPersons) return;
                _selectedPersons = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addPersonButton;
        public RelayCommand AddButton
        {
            get
            {
                return _addPersonButton ?? (_addPersonButton = new RelayCommand(obj=>
                {
                    Person p = new Person();
                    Persons.Insert(Persons.Count - 1, p);
                    SelectedPersons = p;
                }));
            }
        }

        public ContextView()
        {
            Persons = new ObservableCollection<Person>
            {
            };
            //ContractWithPersons = new ObservableCollection<ContractWithPerson>();
            //Musics = new ObservableCollection<Music>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
