using EnergyReport.DbConnector.Model;

namespace EnergyReport.DbConnector.Intf
{
    public interface IRel_Type_Unit
    {
        Guid Enum_Typ_FK { get; set; }
        Guid Enum_Unit_FK { get; set; }
        Guid RecID { get; set; }
        IEnum_Type Enum_Type { get; set; }
        IEnum_Unit Enum_Unit { get; set; }
    }
}