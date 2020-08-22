﻿// <auto-generated />
using System;
using ChatApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatApp.Models.ChatRoom", b =>
                {
                    b.Property<int>("ChatRoomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("RoomName")
                        .IsRequired();

                    b.HasKey("ChatRoomID");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("ChatApp.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatRoomID");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("MessageID");

                    b.HasIndex("ChatRoomID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatApp.Models.Message", b =>
                {
                    b.HasOne("ChatApp.Models.ChatRoom", "ChatRoom")
                        .WithMany("Messages")
                        .HasForeignKey("ChatRoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
