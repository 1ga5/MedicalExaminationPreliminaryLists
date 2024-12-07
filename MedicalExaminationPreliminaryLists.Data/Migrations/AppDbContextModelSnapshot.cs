﻿// <auto-generated />
using System;
using MedicalExaminationPreliminaryLists.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalExaminationPreliminaryLists.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.Dictionaries.DiagnosisDictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("date");

                    b.Property<int>("EditUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActual")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DiagnosisDictionaries");
                });

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.Dictionaries.MedProfileDictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("date");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("date");

                    b.Property<int>("EditUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("Id");

                    b.ToTable("MedProfileDictionaries");
                });

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.DispensaryObservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("int");

                    b.Property<string>("DiagnosisCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiagnosisDictionaryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("date");

                    b.Property<int>("EditUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LpuType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MedProfileDictionaryId")
                        .HasColumnType("int");

                    b.Property<int>("MedProfileId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("ZAPId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisDictionaryId");

                    b.HasIndex("MedProfileDictionaryId");

                    b.HasIndex("ZAPId");

                    b.ToTable("ExaminationDiagnoses");
                });

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<string>("ENP")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("date");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsBad")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("SNILS")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.UploadFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("date");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UploadFiles");
                });

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.ZAP", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UploadFileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZAPNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("UploadFileId");

                    b.ToTable("ZAPs");
                });

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.DispensaryObservation", b =>
                {
                    b.HasOne("MedicalExaminationPreliminaryLists.Data.Models.Dictionaries.DiagnosisDictionary", "DiagnosisDictionary")
                        .WithMany()
                        .HasForeignKey("DiagnosisDictionaryId");

                    b.HasOne("MedicalExaminationPreliminaryLists.Data.Models.Dictionaries.MedProfileDictionary", "MedProfileDictionary")
                        .WithMany()
                        .HasForeignKey("MedProfileDictionaryId");

                    b.HasOne("MedicalExaminationPreliminaryLists.Data.Models.ZAP", "ZAP")
                        .WithMany("Dispenses")
                        .HasForeignKey("ZAPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiagnosisDictionary");

                    b.Navigation("MedProfileDictionary");

                    b.Navigation("ZAP");
                });

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.ZAP", b =>
                {
                    b.HasOne("MedicalExaminationPreliminaryLists.Data.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalExaminationPreliminaryLists.Data.Models.UploadFile", "UploadFile")
                        .WithMany()
                        .HasForeignKey("UploadFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("UploadFile");
                });

            modelBuilder.Entity("MedicalExaminationPreliminaryLists.Data.Models.ZAP", b =>
                {
                    b.Navigation("Dispenses");
                });
#pragma warning restore 612, 618
        }
    }
}
