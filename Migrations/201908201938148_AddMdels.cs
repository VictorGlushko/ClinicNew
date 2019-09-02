namespace Clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMdels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        Detail = c.String(),
                        Status = c.Boolean(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Address = c.String(),
                        SpecializationId = c.Int(nullable: false),
                        PhysicianId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PhysicianId)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId)
                .Index(t => t.PhysicianId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        Name = c.String(),
                        Sex = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        CityId = c.Byte(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Height = c.String(),
                        Weight = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicRemarks = c.String(),
                        Diagnosis = c.String(),
                        SecondDiagnosis = c.String(),
                        ThirdDiagnosis = c.String(),
                        Therapy = c.String(),
                        Date = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Attendances", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.Doctors", "PhysicianId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Attendances", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "CityId" });
            DropIndex("dbo.Doctors", new[] { "PhysicianId" });
            DropIndex("dbo.Doctors", new[] { "SpecializationId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropTable("dbo.Attendances");
            DropTable("dbo.Patients");
            DropTable("dbo.Specializations");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
