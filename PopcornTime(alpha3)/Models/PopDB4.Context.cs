﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PopcornTime_alpha3_.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PopScriptEntities1 : DbContext
    {
        public PopScriptEntities1()
            : base("name=PopScriptEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MovieDetail> MovieDetails { get; set; }
        public virtual DbSet<Movy> Movies { get; set; }
        public virtual DbSet<PaymentTable> PaymentTables { get; set; }
        public virtual DbSet<SeatDetail> SeatDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Trailer> Trailers { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        public System.Data.Entity.DbSet<PopcornTime_alpha3_.Models.BookingTable> BookingTables { get; set; }

        public System.Data.Entity.DbSet<PopcornTime_alpha3_.Models.MovieSingle> MovieSingles { get; set; }
    }
}
