using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Text;
using XFormsAppTutorial.Types;

namespace XFormsAppTutorial.Models
{
    static public class CoffeeProvider
    {
        static public ObservableCollection<CoffeeType> coffees = new ObservableCollection<CoffeeType>();
    }
}
