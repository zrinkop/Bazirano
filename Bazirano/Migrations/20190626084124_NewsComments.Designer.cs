﻿// <auto-generated />
using System;
using Bazirano.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bazirano.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190626084124_NewsComments")]
    partial class NewsComments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bazirano.Models.Board.BoardPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BoardThreadId");

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("Image");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("BoardThreadId");

                    b.ToTable("BoardPosts");
                });

            modelBuilder.Entity("Bazirano.Models.Board.BoardThread", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ImageCount");

                    b.Property<bool>("IsLocked");

                    b.Property<int>("PostCount");

                    b.HasKey("Id");

                    b.ToTable("BoardThreads");
                });

            modelBuilder.Entity("Bazirano.Models.News.NewsComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePosted");

                    b.Property<long?>("NewsPostId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("NewsPostId");

                    b.ToTable("NewsComments");
                });

            modelBuilder.Entity("Bazirano.Models.News.NewsPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("Image");

                    b.Property<string>("Keywords");

                    b.Property<string>("Summary");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<long>("ViewCount");

                    b.HasKey("Id");

                    b.ToTable("NewsPosts");
                });

            modelBuilder.Entity("Bazirano.Models.Board.BoardPost", b =>
                {
                    b.HasOne("Bazirano.Models.Board.BoardThread")
                        .WithMany("Posts")
                        .HasForeignKey("BoardThreadId");
                });

            modelBuilder.Entity("Bazirano.Models.News.NewsComment", b =>
                {
                    b.HasOne("Bazirano.Models.News.NewsPost")
                        .WithMany("Comments")
                        .HasForeignKey("NewsPostId");
                });
#pragma warning restore 612, 618
        }
    }
}
