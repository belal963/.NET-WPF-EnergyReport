using EnergyReport.DbConnector;
using EnergyReport.DbConnector.Intf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Globalization;


namespace EnergyReport.ViewModel
{
    public class LivechartsViewModle : ViewModelBase
    {

        private Connector _connector;
        private IRealestate recId;
        private IEnum_Type tpyId;


        public ISeries[] Series { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 0, -10, -20, -30, -40 },
                    GeometrySize = 15 ,
                    Fill = new SolidColorPaint(new SKColor(10,255,25)),
                    Stroke = new SolidColorPaint(new SKColor (100,100,100)) { StrokeThickness = 10}                   
                }, 
                new ColumnSeries<Double>
                {
                    Values = new double[] { 0, 10 , 20 , 30 , 50 }
                }
            };

        public LivechartsViewModle()
        {
            _connector = new Connector();

            StratDate = DateTime.Now;
            EndDate = DateTime.Now;
            FromToContract = new(_connector.SelectAllContractByDate(StratDate, EndDate));
            RealstateItems = new(_connector.SelectAllRealestate());
            Enums = new(_connector.SelectAllEnumType());
            ReadingItems = new(_connector.SelectAlReding());
            SelectedItemIndexRE = 1;
            SelectedItemIndexEnum = 0;
        }

        public string TextboxOutput { get; set; }
        public ObservableCollection<IRealestate> RealstateItems { get; }
        public ObservableCollection<IContract> ContractItems { get; set; }
        public ObservableCollection<IReading> ReadingItems { get; set; }
        private ObservableCollection<IEnum_Type> _FilteredEnums;
        public ObservableCollection<IEnum_Type> FilteredEnums
        {
            get => _FilteredEnums;
            set
            {
                _FilteredEnums = value;
                OnPrpertyChanged(nameof(FilteredEnums));
            }
        }
        private ObservableCollection<IContract> _FromToContract;
        public ObservableCollection<IContract> FromToContract
        {
            get => _FromToContract;
            set
            {
                _FromToContract = value;
                OnPrpertyChanged(nameof(FromToContract));
            }
        }

        public ObservableCollection<IEnum_Type> Enums { get; }
        public IEnum_Type TpyId
        {
            get => tpyId;
            set
            {
                tpyId = value;
                OnPrpertyChanged(nameof(TpyId));
            }
        }
        private DateTime _EndDate;
        public DateTime EndDate
        {
            get => _EndDate;
            set
            {
                _EndDate = value;
                OnPrpertyChanged(nameof(EndDate));
            }
        }

        private DateTime _StratDate;
        public DateTime StratDate
        {
            get { return _StratDate; }
            set
            {
                _StratDate = value;
                OnPrpertyChanged(nameof(StratDate));
            }
        }
        private int selectedItemIndexRE;
        private int selectedItemIndexEnum;

        public int SelectedItemIndexRE
        {
            get => selectedItemIndexRE;
            set
            {

                if (selectedItemIndexRE != value && value >= 0 && value < RealstateItems.Count)
                {
                    
                    selectedItemIndexRE = value;
                    OnPrpertyChanged(nameof(SelectedItemIndexRE));
                   

                    var selectedRealstate = RealstateItems.ElementAt<IRealestate>(SelectedItemIndexRE);
                    var ContractItems = _connector.SelectAllContractByRealstate(selectedRealstate);
                    var selectedContract = ContractItems.First();
                    FilteredEnums = new(_connector.SelectEnumTypeByRealestate(selectedRealstate));
                    SelectedItemIndexEnum = 0;
                }
            }  
        }

        public int SelectedItemIndexEnum
        {
            get => selectedItemIndexEnum;

            set
            {
                selectedItemIndexEnum = value;
                OnPrpertyChanged(nameof(SelectedItemIndexEnum));
            }   
        }
        public IRealestate RecId
        {
            get => recId;
            set
            {
                recId = value;
                OnPrpertyChanged(nameof(RecId));
            }
        }

       

        private string _Test;
        public string Test
        {
            get { return _Test; } set
            {
                _Test = value;
                OnPrpertyChanged(nameof(Test));
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

                        var selectedRealstate = RealstateItems.ElementAt<IRealestate>(SelectedItemIndexRE);
                        var ContractItems = _connector.SelectAllContractByRealstate(selectedRealstate);

                        if (ContractItems.Count > 0)
                        {
                            var selectedContract = ContractItems.First(); 
                            var selectedReading = _connector.SelectAlRedingByContract(selectedContract);
                            _connector.SelectAllContractByDate(StratDate, EndDate);                            
                            FromToContract.Clear();
                            FromToContract = new ObservableCollection<IContract>(_connector.SelectAllContractByDate(StratDate, EndDate));
                            var verbracuh = selectedReading.First().Counter_HT * 520;
                            Test =   $"{verbracuh}";
                        }
                        else
                        {
                            MessageBox.Show("No contracts found for the selected real estate.");
                        }
                    },
                    (p) =>

                    {
                        return true;
                    }
                ));

            }

        }

    }
}
