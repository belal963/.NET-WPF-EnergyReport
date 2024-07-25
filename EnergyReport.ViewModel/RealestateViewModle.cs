using EnergyReport.DbConnector.Intf;
using EnergyReport.DbConnector.Model;
using EnergyReport.DbConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace EnergyReport.ViewModel
{
    public class RealestateViewModle : ViewModelBase
    {

        private Connector _connector;       
        public RealestateViewModle()
        {

            _connector = new Connector();
            RealstateItems = new(_connector.SelectAllRealestate());
           
        }
        private void ResetInputValues()
        {
            FirstName = "";
            LastName = "";
            FirstName = "";
            Location = "";
            Addition = "";
            Street = "";
            Postcode = 0;
            HouseNumber = "";
        }
        public ObservableCollection<IRealestate> RealstateItems { get; set;}
        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                OnPrpertyChanged(nameof(FirstName));
            }
        }
        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; OnPrpertyChanged(nameof(LastName)); }
        }
        private string _Firm;
        public string Firm
        {
            get { return _Firm; }
            set
            {
                _Firm = value;
                OnPrpertyChanged(nameof(Firm));
            }
        }

        private string _Addition;

        public string Addition
        {
            get { return _Addition; }
            set
            {
                _Addition = value;
                OnPrpertyChanged(nameof(_Addition));
            }
        }

        private string _Location;

        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                OnPrpertyChanged(nameof(_Location));
            }
        }
        private int _Postcode;

        public int Postcode
        {
            get { return _Postcode; }
            set
            {
                _Postcode = value;
                OnPrpertyChanged(nameof(_Postcode));

            }
        }
        private string _Street;

        public string Street
        {
            get
            {
                return _Street;
            }
            set
            {
                _Street = value;
                OnPrpertyChanged(nameof(_Street));
            }
        }

        private string _HouseNumber;

        public string HouseNumber
        {
            get { return _HouseNumber; }
            set
            {
                _HouseNumber = value;
                OnPrpertyChanged(nameof(_HouseNumber));
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
                        InsertRealestate();
                        ResetInputValues();
                    },
                    (p) =>
                    {
                        return true;
                    }
                    ));
            }
        }
        private void InsertRealestate()
        {
            IRealestate realestate = new Realestate();
            realestate.FirstName = _FirstName;
            realestate.LastName = _LastName;
            realestate.Firm = _Firm;
            realestate.Street = _Street;
            realestate.Addition = _Addition;
            realestate.Location = _Location;
            realestate.Postcode = _Postcode;
            realestate.HouseNumber = _HouseNumber;
            _connector.InsertRealestate(realestate);
        }
    }
}
