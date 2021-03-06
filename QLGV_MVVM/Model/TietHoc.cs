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
    using QLGV_MVVM.DAO;
    using System;
    using System.Collections.Generic;

    public partial class TietHoc
    {
        public Nullable<int> maLopHoc { get; set; }
        public int idTietHoc { get; set; }
        public string tenPhong { get; set; }
        public Nullable<System.DateTime> ngayHoc { get; set; }
        public Nullable<int> trangThai { get; set; }
        public string ghiChu { get; set; }

        public virtual LopHoc LopHoc { get; set; }
        public virtual TietHocBu TietHocBu { get; set; }
        public string Background { get => "Red"; }


        public int Tuan
        {
            get => this.ngayHoc == null ? 0 : TietHocDAO.TuanHoc(this.ngayHoc.Value);

        }
        public virtual string TuanHocBu { get => ""; }
        public string Thu { get => this.ngayHoc == null ? "" : getThu(); }
        public string SoTiet { get => getSoTiet(); }
        public virtual int TietBatDau { get => LopHoc.tietBatDau.Value; }
        public string TextTrangThai { get => getTrangThai(); }


        string getTrangThai()
        {
            switch (trangThai)
            {
                case -1:
                    return "Bình thường";
                case 0:
                    return "Trường cho nghỉ";
                case 1:
                    return "Giảng viên nghỉ";
                default:
                    return "Đi trễ";

            }
        }

        string getSoTiet()
        {
            string soTiet = "";
            if (TietBatDau != 0)
            {
                soTiet = TietBatDau + ", ";
                for (int i = 1; i < LopHoc.soTiet - 1; i++)
                {
                    soTiet += (TietBatDau + i) + ", ";
                }
                soTiet += ((TietBatDau + LopHoc.soTiet) - 1) + "";
            }

            return soTiet;
        }
        string getThu()
        {
            switch (ngayHoc.Value.DayOfWeek)
            {
                case DayOfWeek.Sunday:

                    return "Chủ Nhật";



                case DayOfWeek.Monday:

                    return "Thứ Hai";



                case DayOfWeek.Tuesday:
                    return "Thứ Ba";


                case DayOfWeek.Wednesday:
                    return "Thứ Tư";

                case DayOfWeek.Thursday:
                    return "Thứ Năm";


                case DayOfWeek.Friday:
                    return "Thứ Sáu";

                default:
                    return "Thứ Bảy";

            }

        }

    }
}
