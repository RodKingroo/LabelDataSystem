using LabelSystem.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Globalization;

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
                    Person p = new Person();
                    p.PersonID = Persons.Count+1;
                    Persons.Add(p);
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
                    Music m = new Music();
                    m.TrackID = Persons.Count + 1;
                    Musics.Add(m);
                    SelectedMusics = m;
                }));
            }
        }

        private RelayCommand _infoButton;
        public RelayCommand InfoButton
        {
            get
            {
                return _infoButton ?? (_infoButton = new RelayCommand(obj =>
                {
                    Random r = new Random();
                    using(StreamWriter swInfo = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/information/{r.Next()}.rtf", false, Encoding.UTF8))
                    {
                        double income, allincome = 0, cleanincome=0, pricePerson = 0;
                        swInfo.WriteLine($"Количество учатсников лейбла: {Persons.Count}");
                        swInfo.WriteLine("\nСписок участников: ");
                        foreach (Person p in Persons)
                        {
                            
                            swInfo.WriteLine($"\t{p.PersonNickname} ({p.PersonFirstname} {p.PersonSecondname})");
                            foreach (Music m in Musics)
                            {
                                
                                if (p.PersonID == m.Person.PersonID)
                                {
                                    income = (m.Price.PriceSize*m.TrackCountSell)+(m.TrackCountAudition*0.0015);
                                    swInfo.WriteLine($"\t\t{m.TrackTitle}. — Доход с трека: {Math.Round(income,2)}$.");

                                    allincome += income-m.Expens;
                                }
                                
                            }
                            
                            foreach (ContractWithPerson cwp in ContractWithPersons)
                            {
                                if (p.PersonID == cwp.Person.PersonID) pricePerson = cwp.ContractWithPersonPrice;

                            }
                            cleanincome = allincome - pricePerson;
                            swInfo.WriteLine($"\n\t\t\t\tОбщий доход: {Math.Round(allincome, 2)}$");
                            swInfo.WriteLine($"\t\t\t\tПрайс исполнителя: {pricePerson}$");
                            swInfo.WriteLine($"\t\t\t\tЧистый доход: {Math.Round(cleanincome, 2)}$\n");

                            allincome += allincome;
                            cleanincome += cleanincome;
                        }

                        swInfo.WriteLine($"Общий доход лейбла: {Math.Round(allincome,2)}$");
                        swInfo.WriteLine($"Чистая прибыль: {Math.Round(cleanincome,2)}$");

                    }
                    Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}/information/");
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
                    ContractWithPerson cwp = new ContractWithPerson();
                    cwp.ContractWithPersonID = ContractWithPersons.Count+1;
                    ContractWithPersons.Add(cwp);
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
                    ARManager arm = new ARManager();
                    arm.ARManagerID = ARManagers.Count + 1;
                    ARManagers.Add(arm);
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
                    ContractWithLabel cwl = new ContractWithLabel();
                    cwl.ContractWithLabelID = ContractWithPersons.Count + 1;
                    ContractWithLabels.Add(cwl);
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
                    Price p = new Price();
                    p.PriceID = Prices.Count + 1;
                    Prices.Add(p);
                    SelectedPrices = p;
                }));
            }
        }


        private RelayCommand _export;
        public RelayCommand ExportButton
        {
            get
            {
                return _export ?? (_export = new RelayCommand(obj =>
                {
                    using(StreamWriter swPerson = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/export/person.csv", false, Encoding.UTF8)) {
                        swPerson.WriteLine("ID;Псевдоним;Имя;Фамилия;Контактные данные;A&R менеджер;Участник лейбла");
                        foreach (Person item in Persons)
                        {
                            string sandwich = $"{item.PersonID};{item.PersonNickname};{item.PersonFirstname};{item.PersonSecondname};" +
                                                $"{item.PersonContract};{item.ARManager.ARManagerID};{item.PersonLabelMember}";
                            swPerson.WriteLine(sandwich);
                        }
                        swPerson.Close();
                    }

                    using (StreamWriter swMusic = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/export/music.csv", false, Encoding.UTF8)){
                        swMusic.WriteLine("ID;Название;Стоимость;Исполнитель;Затраты;Количество прослушиваний;Количество продаж;Дата записи;Дата релиза;Воспроизведение на радио;Продажа в магазине;Контракт по аренде");
                        foreach (Music item in Musics)
                        {
                            string sandwich = $"{item.TrackID};{item.TrackTitle};{item.Price.PriceID};{item.Person.PersonID};" +
                                                $"{item.Expens};{item.TrackCountAudition};{item.TrackCountSell};" +
                                                $"{item.TrackDataRec.Value.ToString("dd/MM/yyyy")};" +
                                                $"{item.TrackDataRealise.Value.ToString("dd/MM/yyyy")};" +
                                                $"{item.EnableRadio};{item.PresenceInStore};{item.CWL.ContractWithLabelID}";
                            swMusic.WriteLine(sandwich);
                        }
                        swMusic.Close();
                    }

                    using (StreamWriter swCWP = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/export/cwp.csv", false, Encoding.UTF8)) {
                        swCWP.WriteLine("ID;Исполнитель;Действительность контракта;Дата подписания;Количество треков,прописанных в контракте;Количество готовых треков;Стоимость сотрудничества;Дата Окончания");
                        foreach (ContractWithPerson item in ContractWithPersons)
                        {
                            string sandwich = $"{item.ContractWithPersonID};{item.Person.PersonID};{item.ContractWithPersonEnable};" +
                                                $"{item.ContractWithPersonDateOfSingle.Value.ToString("dd/MM/yyyy")};{item.ContractWithPersonCountTrackUnder};" +
                                                $"{item.CountrackWithPersonCountReadyTrack};{item.ContractWithPersonPrice};" +
                                                $"{item.DateDeadLine.Value.ToString("dd/MM/yyyy")}";
                            swCWP.WriteLine(sandwich);
                        }
                        swCWP.Close();
                    }

                    using (StreamWriter swCWL = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/export/cwl.csv", false, Encoding.UTF8))
                    {
                        swCWL.WriteLine("ID;Названия компаний;Стоимость;Дата Подписания;Дата окончания контракта");
                        foreach (ContractWithLabel item in ContractWithLabels)
                        {
                            string sandwich = $"{item.ContractWithLabelID};{item.NameLabel};{item.PriceContract};" +
                                                $"{item.ContractWithLabelDataOfSingle.Value.ToString("dd/MM/yyyy")};" +
                                                $"{item.ContractWithLabelDataDeadline.Value.ToString("dd/MM/yyyy")}";
                            swCWL.WriteLine(sandwich);
                        }
                        swCWL.Close();
                    }

                    using (StreamWriter swARM = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/export/arm.csv", false, Encoding.UTF8))
                    {
                        swARM.WriteLine("ID;Имя;Фамилия");
                        foreach (ARManager item in ARManagers)
                        {
                            string sandwich = $"{item.ARManagerID};{item.Firstname};{item.Secondname}";
                            swARM.WriteLine(sandwich);
                        }
                        swARM.Close();
                    }

                    using (StreamWriter swPrice = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/export/price.csv", false, Encoding.UTF8))
                    {
                        swPrice.WriteLine("ID;Стоимость");
                        foreach (Price item in Prices)
                        {
                            string sandwich = $"{item.PriceID};{item.PriceSize}";
                            swPrice.WriteLine(sandwich);
                        }
                    swPrice.Close();
                    }

                    Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}/export/");

                }));
            }
        }

        private RelayCommand _importButton;
        public RelayCommand ImportButton
        {
            get
            {
                return _importButton ?? (_importButton = new RelayCommand(obj =>
                {
                    string linePerson, lineMusic, lineCWP, lineCWL, lineARM, linePrice;
                    
                    using (StreamReader srARM = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/import/ARMan.csv")) { 
                        lineARM = srARM.ReadLine();
                        while ((lineARM = srARM.ReadLine()) != null)
                        {
                            string[] word = lineARM.Split(';');
                            ARManager arm = new ARManager();
                            arm.ARManagerID = int.Parse(word[0]); arm.Firstname = word[1]; arm.Secondname = word[2];
                            ARManagers.Add(arm);
                            SelectedARManager = arm;
                        }
                        srARM.Close();
                    }

                    using(StreamReader srPrice = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/import/price.csv")) {
                        linePrice = srPrice.ReadLine();
                        while ((linePrice = srPrice.ReadLine()) != null)
                        {
                            string[] word = linePrice.Split(';');
                            Price p = new Price();
                            p.PriceID = int.Parse(word[0]); p.PriceSize = double.Parse(word[1]);
                            Prices.Add(p);
                            SelectedPrices = p;
                        }
                        srPrice.Close();
                    }

                    using (StreamReader srCWL = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/import/ContractWithLabel.csv")) { 
                        lineCWL = srCWL.ReadLine();
                        while ((lineCWL = srCWL.ReadLine()) != null)
                        {
                            string[] word = lineCWL.Split(';');
                            ContractWithLabel cwl = new ContractWithLabel();
                            cwl.ContractWithLabelID = int.Parse(word[0]); cwl.NameLabel = word[1];
                            cwl.PriceContract = double.Parse(word[2]);
                            cwl.ContractWithLabelDataOfSingle = DateTime.ParseExact(word[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                            cwl.ContractWithLabelDataDeadline = DateTime.ParseExact(word[4], "dd.MM.yyyy", CultureInfo.InvariantCulture);

                            ContractWithLabels.Add(cwl);
                            SelectedContractWithLabel = cwl;
                        }
                        srCWL.Close();
                    }

                    using (StreamReader srPerson = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/import/person.csv")) {
                        linePerson = srPerson.ReadLine();
                        while ((linePerson = srPerson.ReadLine()) != null)
                        {
                            string[] word = linePerson.Split(';');
                            Person p = new Person();
                            p.PersonID = int.Parse(word[0]); p.PersonNickname = word[1]; p.PersonFirstname = word[2];
                            p.PersonSecondname = word[3]; p.PersonContract = word[4];
                            foreach (ARManager item in ARManagers)
                            {
                                if (item.ARManagerID == int.Parse(word[5])) p.ARManager = item;
                            }
                            p.PersonLabelMember = bool.Parse(word[6]);

                            Persons.Add(p);
                            SelectedPersons = p;
                        }
                        srPerson.Close();
                    }
                    
                    using(StreamReader srCWP = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/import/ContractWithPerson.csv"))
                    {
                        lineCWP = srCWP.ReadLine();

                        while ((lineCWP = srCWP.ReadLine()) != null)
                        {
                            string[] word = lineCWP.Split(';');
                            ContractWithPerson cwp = new ContractWithPerson();

                            cwp.ContractWithPersonID = int.Parse(word[0]);
                            foreach(Person item in Persons)
                            {
                                if (item.PersonID == int.Parse(word[1])) cwp.Person = item;
                            }
                            cwp.ContractWithPersonEnable = bool.Parse(word[2]);
                            cwp.ContractWithPersonDateOfSingle = DateTime.ParseExact(word[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                            cwp.ContractWithPersonCountTrackUnder = int.Parse(word[4]);
                            cwp.CountrackWithPersonCountReadyTrack = int.Parse(word[5]);
                            cwp.ContractWithPersonPrice = int.Parse(word[6]);
                            cwp.DateDeadLine = DateTime.ParseExact(word[7], "dd.MM.yyyy", CultureInfo.InvariantCulture);

                            ContractWithPersons.Add(cwp);
                            SelectedContractWithPersons = cwp;
                        }

                        srCWP.Close();
                    }
                    using (StreamReader srMusic = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/import/Music.csv")) {
                        lineMusic = srMusic.ReadLine();

                        while ((lineMusic = srMusic.ReadLine()) != null)
                        {
                            string[] word = lineMusic.Split(';');
                            Music m = new Music();

                            m.TrackID = int.Parse(word[0]);
                            m.TrackTitle = word[1];
                            foreach(Price item in Prices)
                            {
                                if (item.PriceID == int.Parse(word[2])) m.Price = item;
                            }
                            foreach(Person item in Persons)
                            {
                                if (item.PersonID == int.Parse(word[3])) m.Person = item;
                            }
                            m.Expens = int.Parse(word[4]);
                            m.TrackCountAudition = int.Parse(word[5]);
                            m.TrackCountSell = int.Parse(word[6]);
                            m.TrackDataRec = DateTime.ParseExact(word[7], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                            m.TrackDataRealise = DateTime.ParseExact(word[8], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                            m.EnableRadio = bool.Parse(word[9]);
                            m.PresenceInStore = bool.Parse(word[10]);
                            foreach(ContractWithLabel item in ContractWithLabels)
                            {
                                if (item.ContractWithLabelID == int.Parse(word[11])) m.CWL = item;
                            }

                            Musics.Add(m);
                            SelectedMusics = m;
                        }

                        srMusic.Close();
                    }
                }));
            }
        }

        private RelayCommand _cleanButton;
        public RelayCommand NewTableButton
        {
            get
            {
                return _cleanButton ?? (_cleanButton = new RelayCommand(obj =>
                {
                    Persons.Clear(); ARManagers.Clear(); Musics.Clear(); Prices.Clear();
                    ContractWithLabels.Clear(); ContractWithPersons.Clear();
                }));
            }
        }

        public ContextView()
        {
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
