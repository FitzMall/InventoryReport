﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication7.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChecklistsEntities : DbContext
    {
        public ChecklistsEntities()
            : base("name=ChecklistsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Checklist> Checklists { get; set; }
        public virtual DbSet<ChecklistItem> ChecklistItems { get; set; }
        public virtual DbSet<ChecklistItemRecord> ChecklistItemRecords { get; set; }
        public virtual DbSet<ChecklistRecord> ChecklistRecords { get; set; }
        public virtual DbSet<ChecklistSection> ChecklistSections { get; set; }
        public virtual DbSet<ChecklistStatu> ChecklistStatus { get; set; }
        public virtual DbSet<AccessList> AccessLists { get; set; }
        public virtual DbSet<AccessListHistory> AccessListHistories { get; set; }
        public virtual DbSet<ChecklistItemRecordHistory> ChecklistItemRecordHistories { get; set; }
        public virtual DbSet<ChecklistRecordHistory> ChecklistRecordHistories { get; set; }
        public virtual DbSet<dbtest> dbtests { get; set; }
        public virtual DbSet<Locations_lkup> Locations_lkup { get; set; }
        public virtual DbSet<UnCheckedCar> UnCheckedCars { get; set; }
    }
}
