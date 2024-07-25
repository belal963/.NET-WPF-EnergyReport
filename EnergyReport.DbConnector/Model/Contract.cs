using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyReport.DbConnector.Intf;
using LinqToDB;
using LinqToDB.Mapping;

namespace EnergyReport.DbConnector.Model
{

    

    [LinqToDB.Mapping.Table("Contract")]
    public class Contract : IContract
    {

        [PrimaryKey, Identity]
        public Guid RecId { get; set; }

        [LinqToDB.Mapping.Column("ContractNumber"), NotNull]
        public int ContractNumber { get; set; }

        [LinqToDB.Mapping.Column("CounterNumber"), NotNull]
        public int CounterNumber { get; set; }

        [LinqToDB.Mapping.Column("ValidFrom"), NotNull]
        public DateTime ValidFrom { get; set; }
        [LinqToDB.Mapping.Column("ExpiresOn"), NotNull]
        public DateTime ExpiresOn { get; set; }

        [LinqToDB.Mapping.Column("Realestate_FK"), NotNull]
        public Guid Realestate_FK { get; set; }

        [Association(ThisKey = nameof(Realestate_FK), OtherKey = nameof(IRealestate.RecId))]
        public IRealestate Realestate { get; set; }

        [LinqToDB.Mapping.Column("Enum_Typ_FK"), NotNull]
        public Guid Enum_Typ_FK { get; set; }

        [Association(ThisKey = nameof(Enum_Typ_FK), OtherKey = nameof(IEnum_Type.RecId))]
        public IEnum_Type Enum_Type { get; set; }



        public override string ToString()
        {
            return $"{ContractNumber}";
        }

    }
}
