using Microsoft.Win32;
using QLGV_MVVM.DAO;
using QLGV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLGV_MVVM.ViewModel
{
    public class ThemDuLieuViewModel:BaseViewModel
    {
        string link;
        private string linkExcel ="";
        int soBuoiHoc;
        Nullable<System.DateTime> ngayKetThuc;
        Nullable<System.DateTime> ngayNhapHoc;



        public ICommand IOpenDialog { get; set; }
        public ICommand ILuu{ get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get => ngayKetThuc; set { ngayKetThuc = value; OnPropertyChanged(); } }
        public Nullable<System.DateTime> NgayNhapHoc { get => ngayNhapHoc; set { ngayNhapHoc = value; OnPropertyChanged(); } }
        public int SoBuoiHoc { get => soBuoiHoc; set { soBuoiHoc = value; OnPropertyChanged(); } }
        public string Link { get => link; set { link = value; OnPropertyChanged(); } }
        public ThemDuLieuViewModel()
        {
            IOpenDialog = new RelayCommand<object>(
               (p) =>
               {

                   return true;
               },
               (p) =>
               {
                   OpenFileDialog openFileDialog = new OpenFileDialog();
                   openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                   if (openFileDialog.ShowDialog() == true)
                   {
                       linkExcel = openFileDialog.FileName;
                       string[] t = openFileDialog.FileName.Split('\\');
                       Link = t[t.Length - 1];
                   }

               }
               );
            ILuu = new RelayCommand<object>(
              (p) =>
              {
                  if(NgayKetThuc == null || NgayNhapHoc == null || SoBuoiHoc ==0 || linkExcel == "")
                  {
                      return false;
                  }
                  return true;
              },
              (p) =>
              {
                  LuuDuLieu.DocExcel(linkExcel,NgayNhapHoc.Value, NgayKetThuc.Value, SoBuoiHoc);
                  

              }
              );
        }
    }
}
