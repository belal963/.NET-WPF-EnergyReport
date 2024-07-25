using EnergyReport.DbConnector;
using EnergyReport.DbConnector.Intf;
using EnergyReport.DbConnector.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Contract = EnergyReport.DbConnector.Model.Contract;

namespace EnergyReport.ViewModel
{

    public class ContractViewModle : ViewModelBase
    {

        private Connector _connector;
        private IRealestate recId;
        private IEnum_Type tpyId;

        private void ResetInputValues()
        {
            ContractNumber = 0; 
            ValidFrom = DateTime.Now; 
            ExpiresOn = DateTime.Now; 
            CounterNumber = 0;
        }

        



        public ContractViewModle()
        {
            _connector = new Connector();

            RealstateItems = new(_connector.SelectAllRealestate());
            Enums = new(_connector.SelectAllEnumType());
            ContractItems = new(_connector.SelectAllContract());
            ValidFrom = DateTime.Now;
            ExpiresOn = DateTime.Now;
        }
        public ObservableCollection<IRealestate> RealstateItems { get; }
        public ObservableCollection<IContract> ContractItems { get; set; }
        public ObservableCollection<IEnum_Type> Enums { get; }
        public IRealestate RecId
        {
            get => recId;
            set
            {
                recId = value;
                OnPrpertyChanged(nameof(RecId));
            }
        }

        public IEnum_Type TpyId
        {
            get => tpyId;
            set
            {
                tpyId = value;
                OnPrpertyChanged(nameof(TpyId));
            }
        }
        private int _ContractNumber;
        public int ContractNumber
        {
            get
            {
                return _ContractNumber;
            }

            set
            {
                _ContractNumber = value;
                OnPrpertyChanged(nameof(ContractNumber));
            }
        }

        private DateTime _ValidFrom;
        public DateTime ValidFrom
        {
            get
            {
                return _ValidFrom;
            }
            set
            {
                _ValidFrom = value;
                OnPrpertyChanged(nameof(ValidFrom));
            }
        }

        private DateTime _ExpiresOn;
        public DateTime ExpiresOn
        {
            get
            {
                return _ExpiresOn;
            }
            set
            {
                _ExpiresOn = value;
                OnPrpertyChanged(nameof(ExpiresOn));
            }
        }

        private int _CounterNumber;
        public int CounterNumber
        {
            get
            {
                return _CounterNumber;
            }
            set
            {
                _CounterNumber = value;
                OnPrpertyChanged(nameof(CounterNumber));
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
                        InsertContract();
                        ResetInputValues();
                        
                    },
                    (p) =>

                    {
                        return true;
                    }
                ));
                
            }

            
        }

        private void InsertContract()
        {
            IContract contract = new Contract();
            contract.ContractNumber = _ContractNumber;
            contract.ValidFrom = _ValidFrom;
            contract.ExpiresOn = _ExpiresOn;
            contract.CounterNumber = _CounterNumber;
            contract.Realestate_FK = RecId.RecId;
            contract.Enum_Typ_FK = TpyId.RecId;
            _connector.InsertContract(contract);

        }

    }

}