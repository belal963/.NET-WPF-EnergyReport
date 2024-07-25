using EnergyReport.DbConnector.Intf;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyReport.DbConnector.Model
{
    [Table("Realestate")]
    public class Realestate : IRealestate
    {
        [PrimaryKey, Identity]


        public Guid RecId { get; set; }

        [LinqToDB.Mapping.Column(Name = "FirstName")]
        public string FirstName { get; set; }

        [LinqToDB.Mapping.Column("LastName")]
        public string LastName { get; set; }

        [LinqToDB.Mapping.Column("Firm")]
        public string Firm { get; set; }

        [LinqToDB.Mapping.Column("Addition")]
        public string Addition { get; set; }

        [LinqToDB.Mapping.Column("Location"), LinqToDB.Mapping.NotNull]
        public string Location { get; set; }

        [LinqToDB.Mapping.Column("Postcode"), LinqToDB.Mapping.NotNull]
        public int Postcode { get; set; }

        [LinqToDB.Mapping.Column("Street"), LinqToDB.Mapping.NotNull]
        public string Street { get; set; }

        [LinqToDB.Mapping.Column("HouseNumber"), LinqToDB.Mapping.NotNull]
        public string HouseNumber { get; set; }



        public override string ToString()

        {
            return $"{FirstName}";
        }

    }
}
