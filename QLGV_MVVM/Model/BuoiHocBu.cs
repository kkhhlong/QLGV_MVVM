//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class BuoiHocBu
    {
        public int id { get; set; }
        public Nullable<System.DateTime> ngay { get; set; }
        public string tenPhong { get; set; }
        public Nullable<int> idLopHoc { get; set; }
        public Nullable<int> tietBatDau { get; set; }
        public Nullable<int> trangThai { get; set; }
        public string ghiChu { get; set; }
    
        public virtual BuoiHoc BuoiHoc { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public virtual Phong Phong { get; set; }
    }
}
