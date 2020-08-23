﻿// <auto-generated />
using System;
using Chat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chat.DATA.Migrations
{
    [DbContext(typeof(ChatContext))]
    [Migration("20200823070002_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Chat.DATA.Entities.Channel", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("topic")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Channel");
                });

            modelBuilder.Entity("Chat.DATA.Entities.Message", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("channelid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("channelid");

                    b.HasIndex("username");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Chat.DATA.Entities.User", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.HasKey("username");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Chat.DATA.Entities.UserChannel", b =>
                {
                    b.Property<long>("idChannel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("userTag")
                        .HasColumnType("TEXT");

                    b.HasKey("idChannel", "userTag");

                    b.HasIndex("userTag");

                    b.ToTable("userChannel");
                });

            modelBuilder.Entity("Chat.DATA.Entities.Message", b =>
                {
                    b.HasOne("Chat.DATA.Entities.Channel", "channel")
                        .WithMany("messages")
                        .HasForeignKey("channelid");

                    b.HasOne("Chat.DATA.Entities.User", "User")
                        .WithMany("messages")
                        .HasForeignKey("username");
                });

            modelBuilder.Entity("Chat.DATA.Entities.UserChannel", b =>
                {
                    b.HasOne("Chat.DATA.Entities.Channel", "Channel")
                        .WithMany()
                        .HasForeignKey("idChannel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chat.DATA.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userTag")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}