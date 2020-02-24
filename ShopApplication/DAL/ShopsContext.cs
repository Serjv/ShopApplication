using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ShopApplication.Models;

namespace ShopApplication.DAL
{
    public class ShopsContext : DbContext
    {


        public ShopsContext()
        : base("DefaultConnection")
        {

        }


        public DbSet<Shops> Shops { get; set; }
        public DbSet<Consultants> Consultants { get; set; }
        public DbSet<Interconnections> Interconnections { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
    class MyContextInitializer : System.Data.Entity.CreateDatabaseIfNotExists<ShopsContext>
   {
         protected override void Seed(ShopsContext db)
        {



            var shops = new List<Shops>
            {
            new Shops{ShopName="Carson",Address="Ukraine"},

            };

            shops.ForEach(s => db.Shops.Add(s));
            db.SaveChanges();
            var consultants = new List<Consultants>
            {
            new Consultants{ConsultantName="Antonio",ConsultantSurname="Banderas"},

            };
            consultants.ForEach(s => db.Consultants.Add(s));
            db.SaveChanges();

            var ic = new List<Interconnections>
            {
            new Interconnections{Date = DateTime.Parse("2005-09-01"),ShopID =1,ConsultantID=1},

            };
            ic.ForEach(s => db.Interconnections.Add(s));
            db.SaveChanges();
        }
    }



}