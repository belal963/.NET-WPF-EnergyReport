using EnergyReport.DbConnector.Intf;
using EnergyReport.DbConnector.Model;
using EnergyReport.DbConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Windows.Media.Imaging;

namespace EnergyReport.ViewModel
{
    public class TariffViewModel : ViewModelBase
    {




        private Connector _connector;
        private IContract recId;


        public TariffViewModel()
        {
            _connector = new Connector();
            contracts = new(_connector.SelectAllContract());
            TariffItems = new(_connector.SelectAllTriff());
            StratDate = DateTime.Now;
        }
        private void ResetInputValues()
        {
            PriceHT = 0;
            PriceNT = 0;
            StratDate = DateTime.Now;
        }
        public ObservableCollection<ITariff> TariffItems { get; set; }

        public ObservableCollection<IContract> contracts { get;  }

        public IContract RecId
        {
            get => recId;
            set
            {
                recId = value;
                OnPrpertyChanged(nameof(RecId));

            }
        }

        private int _PriceHT;
        public int PriceHT
        {
            get
            {
                return _PriceHT;
            }
            set
            {
                _PriceHT = value;
                OnPrpertyChanged(nameof(PriceHT));
            }
        }

        private int _PriceNT;
        public int PriceNT
        {
            get
            {
                return _PriceNT;
            }
            set
            {
                _PriceNT = value;
                OnPrpertyChanged(nameof(PriceNT));
            }
        }

        private DateTime _StratDate;
        public DateTime StratDate
        {
            get
            {
                return _StratDate;

            }
            set
            {
                _StratDate = value;
                OnPrpertyChanged(nameof(StratDate));
            }
        }


        private ICommand? _submitCommand;
        public ICommand? SubmitCommand
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new RelayCommand(
                    (p) =>
                    {
                        InsertTraiff();                      
                        ResetInputValues();
                    },
                    (p) => { return true; }
                    ));
            }
        }

        private void InsertTraiff()
        {
            ITariff traiff = new Tariff();
            traiff.Price_NT = PriceNT;
            traiff.Price_HT = PriceHT;
            traiff.StratDate = StratDate;
            traiff.Contract_FK = RecId.RecId;
            _connector.InsertTariff(traiff);
        }
    }
}
