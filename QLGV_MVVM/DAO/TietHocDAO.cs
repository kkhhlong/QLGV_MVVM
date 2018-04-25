using QLGV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_MVVM.DAO
{
    static class  TietHocDAO
    {
        public static int TuanHoc(DateTime ngayHoc)
        {


            DateTime ngayNhapHoc = DataProvider.Instance.DB.ThongTinHocs.Where(p=>true).SingleOrDefault().ngayNhapHoc;
            int thu = LayThuNgayNhapHoc(ngayNhapHoc);
            //trở về thứ 2
            ngayNhapHoc = ngayNhapHoc.AddDays(thu - 2);
            int k = ngayHoc.DayOfYear - ngayNhapHoc.DayOfYear;


            return k / 7 + 1;
        }
        static int LayThuNgayNhapHoc(DateTime ngayNhapHoc)
        {
            switch (ngayNhapHoc.DayOfWeek)
            {
                case DayOfWeek.Monday: return 2;
                case DayOfWeek.Tuesday: return 3;
                case DayOfWeek.Wednesday: return 4;
                case DayOfWeek.Thursday: return 5;
                case DayOfWeek.Friday: return 6;
                case DayOfWeek.Saturday: return 7;
                case DayOfWeek.Sunday: return 8;
                default: return 0;


            }
        }
    }
}
