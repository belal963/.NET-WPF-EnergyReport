namespace EnergyReport.DbConnector.Intf
{
    public interface IRealestate
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Firm { get; set; }
        string Addition { get; set; }
        string Location { get; set; }
        int Postcode { get; set; }
        Guid RecId { get; set; }
        string Street { get; set; }
        string HouseNumber { get; set; }
    }
}