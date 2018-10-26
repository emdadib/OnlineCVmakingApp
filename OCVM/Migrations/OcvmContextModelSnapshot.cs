﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OCVM.Data;

namespace OCVM.Migrations
{
    [DbContext(typeof(OcvmContext))]
    partial class OcvmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OCVM.Models.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentLocation");

                    b.Property<string>("Email");

                    b.Property<int>("ExpectedSalary");

                    b.Property<string>("LinkdInUrl");

                    b.Property<string>("Objective");

                    b.Property<string>("PermanentAddress");

                    b.Property<int>("PersonalID");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("presentAddress");

                    b.HasKey("ContactID");

                    b.HasIndex("PersonalID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("OCVM.Models.Education", b =>
                {
                    b.Property<int>("EduID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achievement");

                    b.Property<decimal?>("CGPA");

                    b.Property<int?>("Duration");

                    b.Property<string>("Exam_Degree_Title");

                    b.Property<string>("Group_Major_Subject");

                    b.Property<string>("Institute_University");

                    b.Property<int>("PersonalID");

                    b.Property<string>("Result");

                    b.Property<decimal?>("Scale");

                    b.Property<int?>("TrainingDetailsTrainingID");

                    b.Property<int>("TraningID");

                    b.Property<int?>("Year_Of_Passing");

                    b.HasKey("EduID");

                    b.HasIndex("PersonalID");

                    b.HasIndex("TrainingDetailsTrainingID");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("OCVM.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company_Business");

                    b.Property<string>("Company_Name");

                    b.Property<string>("Department");

                    b.Property<string>("Designation");

                    b.Property<DateTime?>("End_Date");

                    b.Property<int>("PersonalID");

                    b.Property<string>("Skill");

                    b.Property<DateTime?>("start_Date");

                    b.HasKey("ExperienceID");

                    b.HasIndex("PersonalID");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("OCVM.Models.PersonalDetail", b =>
                {
                    b.Property<int>("PersonalID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FathersName");

                    b.Property<string>("FullName");

                    b.Property<string>("Gender");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("MothersName");

                    b.Property<string>("Nationality");

                    b.Property<string>("Religion");

                    b.Property<string>("UserPicture");

                    b.HasKey("PersonalID");

                    b.ToTable("PersonalDetail");
                });

            modelBuilder.Entity("OCVM.Models.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("Duration");

                    b.Property<string>("Institute");

                    b.Property<string>("Location");

                    b.Property<int>("PersonalID");

                    b.Property<string>("Topics_Covered");

                    b.Property<string>("Training_Title");

                    b.Property<int?>("Training_Year");

                    b.HasKey("TrainingID");

                    b.HasIndex("PersonalID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("OCVM.Models.Contact", b =>
                {
                    b.HasOne("OCVM.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("Contacts")
                        .HasForeignKey("PersonalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OCVM.Models.Education", b =>
                {
                    b.HasOne("OCVM.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("Educations")
                        .HasForeignKey("PersonalID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OCVM.Models.Training", "TrainingDetails")
                        .WithMany()
                        .HasForeignKey("TrainingDetailsTrainingID");
                });

            modelBuilder.Entity("OCVM.Models.Experience", b =>
                {
                    b.HasOne("OCVM.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("Experiences")
                        .HasForeignKey("PersonalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OCVM.Models.Training", b =>
                {
                    b.HasOne("OCVM.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("Trainings")
                        .HasForeignKey("PersonalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}