﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Palprimes.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PalprimesDBEntities : DbContext
    {
        public PalprimesDBEntities()
            : base("name=PalprimesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C_Log> C_Log { get; set; }
        public virtual DbSet<BinaryNumber> BinaryNumbers { get; set; }
        public virtual DbSet<ConfigurationSetting> ConfigurationSettings { get; set; }
        public virtual DbSet<DecimalNumber> DecimalNumbers { get; set; }
    }
}
