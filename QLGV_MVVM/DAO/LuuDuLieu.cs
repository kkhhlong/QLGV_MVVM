using QLGV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;

namespace QLGV_MVVM.DAO
{
    abstract class LuuDuLieu
    {
        /// <summary>
        /// đọc file excel trả về 1 mảng object 2 chiều
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        static object[,] LayDuLieu(string path)
        {
            var xlApp = new Excel.Application();
            xlApp.Visible = false;
            var xlWorkBook = xlApp.Workbooks.Open(path);
            var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets.get_Item(1);
            Excel.Range xlRange = xlWorkSheet.UsedRange;
            object[,] dt = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
            xlApp.Quit();
            return dt;
        }
        //Lưu  dữ liệu từ excel vào QLYGIANGVIEN.db
        static void LuuCSDL(object[,] dt, DateTime ngayNhapHoc, DateTime ngayKetThuc, int soBuoiHoc)
        {
            ThongTinHoc thongTinHoc = new ThongTinHoc() { ngayNhapHoc = ngayNhapHoc, ngayKetThuc = ngayKetThuc, soTietHoc = soBuoiHoc };
            DataProvider.Instance.DB.ThongTinHocs.Add(thongTinHoc);
            DataProvider.Instance.DB.SaveChanges();

            for (int i = 2; i < dt.GetLength(0); i++)
            {
                //các thự tự column trong excel
                /*column:
                1 : thứ
                2 : tiết bắt đầu
                3 : số tiết
                4 : phòng
                5 : mã môn học
                6 : mã nhân viên
                7 : tên môn học
                8 : họ lót nhân viên
                9 : tên nhân viên
                10: mã lớp(của sinh viên)
                13: mã lớp học
                */
                int thu = int.Parse(dt[i, 1].ToString());
                int tietBatDau = int.Parse(dt[i, 2].ToString());
                int soTiet = int.Parse(dt[i, 3].ToString());
                string phong = dt[i, 4].ToString();
                string maMonHoc = dt[i, 5].ToString();
                string maGv = dt[i, 6].ToString();
                string tenMh = dt[i, 7].ToString();
                string hoLotGv;
                string tenGv;
                string maLop = dt[i, 10].ToString();
                int maLopHoc = int.Parse(dt[i, 13].ToString());
                //new GiangVien(họ lót, tên , mã)
                GiangVien gv = null;
                if (maGv != "")
                {
                    hoLotGv = dt[i, 8].ToString();
                    tenGv = dt[i, 9].ToString();

                    try { 
                    DataProvider.Instance.DB.themGiangVien(maGv,hoLotGv,tenGv);
                }
                catch
                {

                }
            }
                // new MonHoc(Mã môn học, tên môn học)
                try
                {
                    DataProvider.Instance.DB.themMonHoc(tenMh, maMonHoc);
                }
                catch 
                {

                }

                //public LopHoc (int maLopHoc, int thu, int tietBd, int soTiet, string lop, GiangVien gv, MonHoc mh)

                DataProvider.Instance.DB.themLopHoc(maLopHoc, thu, tietBatDau, soTiet, phong, maLop,maGv==""?null:maGv, maMonHoc);


               
                TaoTietHoc(ngayNhapHoc, thu, soBuoiHoc, maLopHoc,phong);

            }


        }
        static void TaoTietHoc(DateTime ngayNhapHoc, int thu,int soBuoiHoc, int maLh,string phong)
        {

            int thuNgayNhapHoc = LayThuNgayNhapHoc(ngayNhapHoc);


            if (thu < thuNgayNhapHoc)
            {
                ngayNhapHoc = ngayNhapHoc.AddDays(7 - thu);
            }
            else ngayNhapHoc = ngayNhapHoc.AddDays(thu - thuNgayNhapHoc);

            for (int i = 0; i < soBuoiHoc; i++)
            {

                DataProvider.Instance.DB.themTietHoc(maLh, phong, ngayNhapHoc, -1, "");
                ngayNhapHoc = ngayNhapHoc.AddDays(7);
            }
        }
       static  int LayThuNgayNhapHoc(DateTime ngayNhapHoc)
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
        static public string DocExcel(string path, DateTime ngayNhapHoc, DateTime ngayKetThuc, int soTiet)
        {
            DataProvider.Instance.DB.xoaDuLieu();
            object[,] dt = LayDuLieu(path);
            LuuCSDL(dt, ngayNhapHoc, ngayKetThuc, soTiet);
            return "";
        }

    }
}
