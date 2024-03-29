﻿// <auto-generated />
using System;
using Cronofy.Infrastructure.Persistence.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cronofy.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(CronofyWriteDbContext))]
    [Migration("20230616085341_ProtectServiceAccountRefreshToken")]
    partial class ProtectServiceAccountRefreshToken
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cronofy.Domain.AuthorizedAccount", b =>
                {
                    b.Property<string>("Sub")
                        .HasColumnType("text");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("AccessTokenExpiryDateTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServiceAccountId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Sub");

                    b.HasIndex("ServiceAccountId");

                    b.ToTable("AuthorizedAccounts", (string)null);
                });

            modelBuilder.Entity("Cronofy.Domain.ServiceAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProtectedRefreshToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ServiceAccounts", (string)null);
                });

            modelBuilder.Entity("Cronofy.Domain.AuthorizedAccount", b =>
                {
                    b.HasOne("Cronofy.Domain.ServiceAccount", "ServiceAccount")
                        .WithMany()
                        .HasForeignKey("ServiceAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
