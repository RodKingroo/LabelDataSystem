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
                    var path = Path.Combine(direct, ARMans);
                    ushort key = 0x6010;
                    StreamWriter sw = new StreamWriter(path, false);
                    foreach(ARManager item in ARManagers)
                    {
                        string sandwich = $"{Convert.ToString(item.ARManagerID)};{item.ARManagerFirstname};{item.ARManagerSecondname};";
                        sandwich = сoderin.EncodDestruct(sandwich, key);
                        sw.WriteLine(sandwich);
                    }
                    sw.Close();
                }));
            }
        }

        public ContextView()
        {
            ARManagers = new ObservableCollection<ARManager> { };

            Coderin coderin = new Coderin();
            var direct = AppDomain.CurrentDomain.BaseDirectory;
            var ARMans = $"base/ARMans.lbs";
            var path = Path.Combine(direct, ARMans);
            StreamReader sr = new StreamReader(path);
            string line; ushort key = 0x6010;
            while ((line = sr.ReadLine()) != null)
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

            sr.Close();
        }


        /*ObservableCollection<Person> Persons { get; set; }
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
        public RelayCommand AddPersonButton
        {
            get
            {
                return _addPersonButton ?? (_addPersonButton = new RelayCommand(obj=>
                {
                    Person p = new Person();
                    Persons.Insert(Persons.Count, p);
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
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
