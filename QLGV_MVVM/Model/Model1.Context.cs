﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLGV_MVVM.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLGVEntities : DbContext
    {
        public QLGVEntities()
            : base("name=QLGVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BuoiHoc> BuoiHocs { get; set; }
        public virtual DbSet<BuoiHocBu> BuoiHocBus { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThongTinHoc> ThongTinHocs { get; set; }
    
        public virtual ObjectResult<LayGiangVienTheoTen_Result> LayGiangVienTheoTen(string ten)
        {
            var tenParameter = ten != null ?
                new ObjectParameter("ten", ten) :
                new ObjectParameter("ten", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayGiangVienTheoTen_Result>("LayGiangVienTheoTen", tenParameter);
        }
    
        public virtual ObjectResult<LayMonHocTheoTen_Result> LayMonHocTheoTen(string ten)
        {
            var tenParameter = ten != null ?
                new ObjectParameter("ten", ten) :
                new ObjectParameter("ten", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayMonHocTheoTen_Result>("LayMonHocTheoTen", tenParameter);
        }
    
        public virtual int luuThongTinHoc(Nullable<System.DateTime> ngayBatDau, Nullable<System.DateTime> ngayKetThuc, Nullable<int> soTiet)
        {
            var ngayBatDauParameter = ngayBatDau.HasValue ?
                new ObjectParameter("ngayBatDau", ngayBatDau) :
                new ObjectParameter("ngayBatDau", typeof(System.DateTime));
    
            var ngayKetThucParameter = ngayKetThuc.HasValue ?
                new ObjectParameter("ngayKetThuc", ngayKetThuc) :
                new ObjectParameter("ngayKetThuc", typeof(System.DateTime));
    
            var soTietParameter = soTiet.HasValue ?
                new ObjectParameter("soTiet", soTiet) :
                new ObjectParameter("soTiet", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("luuThongTinHoc", ngayBatDauParameter, ngayKetThucParameter, soTietParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int SuaBuoiHoc(Nullable<int> id, string tenPhong, Nullable<int> trangThai, string ghiChu)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var tenPhongParameter = tenPhong != null ?
                new ObjectParameter("tenPhong", tenPhong) :
                new ObjectParameter("tenPhong", typeof(string));
    
            var trangThaiParameter = trangThai.HasValue ?
                new ObjectParameter("trangThai", trangThai) :
                new ObjectParameter("trangThai", typeof(int));
    
            var ghiChuParameter = ghiChu != null ?
                new ObjectParameter("ghiChu", ghiChu) :
                new ObjectParameter("ghiChu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SuaBuoiHoc", idParameter, tenPhongParameter, trangThaiParameter, ghiChuParameter);
        }
    
        public virtual int SuaBuoiHocBu(Nullable<int> idTietHoc, Nullable<int> maLopHoc, Nullable<int> tietBatDau, string tenPhong, Nullable<System.DateTime> ngayHoc, Nullable<int> trangThai, string ghiChu)
        {
            var idTietHocParameter = idTietHoc.HasValue ?
                new ObjectParameter("idTietHoc", idTietHoc) :
                new ObjectParameter("idTietHoc", typeof(int));
    
            var maLopHocParameter = maLopHoc.HasValue ?
                new ObjectParameter("maLopHoc", maLopHoc) :
                new ObjectParameter("maLopHoc", typeof(int));
    
            var tietBatDauParameter = tietBatDau.HasValue ?
                new ObjectParameter("tietBatDau", tietBatDau) :
                new ObjectParameter("tietBatDau", typeof(int));
    
            var tenPhongParameter = tenPhong != null ?
                new ObjectParameter("tenPhong", tenPhong) :
                new ObjectParameter("tenPhong", typeof(string));
    
            var ngayHocParameter = ngayHoc.HasValue ?
                new ObjectParameter("ngayHoc", ngayHoc) :
                new ObjectParameter("ngayHoc", typeof(System.DateTime));
    
            var trangThaiParameter = trangThai.HasValue ?
                new ObjectParameter("trangThai", trangThai) :
                new ObjectParameter("trangThai", typeof(int));
    
            var ghiChuParameter = ghiChu != null ?
                new ObjectParameter("ghiChu", ghiChu) :
                new ObjectParameter("ghiChu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SuaBuoiHocBu", idTietHocParameter, maLopHocParameter, tietBatDauParameter, tenPhongParameter, ngayHocParameter, trangThaiParameter, ghiChuParameter);
        }
    
        public virtual int themBuoiHoc(Nullable<int> maLopHoc, string tenPhong, Nullable<System.DateTime> ngayHoc, Nullable<int> trangThai, string ghiChu)
        {
            var maLopHocParameter = maLopHoc.HasValue ?
                new ObjectParameter("maLopHoc", maLopHoc) :
                new ObjectParameter("maLopHoc", typeof(int));
    
            var tenPhongParameter = tenPhong != null ?
                new ObjectParameter("tenPhong", tenPhong) :
                new ObjectParameter("tenPhong", typeof(string));
    
            var ngayHocParameter = ngayHoc.HasValue ?
                new ObjectParameter("ngayHoc", ngayHoc) :
                new ObjectParameter("ngayHoc", typeof(System.DateTime));
    
            var trangThaiParameter = trangThai.HasValue ?
                new ObjectParameter("trangThai", trangThai) :
                new ObjectParameter("trangThai", typeof(int));
    
            var ghiChuParameter = ghiChu != null ?
                new ObjectParameter("ghiChu", ghiChu) :
                new ObjectParameter("ghiChu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themBuoiHoc", maLopHocParameter, tenPhongParameter, ngayHocParameter, trangThaiParameter, ghiChuParameter);
        }
    
        public virtual int themBuoiHocBu(Nullable<int> maLopHoc, Nullable<int> idTietHoc, string tenPhong, Nullable<System.DateTime> ngayHoc, Nullable<int> tietBatDau, Nullable<int> trangThai, string ghiChu)
        {
            var maLopHocParameter = maLopHoc.HasValue ?
                new ObjectParameter("maLopHoc", maLopHoc) :
                new ObjectParameter("maLopHoc", typeof(int));
    
            var idTietHocParameter = idTietHoc.HasValue ?
                new ObjectParameter("idTietHoc", idTietHoc) :
                new ObjectParameter("idTietHoc", typeof(int));
    
            var tenPhongParameter = tenPhong != null ?
                new ObjectParameter("tenPhong", tenPhong) :
                new ObjectParameter("tenPhong", typeof(string));
    
            var ngayHocParameter = ngayHoc.HasValue ?
                new ObjectParameter("ngayHoc", ngayHoc) :
                new ObjectParameter("ngayHoc", typeof(System.DateTime));
    
            var tietBatDauParameter = tietBatDau.HasValue ?
                new ObjectParameter("tietBatDau", tietBatDau) :
                new ObjectParameter("tietBatDau", typeof(int));
    
            var trangThaiParameter = trangThai.HasValue ?
                new ObjectParameter("trangThai", trangThai) :
                new ObjectParameter("trangThai", typeof(int));
    
            var ghiChuParameter = ghiChu != null ?
                new ObjectParameter("ghiChu", ghiChu) :
                new ObjectParameter("ghiChu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themBuoiHocBu", maLopHocParameter, idTietHocParameter, tenPhongParameter, ngayHocParameter, tietBatDauParameter, trangThaiParameter, ghiChuParameter);
        }
    
        public virtual int themGiangVien(string maGiangVien, string hoLotGiangVien, string tenGiangVien)
        {
            var maGiangVienParameter = maGiangVien != null ?
                new ObjectParameter("maGiangVien", maGiangVien) :
                new ObjectParameter("maGiangVien", typeof(string));
    
            var hoLotGiangVienParameter = hoLotGiangVien != null ?
                new ObjectParameter("hoLotGiangVien", hoLotGiangVien) :
                new ObjectParameter("hoLotGiangVien", typeof(string));
    
            var tenGiangVienParameter = tenGiangVien != null ?
                new ObjectParameter("tenGiangVien", tenGiangVien) :
                new ObjectParameter("tenGiangVien", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themGiangVien", maGiangVienParameter, hoLotGiangVienParameter, tenGiangVienParameter);
        }
    
        public virtual int themLopHoc(Nullable<int> maLopHoc, Nullable<int> thu, Nullable<int> tietBatDau, Nullable<int> soTiet, string phong, string maLop, Nullable<int> maGiangVien, Nullable<int> maMonHoc, Nullable<int> nhom, Nullable<double> soTc)
        {
            var maLopHocParameter = maLopHoc.HasValue ?
                new ObjectParameter("maLopHoc", maLopHoc) :
                new ObjectParameter("maLopHoc", typeof(int));
    
            var thuParameter = thu.HasValue ?
                new ObjectParameter("thu", thu) :
                new ObjectParameter("thu", typeof(int));
    
            var tietBatDauParameter = tietBatDau.HasValue ?
                new ObjectParameter("tietBatDau", tietBatDau) :
                new ObjectParameter("tietBatDau", typeof(int));
    
            var soTietParameter = soTiet.HasValue ?
                new ObjectParameter("soTiet", soTiet) :
                new ObjectParameter("soTiet", typeof(int));
    
            var phongParameter = phong != null ?
                new ObjectParameter("phong", phong) :
                new ObjectParameter("phong", typeof(string));
    
            var maLopParameter = maLop != null ?
                new ObjectParameter("maLop", maLop) :
                new ObjectParameter("maLop", typeof(string));
    
            var maGiangVienParameter = maGiangVien.HasValue ?
                new ObjectParameter("maGiangVien", maGiangVien) :
                new ObjectParameter("maGiangVien", typeof(int));
    
            var maMonHocParameter = maMonHoc.HasValue ?
                new ObjectParameter("maMonHoc", maMonHoc) :
                new ObjectParameter("maMonHoc", typeof(int));
    
            var nhomParameter = nhom.HasValue ?
                new ObjectParameter("nhom", nhom) :
                new ObjectParameter("nhom", typeof(int));
    
            var soTcParameter = soTc.HasValue ?
                new ObjectParameter("soTc", soTc) :
                new ObjectParameter("soTc", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themLopHoc", maLopHocParameter, thuParameter, tietBatDauParameter, soTietParameter, phongParameter, maLopParameter, maGiangVienParameter, maMonHocParameter, nhomParameter, soTcParameter);
        }
    
        public virtual int themMonHoc(string tenMonHoc, string maMonHoc)
        {
            var tenMonHocParameter = tenMonHoc != null ?
                new ObjectParameter("tenMonHoc", tenMonHoc) :
                new ObjectParameter("tenMonHoc", typeof(string));
    
            var maMonHocParameter = maMonHoc != null ?
                new ObjectParameter("maMonHoc", maMonHoc) :
                new ObjectParameter("maMonHoc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themMonHoc", tenMonHocParameter, maMonHocParameter);
        }
    
        public virtual int themPhongHoc(string tenPhong)
        {
            var tenPhongParameter = tenPhong != null ?
                new ObjectParameter("tenPhong", tenPhong) :
                new ObjectParameter("tenPhong", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themPhongHoc", tenPhongParameter);
        }
    
        public virtual int UpDateTietHocTheoNgayNghi(Nullable<System.DateTime> ngayNghi, string ghiChu, Nullable<int> trangThai)
        {
            var ngayNghiParameter = ngayNghi.HasValue ?
                new ObjectParameter("ngayNghi", ngayNghi) :
                new ObjectParameter("ngayNghi", typeof(System.DateTime));
    
            var ghiChuParameter = ghiChu != null ?
                new ObjectParameter("ghiChu", ghiChu) :
                new ObjectParameter("ghiChu", typeof(string));
    
            var trangThaiParameter = trangThai.HasValue ?
                new ObjectParameter("trangThai", trangThai) :
                new ObjectParameter("trangThai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpDateTietHocTheoNgayNghi", ngayNghiParameter, ghiChuParameter, trangThaiParameter);
        }
    
        public virtual int UpDateTietHocTheoTiet_NgayNghi(Nullable<System.DateTime> ngayNghi, Nullable<int> tietBatDau, Nullable<int> tietKetThuc, string ghiChu, Nullable<int> trangThai)
        {
            var ngayNghiParameter = ngayNghi.HasValue ?
                new ObjectParameter("ngayNghi", ngayNghi) :
                new ObjectParameter("ngayNghi", typeof(System.DateTime));
    
            var tietBatDauParameter = tietBatDau.HasValue ?
                new ObjectParameter("tietBatDau", tietBatDau) :
                new ObjectParameter("tietBatDau", typeof(int));
    
            var tietKetThucParameter = tietKetThuc.HasValue ?
                new ObjectParameter("tietKetThuc", tietKetThuc) :
                new ObjectParameter("tietKetThuc", typeof(int));
    
            var ghiChuParameter = ghiChu != null ?
                new ObjectParameter("ghiChu", ghiChu) :
                new ObjectParameter("ghiChu", typeof(string));
    
            var trangThaiParameter = trangThai.HasValue ?
                new ObjectParameter("trangThai", trangThai) :
                new ObjectParameter("trangThai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpDateTietHocTheoTiet_NgayNghi", ngayNghiParameter, tietBatDauParameter, tietKetThucParameter, ghiChuParameter, trangThaiParameter);
        }
    
        public virtual int xoaDuLieu()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("xoaDuLieu");
        }
    }
}
