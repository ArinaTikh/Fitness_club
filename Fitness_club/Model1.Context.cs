﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fitness_club
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Fitness_clubEntities : DbContext
    {
        public Fitness_clubEntities()
            : base("name=Fitness_clubEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abonement> Abonement { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Shkaf> Shkaf { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Trener> Trener { get; set; }
        public virtual DbSet<TypeAbon> TypeAbon { get; set; }
        public virtual DbSet<Uchet> Uchet { get; set; }
        public virtual DbSet<Zal> Zal { get; set; }
        public virtual DbSet<card> card { get; set; }
    }
}
