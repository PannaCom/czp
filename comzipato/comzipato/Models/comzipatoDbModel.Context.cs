﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace comzipato.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class comzipatoEntities : DbContext
    {
        public comzipatoEntities()
            : base("name=comzipatoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<product_img> product_img { get; set; }
        public virtual DbSet<cat> cats { get; set; }
        public virtual DbSet<product_file> product_file { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<partner> partners { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
