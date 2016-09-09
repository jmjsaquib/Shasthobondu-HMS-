﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMSDevelopmentApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<admission> admissions { get; set; }
        public DbSet<appoinment> appoinments { get; set; }
        public DbSet<bank> banks { get; set; }
        public DbSet<discharge> discharges { get; set; }
        public DbSet<discharge_medicine_mapping> discharge_medicine_mapping { get; set; }
        public DbSet<discharge_type> discharge_type { get; set; }
        public DbSet<district> districts { get; set; }
        public DbSet<division> divisions { get; set; }
        public DbSet<doctor> doctors { get; set; }
        public DbSet<drug_allergies> drug_allergies { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<floor> floors { get; set; }
        public DbSet<medicine> medicines { get; set; }
        public DbSet<medicine_power> medicine_power { get; set; }
        public DbSet<meta_info> meta_info { get; set; }
        public DbSet<module> modules { get; set; }
        public DbSet<nid> nids { get; set; }
        public DbSet<patient> patients { get; set; }
        public DbSet<patient_emergency_contact> patient_emergency_contact { get; set; }
        public DbSet<patient_health_condition> patient_health_condition { get; set; }
        public DbSet<patient_health_info> patient_health_info { get; set; }
        public DbSet<patient_tracking> patient_tracking { get; set; }
        public DbSet<payment_cheque_details> payment_cheque_details { get; set; }
        public DbSet<payment_method> payment_method { get; set; }
        public DbSet<payment_type> payment_type { get; set; }
        public DbSet<presscription> presscriptions { get; set; }
        public DbSet<presscription_complaints_mapping> presscription_complaints_mapping { get; set; }
        public DbSet<presscription_drug_allergies_mapping> presscription_drug_allergies_mapping { get; set; }
        public DbSet<presscription_health_condition_mapping> presscription_health_condition_mapping { get; set; }
        public DbSet<presscription_medicine_mapping> presscription_medicine_mapping { get; set; }
        public DbSet<presscription_suggestion_mapping> presscription_suggestion_mapping { get; set; }
        public DbSet<presscription_test_type_mapping> presscription_test_type_mapping { get; set; }
        public DbSet<role_permission> role_permission { get; set; }
        public DbSet<role_type> role_type { get; set; }
        public DbSet<room> rooms { get; set; }
        public DbSet<room_type> room_type { get; set; }
        public DbSet<room_ward_mapping> room_ward_mapping { get; set; }
        public DbSet<suggestion> suggestions { get; set; }
        public DbSet<test_type> test_type { get; set; }
        public DbSet<ward> wards { get; set; }
        public DbSet<blood_donation> blood_donation { get; set; }
        public DbSet<payment> payments { get; set; }
        public DbSet<doctor_roster> doctor_roster { get; set; }
        public DbSet<disease> diseases { get; set; }
        public DbSet<department> departments { get; set; }
    }
}
