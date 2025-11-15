using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applications> Applications { get; set; }

    public virtual DbSet<Gender> Gender { get; set; }

    public virtual DbSet<GenderType> GenderType { get; set; }

    public virtual DbSet<GroupUser> GroupUser { get; set; }

    public virtual DbSet<GroupUserRelationshipUser> GroupUserRelationshipUser { get; set; }

    public virtual DbSet<MenuForm> MenuForm { get; set; }

    public virtual DbSet<Party> Party { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    public virtual DbSet<TbChitietgiohang> TbChitietgiohang { get; set; }

    public virtual DbSet<TbChitiethoadon> TbChitiethoadon { get; set; }

    public virtual DbSet<TbDanhmuc> TbDanhmuc { get; set; }

    public virtual DbSet<TbGiohang> TbGiohang { get; set; }

    public virtual DbSet<TbHoadon> TbHoadon { get; set; }

    public virtual DbSet<TbKhanhhang> TbKhanhhang { get; set; }

    public virtual DbSet<TbSanpham> TbSanpham { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=dbQUANLYBANHANG; User ID=sa; Password=12345; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applications>(entity =>
        {
            entity.HasKey(e => e.IdApplication);

            entity.ToTable("APPLICATIONS");

            entity.Property(e => e.IdApplication)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ID_APPLICATION");
            entity.Property(e => e.ApplicationName)
                .HasMaxLength(100)
                .HasColumnName("APPLICATION_NAME");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => new { e.PartyId, e.GenderTypeId, e.FromDate }).HasName("PK__GENDER__3F865F66");

            entity.ToTable("GENDER");

            entity.Property(e => e.PartyId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PARTY_ID");
            entity.Property(e => e.GenderTypeId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("GENDER_TYPE_ID");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("FROM_DATE");
            entity.Property(e => e.ThruDate)
                .HasColumnType("datetime")
                .HasColumnName("THRU_DATE");

            entity.HasOne(d => d.GenderType).WithMany(p => p.Gender)
                .HasForeignKey(d => d.GenderTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName(" FK__GENDER__GENDER_T__416EA7D8");
        });

        modelBuilder.Entity<GenderType>(entity =>
        {
            entity.HasKey(e => e.GenderTypeId).HasName("PK__GENDER_TYPE__3D9E16F4");

            entity.ToTable("GENDER_TYPE");

            entity.Property(e => e.GenderTypeId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("GENDER_TYPE_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.GenderTypeName)
                .HasMaxLength(10)
                .HasColumnName("GENDER_TYPE_NAME");
        });

        modelBuilder.Entity<GroupUser>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.ToTable("GROUP_USER");

            entity.Property(e => e.IdGroup)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ID_GROUP");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.GroupName)
                .HasMaxLength(300)
                .HasColumnName("GROUP_NAME");
        });

        modelBuilder.Entity<GroupUserRelationshipUser>(entity =>
        {
            entity.HasKey(e => new { e.PartyId, e.IdGroup }).HasName("PK_GROUP_USER_RELATIONSHIP_USER_1");

            entity.ToTable("GROUP_USER_RELATIONSHIP_USER");

            entity.Property(e => e.PartyId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PARTY_ID");
            entity.Property(e => e.IdGroup)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ID_GROUP");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.GroupUserRelationshipUser)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK_GROUP_USER_RELATIONSHIP_USER_GROUP_USER");

            entity.HasOne(d => d.Party).WithMany(p => p.GroupUserRelationshipUser)
                .HasForeignKey(d => d.PartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GROUP_USER_RELATIONSHIP_USER_PARTY");

            entity.HasMany(d => d.IdMenuForm).WithMany(p => p.GroupUserRelationshipUser)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupRelationshipMenuForm",
                    r => r.HasOne<MenuForm>().WithMany()
                        .HasForeignKey("IdMenuForm")
                        .HasConstraintName("FK_GROUP_RELATIONSHIP_MENU_FORM_MENU_FORM"),
                    l => l.HasOne<GroupUserRelationshipUser>().WithMany()
                        .HasForeignKey("PartyId", "IdGroup")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GROUP_RELATIONSHIP_MENU_FORM_GROUP_USER_RELATIONSHIP_USER"),
                    j =>
                    {
                        j.HasKey("PartyId", "IdGroup", "IdMenuForm");
                        j.ToTable("GROUP_RELATIONSHIP_MENU_FORM");
                        j.IndexerProperty<decimal>("PartyId")
                            .HasColumnType("numeric(18, 0)")
                            .HasColumnName("PARTY_ID");
                        j.IndexerProperty<decimal>("IdGroup")
                            .HasColumnType("numeric(18, 0)")
                            .HasColumnName("ID_GROUP");
                        j.IndexerProperty<decimal>("IdMenuForm")
                            .HasColumnType("numeric(18, 0)")
                            .HasColumnName("ID_MENU_FORM");
                    });
        });

        modelBuilder.Entity<MenuForm>(entity =>
        {
            entity.HasKey(e => e.IdMenuForm);

            entity.ToTable("MENU_FORM");

            entity.Property(e => e.IdMenuForm)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ID_MENU_FORM");
            entity.Property(e => e.DanhMuc)
                .HasDefaultValue(false)
                .HasColumnName("DANH_MUC");
            entity.Property(e => e.IdMenuFormParent)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ID_MENU_FORM_PARENT");
            entity.Property(e => e.MenuFormName)
                .HasMaxLength(300)
                .HasColumnName("MENU_FORM_NAME");
            entity.Property(e => e.MenuFormUrl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MENU_FORM_URL");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("MOTA");
            entity.Property(e => e.Sort).HasColumnName("SORT");
            entity.Property(e => e.SortParent).HasColumnName("SORT_PARENT");
            entity.Property(e => e.Visible)
                .HasDefaultValue(true)
                .HasColumnName("VISIBLE");

            entity.HasOne(d => d.IdMenuFormParentNavigation).WithMany(p => p.InverseIdMenuFormParentNavigation)
                .HasForeignKey(d => d.IdMenuFormParent)
                .HasConstraintName("FK_MENU_FORM_MENU_FORM");

            entity.HasMany(d => d.IdApplication).WithMany(p => p.IdMenuForm)
                .UsingEntity<Dictionary<string, object>>(
                    "ApplicationsMenuFormRelations",
                    r => r.HasOne<Applications>().WithMany()
                        .HasForeignKey("IdApplication")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_APPLICATIONS_MENU_FORM_RELATIONS_APPLICATIONS"),
                    l => l.HasOne<MenuForm>().WithMany()
                        .HasForeignKey("IdMenuForm")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_APPLICATIONS_MENU_FORM_RELATIONS_MENU_FORM"),
                    j =>
                    {
                        j.HasKey("IdMenuForm", "IdApplication");
                        j.ToTable("APPLICATIONS_MENU_FORM_RELATIONS");
                        j.IndexerProperty<decimal>("IdMenuForm")
                            .HasColumnType("numeric(18, 0)")
                            .HasColumnName("ID_MENU_FORM");
                        j.IndexerProperty<decimal>("IdApplication")
                            .HasColumnType("numeric(18, 0)")
                            .HasColumnName("ID_APPLICATION");
                    });
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.PartyId).HasName("PK_PARTY_1");

            entity.ToTable("PARTY");

            entity.Property(e => e.PartyId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PARTY_ID");
            entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PasswordH)
                .HasMaxLength(300)
                .HasColumnName("PASSWORD_H");
            entity.Property(e => e.TypeOfParty)
                .HasMaxLength(50)
                .HasColumnName("TYPE_OF_PARTY");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("USERNAME");
            entity.Property(e => e.UsernameH)
                .HasMaxLength(300)
                .HasColumnName("USERNAME_H");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PartyId);

            entity.ToTable("PERSON");

            entity.Property(e => e.PartyId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PARTY_ID");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("BIRTH_DATE");
            entity.Property(e => e.CurrentEmail)
                .HasMaxLength(100)
                .HasColumnName("CURRENT_EMAIL");
            entity.Property(e => e.CurrentFirstName)
                .HasMaxLength(50)
                .HasColumnName("CURRENT_FIRST_NAME");
            entity.Property(e => e.CurrentGenderTypeId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CURRENT_GENDER_TYPE_ID");
            entity.Property(e => e.CurrentLastName)
                .HasMaxLength(50)
                .HasColumnName("CURRENT_LAST_NAME");
            entity.Property(e => e.CurrentMiddleName)
                .HasMaxLength(50)
                .HasColumnName("CURRENT_MIDDLE_NAME");
            entity.Property(e => e.CurrentNickname)
                .HasMaxLength(50)
                .HasColumnName("CURRENT_NICKNAME");
            entity.Property(e => e.CurrentPhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("CURRENT_PHONE_NUMBER");
            entity.Property(e => e.PeopleIdIssueDate)
                .HasColumnType("datetime")
                .HasColumnName("PEOPLE_ID_ISSUE_DATE");
            entity.Property(e => e.PeopleIdIssuePlace)
                .HasMaxLength(50)
                .HasColumnName("PEOPLE_ID_ISSUE_PLACE");
            entity.Property(e => e.PeopleIdNumber)
                .HasMaxLength(50)
                .HasColumnName("PEOPLE_ID_NUMBER");
            entity.Property(e => e.PersonImage)
                .HasMaxLength(50)
                .HasColumnName("PERSON_IMAGE");

            entity.HasOne(d => d.Party).WithOne(p => p.Person)
                .HasForeignKey<Person>(d => d.PartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERSON_PARTY");
        });

        modelBuilder.Entity<TbChitietgiohang>(entity =>
        {
            entity.HasKey(e => new { e.Magiohang, e.Masanpham });

            entity.ToTable("tbCHITIETGIOHANG");

            entity.Property(e => e.Magiohang).HasColumnName("MAGIOHANG");
            entity.Property(e => e.Masanpham).HasColumnName("MASANPHAM");
            entity.Property(e => e.Dongia)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien)
                .HasComputedColumnSql("([SOLUONG]*[DONGIA])", true)
                .HasColumnType("decimal(29, 2)")
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.MagiohangNavigation).WithMany(p => p.TbChitietgiohang)
                .HasForeignKey(d => d.Magiohang)
                .HasConstraintName("FK_GH_GIOHANG");

            entity.HasOne(d => d.MasanphamNavigation).WithMany(p => p.TbChitietgiohang)
                .HasForeignKey(d => d.Masanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GH_SANPHAM");
        });

        modelBuilder.Entity<TbChitiethoadon>(entity =>
        {
            entity.HasKey(e => e.Machitiet);

            entity.ToTable("tbCHITIETHOADON");

            entity.Property(e => e.Machitiet).HasColumnName("MACHITIET");
            entity.Property(e => e.Dongia)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");
            entity.Property(e => e.Masanpham).HasColumnName("MASANPHAM");
            entity.Property(e => e.Soluong)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("SOLUONG");

            entity.HasOne(d => d.MahoadonNavigation).WithMany(p => p.TbChitiethoadon)
                .HasForeignKey(d => d.Mahoadon)
                .HasConstraintName("FK_tbCHITIETHOADON_tbHOADON");

            entity.HasOne(d => d.MasanphamNavigation).WithMany(p => p.TbChitiethoadon)
                .HasForeignKey(d => d.Masanpham)
                .HasConstraintName("FK_tbCHITIETHOADON_tbSANPHAM");
        });

        modelBuilder.Entity<TbDanhmuc>(entity =>
        {
            entity.HasKey(e => e.Madanhmuc).HasName("PK__tbDANHMU__804E2884FBEE3276");

            entity.ToTable("tbDANHMUC");

            entity.Property(e => e.Madanhmuc).HasColumnName("MADANHMUC");
            entity.Property(e => e.Danhmuccha).HasColumnName("DANHMUCCHA");
            entity.Property(e => e.Mota)
                .HasMaxLength(200)
                .HasColumnName("MOTA");
            entity.Property(e => e.Tendanhmuc)
                .HasMaxLength(200)
                .HasColumnName("TENDANHMUC");
        });

        modelBuilder.Entity<TbGiohang>(entity =>
        {
            entity.HasKey(e => e.Magiohang).HasName("PK__tbGIOHAN__559F5534E34A6024");

            entity.ToTable("tbGIOHANG");

            entity.Property(e => e.Magiohang).HasColumnName("MAGIOHANG");
            entity.Property(e => e.Makhachhang).HasColumnName("MAKHACHHANG");
            entity.Property(e => e.Ngaytao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NGAYTAO");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(30)
                .HasDefaultValue("CHUA_THANH_TOAN")
                .HasColumnName("TRANGTHAI");
        });

        modelBuilder.Entity<TbHoadon>(entity =>
        {
            entity.HasKey(e => e.Mahoadon);

            entity.ToTable("tbHOADON");

            entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");
            entity.Property(e => e.Makhachhang).HasColumnName("MAKHACHHANG");
            entity.Property(e => e.Ngay)
                .HasColumnType("datetime")
                .HasColumnName("NGAY");
            entity.Property(e => e.Ngayduyet)
                .HasColumnType("datetime")
                .HasColumnName("NGAYDUYET");
            entity.Property(e => e.Nguoiduyet)
                .HasMaxLength(50)
                .HasColumnName("NGUOIDUYET");
            entity.Property(e => e.Tongtien)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(30)
                .HasDefaultValue("DA_DAT_HANG")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MakhachhangNavigation).WithMany(p => p.TbHoadon)
                .HasForeignKey(d => d.Makhachhang)
                .HasConstraintName("FK_tbHOADON_tbKHANHHANG");
        });

        modelBuilder.Entity<TbKhanhhang>(entity =>
        {
            entity.HasKey(e => e.Makhachhang);

            entity.ToTable("tbKHANHHANG");

            entity.Property(e => e.Makhachhang)
                .ValueGeneratedNever()
                .HasColumnName("MAKHACHHANG");
            entity.Property(e => e.Diachi)
                .HasMaxLength(200)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(6)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("HOTEN");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .HasColumnName("MATKHAU");
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");
            entity.Property(e => e.Taikhoan)
                .HasMaxLength(50)
                .HasColumnName("TAIKHOAN");
        });

        modelBuilder.Entity<TbSanpham>(entity =>
        {
            entity.HasKey(e => e.Masanpham).HasName("PK__tbSANPHA__9534C892800073C7");

            entity.ToTable("tbSANPHAM");

            entity.Property(e => e.Masanpham).HasColumnName("MASANPHAM");
            entity.Property(e => e.Dongia)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(50)
                .HasColumnName("HINHANH");
            entity.Property(e => e.Madanhmuc).HasColumnName("MADANHMUC");
            entity.Property(e => e.Mota).HasColumnName("MOTA");
            entity.Property(e => e.Soluong)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("SOLUONG");
            entity.Property(e => e.Tensanpham)
                .HasMaxLength(200)
                .HasColumnName("TENSANPHAM");

            entity.HasOne(d => d.MadanhmucNavigation).WithMany(p => p.TbSanpham)
                .HasForeignKey(d => d.Madanhmuc)
                .HasConstraintName("FK_tbSANPHAM_tbDANHMUC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
