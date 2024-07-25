using EnergyReport.DbConnector.Intf;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyReport.DbConnector.Model
{
    [Table("Reading")]
    public class Reading : IReading
    {
        [PrimaryKey, Identity]
        public Guid RecId { get; set; }

        [LinqToDB.Mapping.Column("Contract_Fk"), NotNull]
        public Guid Contract_Fk { get; set; }

        [LinqToDB.Mapping.Column("ReadingDate"), NotNull]
        public DateTime ReadingDate { get; set; }

        [LinqToDB.Mapping.Column("Counter_NT"), NotNull]
        public int Counter_NT { get; set; }

        [LinqToDB.Mapping.Column("Counter_HT"), NotNull]
        public int Counter_HT { get; set; }

        [Association(ThisKey = nameof(Contract_Fk), OtherKey = nameof(IContract.RecId))]
        public IContract Contract { get; set; }
    }
}
