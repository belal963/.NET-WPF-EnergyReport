namespace EnergyReport.DbConnector.Intf
{
    public interface IEnum_Unit
    {
        string Name { get; set; }
        Guid RecID { get; set; }

        int ID { get; set; }
    }
}