﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Proje
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PetDeryasıEntities : DbContext
    {
        public PetDeryasıEntities()
            : base("name=PetDeryasıEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FATURA> FATURA { get; set; }
        public virtual DbSet<HamsterÜrün> HamsterÜrün { get; set; }
        public virtual DbSet<KARGO> KARGO { get; set; }
        public virtual DbSet<KediÜrün> KediÜrün { get; set; }
        public virtual DbSet<KöpekÜrün> KöpekÜrün { get; set; }
        public virtual DbSet<KuşÜrün> KuşÜrün { get; set; }
        public virtual DbSet<MÜŞTERİ> MÜŞTERİ { get; set; }
        public virtual DbSet<SİPARİŞ> SİPARİŞ { get; set; }
        public virtual DbSet<TEDARİKÇİ> TEDARİKÇİ { get; set; }
    }
}