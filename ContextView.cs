using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabelBaseSys.Models;

namespace LabelBaseSys
{
    public class ContextView
    {

        ObservableCollection<Person> Persons { get; set; }

    }
}
