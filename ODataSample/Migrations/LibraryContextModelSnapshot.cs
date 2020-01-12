﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ODataSample.Data;

namespace ODataSample.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ODataSample.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ODataSample.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ODataSample.Model.CookBook", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CookBooks");
                });

            modelBuilder.Entity("ODataSample.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ODataSample.Model.RoadAtlas", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("RoadAtlases");
                });

            modelBuilder.Entity("ODataSample.Model.TextBook", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TextBooks");
                });

            modelBuilder.Entity("ODataSample.Model.Book", b =>
                {
                    b.OwnsMany("ODataSample.Model.BookAuthor", "Authors", b1 =>
                        {
                            b1.Property<int>("BookId")
                                .HasColumnType("int");

                            b1.Property<int>("AuthorId")
                                .HasColumnType("int");

                            b1.HasKey("BookId", "AuthorId");

                            b1.HasIndex("AuthorId");

                            b1.ToTable("BookAuthors");

                            b1.HasOne("ODataSample.Model.Author", "Author")
                                .WithMany()
                                .HasForeignKey("AuthorId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner("Book")
                                .HasForeignKey("BookId");
                        });

                    b.OwnsMany("ODataSample.Model.BookGenre", "Genres", b1 =>
                        {
                            b1.Property<int>("BookId")
                                .HasColumnType("int");

                            b1.Property<int>("GenreId")
                                .HasColumnType("int");

                            b1.HasKey("BookId", "GenreId");

                            b1.HasIndex("GenreId");

                            b1.ToTable("BookGenres");

                            b1.WithOwner("Book")
                                .HasForeignKey("BookId");

                            b1.HasOne("ODataSample.Model.Genre", "Genre")
                                .WithMany()
                                .HasForeignKey("GenreId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();
                        });
                });

            modelBuilder.Entity("ODataSample.Model.CookBook", b =>
                {
                    b.HasOne("ODataSample.Model.Book", null)
                        .WithOne("CookBook")
                        .HasForeignKey("ODataSample.Model.CookBook", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("ODataSample.Model.CookRecipe", "Recipes", b1 =>
                        {
                            b1.Property<int>("CookBookId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Content")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.HasKey("CookBookId", "Id");

                            b1.ToTable("CookRecipes");

                            b1.WithOwner("CookBook")
                                .HasForeignKey("CookBookId");
                        });
                });

            modelBuilder.Entity("ODataSample.Model.RoadAtlas", b =>
                {
                    b.HasOne("ODataSample.Model.Book", null)
                        .WithOne("RoadAtlas")
                        .HasForeignKey("ODataSample.Model.RoadAtlas", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ODataSample.Model.TextBook", b =>
                {
                    b.HasOne("ODataSample.Model.Book", null)
                        .WithOne("TextBook")
                        .HasForeignKey("ODataSample.Model.TextBook", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
