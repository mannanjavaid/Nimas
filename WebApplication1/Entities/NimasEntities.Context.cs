﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestDB1Entities2 : DbContext
    {
        public TestDB1Entities2()
            : base("name=TestDB1Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<cdrcmrfile> cdrcmrfiles { get; set; }
        public virtual DbSet<CdrData> CdrDatas { get; set; }
        public virtual DbSet<cmrdata> cmrdatas { get; set; }
        public virtual DbSet<DeviceRegistration> DeviceRegistrations { get; set; }
        public virtual DbSet<DeviceRegistrationReason> DeviceRegistrationReasons { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<LinesMonitoring> LinesMonitorings { get; set; }
        public virtual DbSet<LinesMonitoringCause> LinesMonitoringCauses { get; set; }
        public virtual DbSet<LinesMonitoringPort> LinesMonitoringPorts { get; set; }
        public virtual DbSet<LinesMonitoringVG> LinesMonitoringVGs { get; set; }
    }
}
