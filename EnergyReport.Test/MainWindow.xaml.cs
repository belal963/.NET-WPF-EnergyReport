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
using EnergyReport.DbConnector;
using EnergyReport.DbConnector.Intf;
using EnergyReport.DbConnector.Model;

namespace EnergyReport.Test
{

    public partial class MainWindow : Window
    {
        private Connector _connector;

        public MainWindow()
        {
            InitializeComponent();
            _connector = new Connector();

            _connector.InsertRealestate(GetRealestate());
            var realestate = _connector.SelectAllRealestate().FirstOrDefault();

            _connector.InsertContract(GetContract(realestate));
            var my1 = _connector.SelectAllRealestate();


            _connector.InsertReading(GetReading());
            var my2 = _connector.SelectAllRealestate();


            _connector.InsertTariff(GetTariff());
            var my3 = _connector.SelectAllRealestate();

        }

        private ITariff GetTariff()
        {

            var contract = _connector.SelectAllContracts().FirstOrDefault();

            ITariff tariff = new Tariff()
            {
                Price_HT = 33,
                Price_NT = 44,
                StartDate = new DateOnly(2020, 10, 10),
                Contract = contract
            };

                return tariff;        
        }
        private IContract GetContract(IRealestate realestate)
        {


            IContract contract = new Contract()
            {
                ContractNumber = 1,
                ValidFrom = new DateOnly(2023, 12, 11),
                ExpiresOn = new DateOnly(2023, 12, 22),
                CounterNumber = 1234,
                Realestate = realestate,
                Enum_Type = _connector.SelestEnumType().FirstOrDefault()
                
            };

            return contract;

        }



        private IReading GetReading()
        {
            var contract = _connector.SelectAllContracts().FirstOrDefault();

            IReading reading = new Reading()
            {
                ReadingDate = new DateOnly(2023, 12, 11),
                Counter_HT = 10,
                Counter_NT = 11,
                Contract = contract 
            };

            return reading;

        }


        private IRealestate GetRealestate()
        {
            IRealestate realestate = new Realestate()
            {
                Firm = "Insystas",
                Location = "Stuttgart",
                Postcode = 70372,
                Street = "Kreuznacherstr.",
                HouseNumber = "47"
            };

            return realestate;
        }
    }
}
