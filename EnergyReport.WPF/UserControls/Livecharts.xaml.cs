﻿using EnergyReport.DbConnector;
using EnergyReport.DbConnector.Intf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnergyReport.WPF.UserControls
{
   
    public partial class Livecharts : UserControl
    {

        private IRealestate typId;
        private IEnum_Type itemId;
        private readonly Dictionary<IRealestate, string> _keyValuePairs;
        private readonly Dictionary<IEnum_Type, string> _KeyEnumtyps;
        static Connector conn = new Connector();


        IList<IRealestate> thelist = conn.SelectAllRealestate();
        IList<IEnum_Type> enum_typeslist = conn.SelectAllEnumType();
        IList<IReading> readinglist = conn.SelectAlReding();

        public Livecharts()
        {
            _keyValuePairs = new Dictionary<IRealestate, string>();
            _KeyEnumtyps = new Dictionary<IEnum_Type, string>();

            InitializeComponent();

            string tmpStr = "";
            foreach (var realestate in thelist)
            {
                tmpStr = realestate.FirstName + ", " + realestate.LastName + ", " + realestate.Firm + ", " + realestate.Location + ", " + realestate.Postcode + ", " + realestate.Street + ", " + realestate.HouseNumber;
                _keyValuePairs.Add(realestate, tmpStr);
            }

            string enumtpystr = "";
            foreach (var typ in enum_typeslist)
            {
                enumtpystr = typ.Name + ", " + typ.ID;
                _KeyEnumtyps.Add(typ, enumtpystr);
            }
        }

        private void REitems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = REitems.SelectedIndex;
            if (selectedIndex >= 0) {
            
             var selectedItem = _keyValuePairs.ElementAt(selectedIndex);
                typId = selectedItem.Key;

            }
            
        }

        
    }
}
