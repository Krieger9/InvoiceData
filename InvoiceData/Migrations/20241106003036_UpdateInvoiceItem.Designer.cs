﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoiceData.Migrations
{
    [DbContext(typeof(InvoiceDbContext))]
    [Migration("20241106003036_UpdateInvoiceItem")]
    partial class UpdateInvoiceItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Invoice", b =>
                {
                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DateIssued")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SalesTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAmountDue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceNumber");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.OwnsMany("InvoiceItem", "Items", b1 =>
                        {
                            b1.Property<string>("InvoiceId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.Property<decimal>("UnitPrice")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("InvoiceId", "Description", "Amount");

                            b1.ToTable("InvoiceItem");

                            b1.WithOwner()
                                .HasForeignKey("InvoiceId");
                        });

                    b.OwnsOne("Customer", "BillTo", b1 =>
                        {
                            b1.Property<string>("InvoiceNumber")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BillTo_Address");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BillTo_City");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BillTo_Email");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BillTo_Name");

                            b1.Property<string>("Phone")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BillTo_Phone");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BillTo_State");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BillTo_ZipCode");

                            b1.HasKey("InvoiceNumber");

                            b1.ToTable("Invoices");

                            b1.WithOwner()
                                .HasForeignKey("InvoiceNumber");
                        });

                    b.Navigation("BillTo");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
