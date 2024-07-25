using EnergyReport.DbConnector.Model;

namespace EnergyReport.DbConnector.Intf
{
    public interface IContract
    {

        int ContractNumber { get; set; }
        int CounterNumber { get; set; }
        Guid RecId { get; set; }
        Guid Realestate_FK { get; set; }
        Guid Enum_Typ_FK { get; set; }
        DateTime ValidFrom { get; set; }
        DateTime ExpiresOn { get; set; }

        IEnum_Type Enum_Type { get; set; }

        IRealestate Realestate { get; set; }


    }
}