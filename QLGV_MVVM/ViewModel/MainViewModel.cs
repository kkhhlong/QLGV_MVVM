using QLGV_MVVM.DAO;
using QLGV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLGV_MVVM.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        public ICommand ILuuDuLieu { get; set; }
        string timTenGiangVien = "";
        LopHoc lopHocSelected;
        public ICommand INgayNghi { get; set; }
        public LopHoc LopHocSelected { get=>lopHocSelected; set
            {

                lopHocSelected = value;
                OnPropertyChanged("LopHocSelected");
                if(LopHocSelected != null)
                {
                    PassingLopHoc.lh = null;
                    PassingLopHoc.lh = LopHocSelected;
                    BuoiHoc buoiHoc = new BuoiHoc();
                    buoiHoc.ShowDialog();
                }
            }
        }
        public string TimTenGiangVien { get =>timTenGiangVien; set
            {
                timTenGiangVien = value;
                OnPropertyChanged();
                ListGiangVien = GiangVienDAO.getListGiangVien(DataProvider.Instance.DB.LayGiangVienTheoTen(timTenGiangVien).ToList());
            } }
        GiangVien selectedGiangVien;
        public GiangVien SelectedGiangVien { get => selectedGiangVien; set
            {
                selectedGiangVien = value;
                if(SelectedGiangVien != null)
                {
                    ListLopHoc = new ObservableCollection<LopHoc>(DataProvider.Instance.DB.LopHocs.Where(p=>p.maGiangVien == selectedGiangVien.maGiangVien));
                    
                }
            } }
        private ObservableCollection<GiangVien> listGiangVien;
        public ObservableCollection<GiangVien> ListGiangVien { get => listGiangVien; set { listGiangVien = value; OnPropertyChanged(); } }
        private ObservableCollection<LopHoc> listLopHoc;
        public ObservableCollection<LopHoc> ListLopHoc { get => listLopHoc; set { listLopHoc = value; OnPropertyChanged(); } }
        public MainViewModel()
        {
            ListGiangVien = GiangVienDAO.getListGiangVien(DataProvider.Instance.DB.LayGiangVienTheoTen(timTenGiangVien).ToList());
            ILuuDuLieu = new RelayCommand<object>((p) => { return true; }, (p) =>
             {
                 ThemDuLieu themDuLieu = new ThemDuLieu();
                 themDuLieu.ShowDialog();
                 ListGiangVien = GiangVienDAO.getListGiangVien(DataProvider.Instance.DB.LayGiangVienTheoTen(timTenGiangVien).ToList());
             });
            INgayNghi = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                NgayNghi themDuLieu = new NgayNghi();
                themDuLieu.ShowDialog();
               
            });


        }
    }
}
