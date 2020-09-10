﻿// <auto-generated />
using AngularTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularTest.Migrations
{
    [DbContext(typeof(eShopDBContext))]
    partial class eShopDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularTest.Models.item", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("itemImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("itemPrice")
                        .HasColumnType("int");

                    b.Property<string>("itemType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("itemId");

                    b.ToTable("items");
                });
<<<<<<< HEAD

            modelBuilder.Entity("AngularTest.Models.shoppingCart", b =>
                {
                    b.Property<int>("shoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("shoppingCartId");

                    b.ToTable("shoppingCarts");
                });

            modelBuilder.Entity("AngularTest.Models.shoppingCartItem", b =>
                {
                    b.Property<int>("shoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("itemId")
                        .HasColumnType("int");

                    b.Property<int>("shoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("shoppingCartItemId");

                    b.HasIndex("itemId");

                    b.HasIndex("shoppingCartId");

                    b.ToTable("shoppingCartItems");
                });

            modelBuilder.Entity("AngularTest.Models.shoppingCartItem", b =>
                {
                    b.HasOne("AngularTest.Models.item", "item")
                        .WithMany("shoppingCartItems")
                        .HasForeignKey("itemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngularTest.Models.shoppingCart", "shoppingCart")
                        .WithMany("shoppingCartItems")
                        .HasForeignKey("shoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
=======
>>>>>>> parent of 413d449... backup before adding shopping cart
#pragma warning restore 612, 618
        }
    }
}
