using UniWebShop.DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniWebShop.DataAccess.Migrations
{
    [DbContext(typeof(UniWebShopDbContext))]
        [Migration("20230411183237_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
            modelBuilder.Entity("UniWebShop.DataAccess.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");
                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("ImageUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<int>("Price")
                        .HasColumnType("int");
                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.ToTable("Products");
                });
            modelBuilder.Entity("UniWebShop.DataAccess.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");
                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");
                    b.HasKey("Id");
                    b.ToTable("Users");
                });
            modelBuilder.Entity("UniWebShop.DataAccess.Models.UserQuestion", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");
                    b.Property<string>("Answer")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");
                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");
                    b.HasKey("ID");
                    b.ToTable("UserQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}