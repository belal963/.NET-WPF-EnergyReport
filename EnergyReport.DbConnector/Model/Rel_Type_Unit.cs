using EnergyReport.DbConnector.Intf;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EnergyReport.DbConnector.Model
{

    [Table("Rel_Type_Unit")]
    public class Rel_Type_Unit : IRel_Type_Unit
    {
        [PrimaryKey, Identity]
        public Guid RecID { get; set; }

        [Column("Enum_Typ_FK"), NotNull]
        public Guid Enum_Typ_FK { get; set; }

        [Column("Enum_Unit_FK"), NotNull]
        public Guid Enum_Unit_FK { get; set; }

        [Association(ThisKey = nameof(Enum_Typ_FK), OtherKey = nameof(IEnum_Type.RecId))]
        public IEnum_Type Enum_Type { get; set; }

        [Association(ThisKey = nameof(Enum_Unit_FK), OtherKey = nameof(IEnum_Unit.RecID))]
        public IEnum_Unit Enum_Unit { get; set; }

    }
}
