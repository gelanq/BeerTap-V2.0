using System.Collections.Generic;
using MyBeerTap.Data.Models;
 
 

namespace MyBeerTap.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyBeerTap.Data.BeerTapDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MyBeerTap.Data.BeerTapDBContext";
        }


    }
}
