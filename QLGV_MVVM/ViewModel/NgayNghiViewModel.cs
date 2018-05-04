using QLGV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLGV_MVVM.ViewModel
{
    public class NgayNghiViewModel:BaseViewModel
    {

        int tietBatDau = 1;
        int tietKetThuc = 15;
        DateTime? ngayBatDau;
        DateTime? ngayKetThuc;
        string ghiChu;
        
       
        public int TietBatDau { get => tietBatDau; set { tietBatDau = value; OnPropertyChanged(); } }
        public int TietKetThuc { get => tietKetThuc; set { tietKetThuc = value; OnPropertyChanged(); }}
        public DateTime? NgayBatDau { get => ngayBatDau; set{ ngayBatDau = value; OnPropertyChanged(); } }
        public DateTime? NgayKetThuc { get => ngayKetThuc; set { ngayKetThuc = value; OnPropertyChanged(); } }
        public string GhiChu { get => ghiChu; set { ghiChu = value; OnPropertyChanged(); } }

        public ICommand ILuu { get; set; }
        
        public ICommand IUndo { get; set; }
        public NgayNghiViewModel()
        {
            ILuu = new RelayCommand<object>((p) =>
            {
                if(NgayBatDau == null || NgayKetThuc == null )
                {
                    return false;
                }
                if (NgayBatDau.Value.CompareTo(NgayKetThuc.Value) > 0) {

                    return false;
                    } 
                return true;
            }, (p) =>
             {
                 var buoiTre = DataProvider.Instance.DB.TietHocs.Where(x => x.ngayHoc >= NgayBatDau.Value && x.ngayHoc <= NgayKetThuc.Value && x.trangThai == 2);
             if (buoiTre.Count() != 0)
                 {
                     MessageBoxResult dialogResult = MessageBox.Show(String.Format("Bạn có chắc chắn trường sẽ nghỉ từ {0:dd/MM/yyyy} đến {1:dd/MM/yyyy} vì chúng tôi thấy có vài buổi học trong những ngày đó bị đi trễ!",NgayBatDau.Value,NgayKetThuc.Value),"Cảnh báo", MessageBoxButton.YesNo);
                    if(dialogResult == MessageBoxResult.Yes)
                     {

                         themNgayNghi();
                     }
                 }
                 else
                 {
                     themNgayNghi();
                 }
             });
            IUndo = new RelayCommand<object>((p) =>
            {

                if (NgayBatDau == null || NgayKetThuc == null)
                {
                    return false;
                }
                if (NgayBatDau.Value.CompareTo(NgayKetThuc.Value) > 0)
                {

                    return false;
                }
                return true;
            }, (p) =>
            {
              
                    MessageBoxResult dialogResult = MessageBox.Show(String.Format("Bạn có chắc chắn hủy bỏ ngày nghĩ từ {0:dd/MM/yyyy} đến {1:dd/MM/yyyy}!", NgayBatDau.Value, NgayKetThuc.Value), "Cảnh báo", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {

                        themNgayHoc();
                    }
               
            });
        }
        void themNgayNghi()
        {
           
            if (NgayBatDau.Value == NgayKetThuc.Value)
            {
                DataProvider.Instance.DB.UpDateTietHocTheoTiet_NgayNghi(NgayBatDau.Value, TietBatDau, 15, GhiChu,0);
            }
            else
            {
                DateTime a = NgayBatDau.Value.AddDays(1);
                DateTime b = NgayKetThuc.Value.AddDays(-1);
                DateTime dt = a;
                DataProvider.Instance.DB.UpDateTietHocTheoTiet_NgayNghi(NgayBatDau.Value, TietBatDau, 15, GhiChu,0);
                DataProvider.Instance.DB.UpDateTietHocTheoTiet_NgayNghi(NgayKetThuc.Value, 1, TietKetThuc, GhiChu,0);
                while (dt.CompareTo(b) <= 0)
                {
                    DataProvider.Instance.DB.UpDateTietHocTheoNgayNghi(dt, GhiChu,0);
                    dt = dt.AddDays(1);

                }
            }
          
        }
        void themNgayHoc()
        {

            if (NgayBatDau.Value == NgayKetThuc.Value)
            {
                DataProvider.Instance.DB.UpDateTietHocTheoTiet_NgayNghi(NgayBatDau.Value, TietBatDau, 15, GhiChu,-1);
            }
            else
            {
                DateTime a = NgayBatDau.Value.AddDays(1);
                DateTime b = NgayKetThuc.Value.AddDays(-1);
                DateTime dt = a;
                DataProvider.Instance.DB.UpDateTietHocTheoTiet_NgayNghi(NgayBatDau.Value, TietBatDau, 15, GhiChu,-1);
                DataProvider.Instance.DB.UpDateTietHocTheoTiet_NgayNghi(NgayKetThuc.Value, 1, TietKetThuc, GhiChu,-1);
                while (dt.CompareTo(b) <= 0)
                {
                    DataProvider.Instance.DB.UpDateTietHocTheoNgayNghi(dt, GhiChu,-1);
                    dt = dt.AddDays(1);

                }
            }

        }
    }
}
