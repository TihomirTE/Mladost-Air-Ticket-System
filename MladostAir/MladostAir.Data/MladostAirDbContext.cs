﻿using MladostAir.Data.Migrations;
using MladostAir.Models;
using System.Data.Entity;

namespace MladostAir.Data
{
    public class MladostAirDbContext : DbContext
    {
        public MladostAirDbContext()
            :base("name=MladostAirDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MladostAirDbContext, Configuration>());
        }

        public virtual IDbSet<Airline> Airlines { get; set; }

        public virtual IDbSet<Airport> Airports { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Ticket> Tickets { get; set; }
    }
}
