﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMSWpfApplication
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HMSAppEntities : DbContext
    {
        public HMSAppEntities()
            : base("name=HMSAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admission> Admissions { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
    }
}
