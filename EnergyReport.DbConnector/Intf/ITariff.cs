using EnergyReport.DbConnector.Model;

namespace EnergyReport.DbConnector.Intf
{
    public interface ITariff
    {
        Guid RecId { get; set; }

        int Price_HT { get; set; }
        int Price_NT { get; set; }
        Guid Contract_FK { get; set; }
        DateTime StratDate { get; set; }

        IContract Contract { get; set; }

    }
}