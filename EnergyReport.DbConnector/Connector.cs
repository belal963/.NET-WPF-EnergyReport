
using LinqToDB.Data;
using LinqToDB;
using EnergyReport.DbConnector.Intf;
using EnergyReport.DbConnector.Model;
using System;
using EnergyReport.DbConnector;
using System.Xml;

namespace EnergyReport.DbConnector
{
    public class Connector : DataConnection
    {
        public ITable<IRealestate> Realestate => this.GetTable<Realestate>();
        public ITable<IContract> Contract => this.GetTable<Contract>();

        public ITable<IEnum_Type> Enum_Types => this.GetTable<Enum_Type>();

        public ITable<ITariff> Tariffs => this.GetTable<Tariff>();

        public ITable<IReading> Readings => this.GetTable<Reading>();


        public ITable<IEnum_Unit> Enum_Units => this.GetTable<Enum_Unit>();

        private static string connStr = @"Server=********;TrustServerCertificate=True;Database=********;User Id=*********;Password=*******";

        public Connector() : base(ProviderName.SqlServer, connStr) { }

        public IList<IRealestate> SelectAllRealestate()
        {
            using var db = new Connector();
            var result = from ld in db.Realestate select ld;
            var test = result.ToList();
            return test;



        }

        public IList<IContract> SelectAllContract()
        {
            using var db = new Connector();
            var result = from ld in db.Contract select ld;
            var test = result.ToList();
            return test;

        }

        public IList<IEnum_Type> SelectAllEnumType()
        {
            using var db = new Connector();
            var result = from ld in db.Enum_Types select ld;
            var test = result.ToList();
            return test;

        }

        public IList<IReading> SelectAlReding()
        {
            using var db = new Connector();
            var result = from ld in db.Readings select ld;
            var test = result.ToList();
            return test;
        }

        public IList<IContract> SelectAllContractByRealstate(IRealestate realestate)
        {
            using var db = new Connector();
            var result = from ld in db.Contract where ld.Realestate_FK == realestate.RecId select ld;
            var test = result.ToList();
            return test;

        }

        public IList<IReading> SelectAlRedingByContract(IContract contract)
        {

            using var db = new Connector();
            var result = from ld in db.Readings where ld.Contract_Fk == contract.RecId select ld;
            var test = result.ToList();
            return test;
        }
        public IList<IEnum_Type> SelectEnumTypeByRealestate(IRealestate realestate)
        {
            var listContract = SelectAllContractByRealstate(realestate);
            var enumList = new List<IEnum_Type>();
            using var db = new Connector();
            foreach (var contract in listContract)
            {
                enumList.Add((from ld in db.Enum_Types where ld.RecId == contract.Enum_Typ_FK select ld).FirstOrDefault());

            }
            
            return enumList;
        }

        public IList<IContract> SelectAllContractByDate(DateTime startdate, DateTime enddate)
        {
            using var db = new Connector();
            var result = from ld in db.Contract where ld.ValidFrom >= startdate && ld.ExpiresOn <= enddate select ld; 
            var test = result .ToList();    
            return test;
        }

        public IList<ITariff> SelectAllTriff()
        {
            using var db = new Connector();
            var result = from ld in db.Tariffs select ld;
            var test = result.ToList();
            return test;
        }

        public IList<IEnum_Type> SelectEnumType()
        {
            using var db = new Connector();
            var result = from ld in db.Enum_Types select ld;
            var test = result.ToList();
            return test;
        }

        public IList<IEnum_Unit> SelectEnum_Unit()
        {
            using var db = new Connector();
            var result = from ld in db.Enum_Units select ld;
            var test = result.ToList();
            return test;
        }

        

        public void InsertRealestate(IRealestate realestate)
        {
            var db = new Connector();
            db.Realestate
                .Value(p => p.FirstName, realestate.FirstName)
                .Value(p => p.LastName, realestate.LastName)
                .Value(p => p.Addition, realestate.Addition)
                .Value(p => p.Firm, realestate.Firm)
                .Value(p => p.Location, realestate.Location)
                .Value(p => p.Postcode, realestate.Postcode)
                .Value(p => p.Street, realestate.Street)
                .Value(p => p.HouseNumber, realestate.HouseNumber)
                .Insert();


        }

        public void InsertContract(IContract contract)
        {
            var db = new Connector();
            db.Contract
                .Value(p => p.ContractNumber, contract.ContractNumber)
                .Value(p => p.CounterNumber, contract.CounterNumber)
                .Value(p => p.ValidFrom, contract.ValidFrom)
                .Value(p => p.ExpiresOn, contract.ExpiresOn)
                .Value(p => p.Realestate_FK, contract.Realestate_FK)
                .Value(p => p.Enum_Typ_FK, contract.Enum_Typ_FK)
                .Insert();

        }

        public void InsertTariff(ITariff tariff)
        {
            var db = new Connector();
            db.Tariffs
                .Value(p => p.Price_HT, tariff.Price_HT)
                .Value(p => p.Price_NT, tariff.Price_NT)
                .Value(p => p.Contract_FK, tariff.Contract_FK)
                .Value(p => p.StratDate, tariff.StratDate)
                .Insert();



        }


        public void InsertReading(IReading reading)
        {
            var db = new Connector();
            db.Readings
                .Value(p => p.ReadingDate, reading.ReadingDate)
                .Value(p => p.Counter_HT, reading.Counter_HT)
                .Value(p => p.Counter_NT, reading.Counter_NT)
                .Value(p => p.Contract_Fk, reading.Contract_Fk)
                .Insert();


        }
    }
}