using EnergyReport.DbConnector.Model;

namespace EnergyReport.DbConnector.Intf
{
    public interface IReading
    {
        Guid RecId { get; set; }

        int Counter_HT { get; set; }
        int Counter_NT { get; set; }
        Guid Contract_Fk { get; set; }

        DateTime ReadingDate { get; set; }

        IContract Contract { get; set; }
    }
}