using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


using LabelSystem.Model;

namespace LabelSystem
{
    public class ContextView : INotifyPropertyChanged
    {


        public ObservableCollection<Person> Persons { get; }
        public ObservableCollection<ContractWithLabel> ContractWithLabels { get; }
        public ObservableCollection<ContractWithPerson> ContractWithPersons { get; }
        public ObservableCollection<Music> Musics { get; }
        public ObservableCollection<ARManager> ARManagers { get; }
        public ObservableCollection<Price> Prices { get; }

        private Person _selectedPersons;
        public Person SelectedPersons
        {
            get => _selectedPersons;
            set
            {
                _selectedPersons = value;
                OnPropertyChanged();
            }
        }

        private Music _selectedMusic;
        public Music SelectedMusics
        {
            get => _selectedMusic;
            set
            {
                _selectedMusic = value;
                OnPropertyChanged();
            }
        }
        private ContractWithPerson _selectedContractWithPersons;
        public ContractWithPerson SelectedContractWithPersons
        {
            get => _selectedContractWithPersons;
            set
            {
                _selectedContractWithPersons = value;
                OnPropertyChanged();
            }
        }

        private ContractWithLabel _selectedContractWithLabel;
        public ContractWithLabel SelectedContractWithLabel
        {
            get => _selectedContractWithLabel;
            set
            {
                _selectedContractWithLabel = value;
                OnPropertyChanged();
            }
        }

        private ARManager _selectedARManager;
        public ARManager SelectedARManager
        {
            get => _selectedARManager;
            set
            {
                _selectedARManager = value;
                OnPropertyChanged();
            }
        }

        private Price _selectedPrice;
        public Price SelectedPrices
        {
            get => _selectedPrice;
            set
            {
                _selectedPrice = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addPerson;
        public RelayCommand AddPersonButton
        {
            get
            {
                return _addPerson ?? (_addPerson = new RelayCommand(obj =>
                {
                    Random r = new Random();
                    Person p = new Person();
                    p.PersonID = r.Next(99999);
                    Persons.Insert(Persons.Count, p);
                    SelectedPersons = p;
                }));
            }
        }

        private RelayCommand _addMusic;
        public RelayCommand AddMusicButton
        {
            get
            {
                return _addMusic ?? (_addMusic = new RelayCommand(obj =>
                {
                    Random r = new Random();
                    Music m = new Music();
                    m.TrackID = r.Next(99999);
                    Musics.Insert(Musics.Count, m);
                    SelectedMusics = m;
                }));
            }
        }

        private RelayCommand _addContractwithperson;
        public RelayCommand AddContractWithPerson
        {
            get
            {
                return _addContractwithperson ?? (_addContractwithperson = new RelayCommand(obj =>
                {
                    Random r = new Random();
                    ContractWithPerson cwp = new ContractWithPerson();
                    cwp.ContractWithPersonID = r.Next(99999);
                    ContractWithPersons.Insert(ContractWithPersons.Count, cwp);
                    SelectedContractWithPersons = cwp;
                }));
            }
        }

        private RelayCommand _addARManagerbutton;
        public RelayCommand AddARManButton
        {
            get
            {
                return _addARManagerbutton ?? (_addARManagerbutton = new RelayCommand(obj =>
                {
                    Random r = new Random();
                    ARManager arm = new ARManager();
                    arm.ARManagerID = r.Next(99999);
                    ARManagers.Insert(ARManagers.Count, arm);
                    SelectedARManager = arm;
                }));
            }
        }

        private RelayCommand _addContractwithlabel;
        public RelayCommand AddContractWithLabel
        {
            get
            {
                return _addContractwithlabel ?? (_addContractwithlabel = new RelayCommand(obj =>
                {
                    Random r = new Random();
                    ContractWithLabel cwl = new ContractWithLabel();
                    cwl.ContractWithLabelID = r.Next(99999);
                    ContractWithLabels.Insert(ContractWithLabels.Count, cwl);
                    SelectedContractWithLabel = cwl;
                }));
            }
        }

        private RelayCommand _addPriceButton;
        public RelayCommand AddPriceButton
        {
            get
            {
                return _addPriceButton ?? (_addPriceButton = new RelayCommand(obj =>
                {
                    Random r = new Random();
                    Price p = new Price();
                    p.PriceID = r.Next(99999);
                    Prices.Insert(Prices.Count, p);
                    SelectedPrices = p;
                }));
            }
        }



        public ContextView(){
            Persons = new ObservableCollection<Person>() { };
            ContractWithLabels = new ObservableCollection<ContractWithLabel>() { };
            ContractWithPersons = new ObservableCollection<ContractWithPerson>() { };
            Musics = new ObservableCollection<Music>() { };
            ARManagers = new ObservableCollection<ARManager>() { };
            Prices = new ObservableCollection<Price>() { };

            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
