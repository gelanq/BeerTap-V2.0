using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBeerTap.Data.Models;

namespace MyBeerTap.Data
{
  public class BeerTapDBContext : DbContext
    {

        /// <summary>
        /// Override the name of the DB
        /// </summary> 
        public BeerTapDBContext()
            : base("name=BeerTapDBContext")
        {


        }

        /// <summary>
        /// Offices DBSet 
        /// </summary> 
        public DbSet<OfficeEntity> Offices { get; set; }

        /// <summary>
        /// Taps DBSet 
        /// </summary> 
        public DbSet<TapEntity> Taps { get; set; }

        /// <summary>
        /// Kegs DBSet 
        /// </summary> 
        public DbSet<KegEntity> Kegs { get; set; }

        /// <summary>
        /// Glasses DBSet 
        /// </summary> 
        public DbSet<GlassEntity> Glasses { get; set; }


        /// <summary>
        /// Fluent API 
        /// </summary> 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<KegEntity>()
                    .HasOptional(s => s.Tap)
                    .WithMany()
                    .HasForeignKey(d => d.TapId);

        }


    }


}





