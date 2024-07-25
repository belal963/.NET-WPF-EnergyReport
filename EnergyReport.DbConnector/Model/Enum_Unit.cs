using EnergyReport.DbConnector.Intf;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyReport.DbConnector.Model
{
    [Table("Enum_Unit")]
    public class Enum_Unit : IEnum_Unit
    {
        [PrimaryKey, Identity]
        public Guid RecID { get; set; }

        [Column("Name"), NotNull]
        public string Name { get; set; }


        [Column("ID"), NotNull]
        public int ID { get; set; }



    }
}
