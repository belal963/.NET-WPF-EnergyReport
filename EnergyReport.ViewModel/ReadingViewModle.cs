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

namespace EnergyReport.ViewModel
{
    public class ReadingViewModle : ViewModelBase
    {

        private Connector _connector;
        private IContract recId;


        public ReadingViewModle()
        {
            _connector = new Connector();
            contracts = new(_connector.SelectAllContract());
            ReadingItems = new(_connector.SelectAlReding());
            ReadingDate = DateTime.Now;
        }

        private void ResetInputValues()
        {
            ReadingDate = DateTime.Now;
            CounterHT = 0;
            CounterNT = 0;
        }

        public ObservableCollection<IReading> ReadingItems {  get; set; }
        public ObservableCollection<IContract> contracts { get; }

        public IContract RecId
        {
            get => recId;
            set
            {
                recId = value;
                OnPrpertyChanged(nameof(RecId));
            }
        }


        private DateTime _ReadingDate;

        public DateTime ReadingDate
        {
            get { return _ReadingDate; }
            set
            {
                _ReadingDate = value;
                OnPrpertyChanged(nameof(ReadingDate));
            }
        }

        private int _CounterHT;
        public int CounterHT
        {
            get { return _CounterHT; }
            set
            {
                _CounterHT = value;
                OnPrpertyChanged(nameof(CounterHT));
            }
        }

        private int _CounterNT;
        public int CounterNT
        {
            get { return _CounterNT; }
            set
            {
                _CounterNT = value;
                OnPrpertyChanged(nameof(CounterNT));
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
                        InsertReading();
                        ResetInputValues();
                    },
                    (p) => { return true; }
                    ));
            }

        }

        private void InsertReading()
        {
            IReading reading = new Reading();
            reading.ReadingDate = _ReadingDate;
            reading.Counter_HT = _CounterHT;
            reading.Counter_NT = _CounterNT;
            reading.Contract_Fk = RecId.RecId;
            _connector.InsertReading(reading);

        }

    }
}
