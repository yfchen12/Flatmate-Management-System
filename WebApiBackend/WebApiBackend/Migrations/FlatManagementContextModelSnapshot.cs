﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiBackend.Model;

namespace WebApiBackend.Migrations
{
    [DbContext(typeof(FlatManagementContext))]
    partial class FlatManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("WebApiBackend.Model.Flat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Flat");
                });

            modelBuilder.Entity("WebApiBackend.Model.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Fixed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FlatId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FlatId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("WebApiBackend.Model.Schedule", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ScheduleType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FlatId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserName", "StartDate", "EndDate", "ScheduleType");

                    b.HasIndex("FlatId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("WebApiBackend.Model.TestModelItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TestItems");
                });

            modelBuilder.Entity("WebApiBackend.Model.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankAccount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FlatId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalInformation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("UserName");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FlatId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApiBackend.Model.UserPayment", b =>
                {
                    b.Property<int>("PaymentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("PaymentId", "UserName");

                    b.HasIndex("UserName");

                    b.ToTable("UserPayments");
                });

            modelBuilder.Entity("WebApiBackend.Model.Payment", b =>
                {
                    b.HasOne("WebApiBackend.Model.Flat", null)
                        .WithMany("Payments")
                        .HasForeignKey("FlatId");
                });

            modelBuilder.Entity("WebApiBackend.Model.Schedule", b =>
                {
                    b.HasOne("WebApiBackend.Model.Flat", null)
                        .WithMany("Schedules")
                        .HasForeignKey("FlatId");
                });

            modelBuilder.Entity("WebApiBackend.Model.User", b =>
                {
                    b.HasOne("WebApiBackend.Model.Flat", null)
                        .WithMany("Users")
                        .HasForeignKey("FlatId");
                });

            modelBuilder.Entity("WebApiBackend.Model.UserPayment", b =>
                {
                    b.HasOne("WebApiBackend.Model.Payment", "Payment")
                        .WithMany("UserPayments")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiBackend.Model.User", "User")
                        .WithMany("UserPayments")
                        .HasForeignKey("UserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}