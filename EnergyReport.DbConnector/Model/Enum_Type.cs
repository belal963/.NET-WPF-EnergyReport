using EnergyReport.DbConnector.Intf;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyReport.DbConnector.Model
{

    [Table("Enum_Type")]
    public class Enum_Type : IEnum_Type
    {
        [PrimaryKey, Identity]
        public Guid RecId { get; set; }

        [LinqToDB.Mapping.Column("Name"), NotNull]
        public string Name { get; set; }

        [LinqToDB.Mapping.Column("ID"), NotNull]
        public int ID { get; set; }


        public override string ToString()
        {
            return $"{Name}";
        }


    }
}
