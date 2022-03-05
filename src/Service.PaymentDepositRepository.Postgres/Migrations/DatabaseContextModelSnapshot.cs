﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Service.PaymentDepositRepository.Postgres;

#nullable disable

namespace Service.PaymentDepositRepository.Postgres.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("education")
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Service.PaymentDepositRepository.Postgres.Models.PaymentDepositRepositoryEntity", b =>
                {
                    b.Property<Guid?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("CardCvv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardMonth")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ExternalId")
                        .HasColumnType("text");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TransactionId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("payment_deposit", "education");
                });
#pragma warning restore 612, 618
        }
    }
}
