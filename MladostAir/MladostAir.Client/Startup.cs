﻿using ExternalFiles.Readers;
using MladostAir.Data;
using MladostAir.Data.Migrations;
using MladostAir.Models;
using MladostAir.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace MladostAir.Client
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MladostAirDbContext, Configuration>());

            var db = new MladostAirDbContext();


            var jsonReader = new JsonReportFileReader();
            var json = jsonReader.ReadJsonReports();
            var airline2 = JsonConvert.DeserializeObject<Airline>(json);

            var city = new City
            {
                Name = "Plovdiv",
            };

            var country = new Country
            {
                Name = "Bulgaria"
            };

            var airport = new Airport
            {
                Name = "Plovdiv",
                AirportCode = "LBPD"
            };

            var airline = new Airline
            {
                Name = "Bulg"
            };

            var customer = new Customer
            {
                FirstName = "Stoqn",
                LastName = "Stoqnov",
                CustomerNumber = 4321,
                Age = 14
            };

            var ticket = new Ticket
            {
                TicketNumber = 9876,
                TypeClass = TypeClass.Economy,
                TypeAircraft = TypeAircraft.Airbus319
            };

            db.Countries.Add(country);

            db.Cities.Add(city);
            db.Airports.Add(airport);
            db.Customers.Add(customer);
            db.Tickets.Add(ticket);
            db.Airlines.Add(airline);

            db.SaveChanges();

            //Console.WriteLine(db.Destinations.Count());
        }
    }
}