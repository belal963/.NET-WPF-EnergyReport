using EnergyReport.DbConnector.Intf;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyReport.DbConnector.Model
{
    [Table("Tariff")]
    public class Tariff : ITariff
    {
        [PrimaryKey, Identity]
        public Guid RecId { get; set; }

        [LinqToDB.Mapping.Column("Contract_FK"), NotNull]
        public Guid Contract_FK { get; set; }

        [LinqToDB.Mapping.Column("Price_HT"), NotNull]
        public int Price_HT { get; set; }

        [LinqToDB.Mapping.Column("Price_NT"), NotNull]
        public int Price_NT { get; set; }

        [LinqToDB.Mapping.Column("StartDate"), NotNull]
        public DateTime StratDate { get; set; }


        [Association(ThisKey = nameof(Contract_FK), OtherKey = nameof(IContract.RecId))]
        public IContract Contract { get; set; }


        public override string ToString()
        {
            return $"{Price_HT}";
        }
    }
}
