using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabelBaseSys.Models;

namespace LabelBaseSys
{
    public class ContextView : INotifyPropertyChanged
    {


        public ObservableCollection<ARManager> ARManagers { get; }
        public ObservableCollection<Person> Persons { get; }

        private ARManager _selectedARManagers;
        public ARManager SelectedARManagers
        {
            get => _selectedARManagers;
            set
            {
                if (value == _selectedARManagers) return;
                _selectedARManagers = value;
                OnPropertyChanged();
            }
        }

        private Person _selectedPersons;
        public Person SelectedPerson
        {
            get => _selectedPersons;
            set
            {
                if(value==_selectedPersons) return;
                _selectedPersons = value;
                OnPropertyChanged();
            }
        }

        private IList<ARManager> _arManager;
        public IList<ARManager> ARManager
        {
            get => _arManager;
            set
            {
                if (value == _arManager) return;
                _arManager = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addPersonButton;
        public RelayCommand AddPersonButton
        {
            get
            {
                return _addPersonButton ?? (_addPersonButton = new RelayCommand(obj =>
                {
                    Person p = new Person();
                    p.PersonID = Persons.Count + 1;
                    Persons.Insert(Persons.Count, p);
                    SelectedPerson = p;
                }));
            }
        }

        private RelayCommand _addARManagerButton;
        public RelayCommand AddARManagerButton
        {
            get
            {
                return _addARManagerButton ?? (_addARManagerButton = new RelayCommand(obj =>
                {
                    
                    ARManager arm = new ARManager();
                    arm.ARManagerID = ARManagers.Count+1;
                    ARManagers.Insert(ARManagers.Count, arm);
                    SelectedARManagers = arm;
                }));
            }
        }

        private RelayCommand _saveBase;
        public RelayCommand SaveBase
        {
            get
            {
                return _saveBase ?? (_saveBase = new RelayCommand(obj =>
                {
                    Coderin сoderin = new Coderin();
                    var direct = AppDomain.CurrentDomain.BaseDirectory;
                    var ARMans = $"base/ARMans.lbs";
                    var Person = $"base/Persons.lbs";
                    ushort key = 0x6010;
                    StreamWriter swAR = new StreamWriter(direct+ARMans, false);
                    foreach(ARManager item in ARManagers)
                    {
                        string sandwich = $"{Convert.ToString(item.ARManagerID)};{item.ARManagerFirstname};{item.ARManagerSecondname};";
                        sandwich = сoderin.EncodDestruct(sandwich, key);
                        swAR.WriteLine(sandwich);
                    }

                    StreamWriter swPer = new StreamWriter(direct + Person, false);
                    foreach (Person item in Persons)
                    {
                        string sandwich = $"{Convert.ToString(item.PersonID)};{item.PersonNickname};{item.PersonFirstname};" +
                        $"{item.PersonSecondname};{item.PersonContract};{item.PersonLabelMember};{item.PersonFoundByWhom};" +
                        $"{item.PersonContract};"; 
                        sandwich = сoderin.EncodDestruct(sandwich, key);
                        swPer.WriteLine(sandwich);
                    }
                    
                    swAR.Close(); swPer.Close();
                }));
            }
        }

        public ContextView()
        {
            ARManagers = new ObservableCollection<ARManager> { };
            Persons = new ObservableCollection<Person> { };

            Coderin coderin = new Coderin();
            var direct = AppDomain.CurrentDomain.BaseDirectory;
            var ARMans = $"base/ARMans.lbs";
            var Person = $"base/Persons.lbs";
            string line; ushort key = 0x6010;
            StreamReader srAR = new StreamReader(direct + ARMans);
            while ((line = srAR.ReadLine()) != null)
            {
                line = coderin.EncodDestruct(line, key);
                string[] word = line.Split(';');
                var arm = new ARManager()
                {
                    ARManagerID = Convert.ToInt32(word[0]),
                    ARManagerFirstname = word[1],
                    ARManagerSecondname = word[2]
                };
                ARManagers.Add(arm);
            }

            StreamReader srPer = new StreamReader(direct + Person);
            while ((line = srPer.ReadLine()) != null)
            {
                line = coderin.EncodDestruct(line, key);
                string[] word = line.Split(';');
                var per = new Person()
                {
                    PersonID = Convert.ToInt32(word[0]),
                    PersonNickname = word[1],
                    PersonFirstname = word[2],
                    PersonSecondname = word[3],
                    PersonContact = word[4],
                    PersonLabelMember = Convert.ToBoolean(word[5]),
                    PersonFoundByWhom = Convert.ToInt32(word[6]),
                    PersonContract = Convert.ToInt32(word[7])
                };
                Persons.Add(per);
            }

            srAR.Close(); srPer.Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
