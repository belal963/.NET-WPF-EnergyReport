using EnergyReport.DbConnector.Intf;
using EnergyReport.DbConnector;
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
using EnergyReport.ViewModel;

namespace EnergyReport.WPF.UserControls
{
    public partial class InputTariff : UserControl
    {

        private readonly Dictionary<IContract, string> _keyV;
        static Connector conn = new Connector();
        IList<IContract> contractlist = conn.SelectAllContract();
        private IContract citemId;
        public InputTariff()
        {
            _keyV = new Dictionary<IContract, string>();

            InitializeComponent();

            string tmpStr = "";
            foreach (var contract in contractlist)
            {
                tmpStr = contract.ContractNumber + ", ";
                _keyV.Add(contract, tmpStr);
            }
        }
        private void ContractCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = ContractCombobox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var selectedItem = _keyV.ElementAt(selectedIndex);
                citemId = selectedItem.Key;
            }
        }

    }
}
