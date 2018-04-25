
using QLGV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLGV_MVVM.ViewModel
{
    public class BuoiHocViewModel:BaseViewModel
    {
        string selectedTrangThai;
        string phong;
        int tietBatDau;
        List<string> listTrangThai;
        DateTime ngayHoc;
        string ghiChu;


        TietHoc selectedItem;
        public TietHoc SelectedItem
        {
            get => selectedItem; set
            {
                selectedItem = value; OnPropertyChanged();
                if(SelectedItem != null)
                {
                    TenPhong = SelectedItem.tenPhong;
                    TietBatDau = SelectedItem.TietBatDau;
                    NgayHoc = SelectedItem.ngayHoc==null?DateTime.Now:SelectedItem.ngayHoc.Value;
                    GhiChu = SelectedItem.ghiChu;
                    if(SelectedItem is TietHocBu)
                    {
                        ListTrangThai = new List<string>(new string[] { "Đi trễ", "Bình thường" });
                        SelectedTrangThai = SelectedItem.TextTrangThai;
                        
                    }
                    else
                    {
                        ListTrangThai = new List<string>(new string[] { "Đi trễ", "Bình thường","Giảng viên nghỉ","Trường cho nghỉ" });
                        SelectedTrangThai = SelectedItem.TextTrangThai;

                    }
                }
            }
        }
        public bool Isloaded = false;
        public ICommand LoadedBuoiHocCommand { get; set; }

        public ICommand IEdit { get; set; }
        private LopHoc Lh;
        public LopHoc lh { get => Lh; set { Lh = value;OnPropertyChanged(); } }


        private ObservableCollection<TietHoc> listBuoiHoc;
        public ObservableCollection<TietHoc> ListBuoiHoc { get=>listBuoiHoc; set { listBuoiHoc = value;OnPropertyChanged(); } }

        public string TenPhong { get => phong; set { phong = value; OnPropertyChanged(); } }
        public int TietBatDau { get => tietBatDau; set {tietBatDau = value; OnPropertyChanged(); }}
        public List<string> ListTrangThai { get => listTrangThai; set { listTrangThai = value; OnPropertyChanged(); }}
        public DateTime NgayHoc { get => ngayHoc; set {ngayHoc = value; OnPropertyChanged(); }}
        public string GhiChu { get => ghiChu; set {ghiChu = value; OnPropertyChanged(); }}

        public string SelectedTrangThai { get => selectedTrangThai; set
            {
                selectedTrangThai = value;
                OnPropertyChanged();
            }
        }

        public BuoiHocViewModel()
        {
            LoadedBuoiHocCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Isloaded = true;
                lh = PassingLopHoc.lh;
                LoadList();
               
            }
             );
            IEdit = new RelayCommand<object>((p) =>
            {
            if (TietBatDau == 0 || string.IsNullOrEmpty(TenPhong) || SelectedItem == null)
                {
                    return false;
                }
                var check = DataProvider.Instance.DB.TietHocs.Where(c => c.ngayHoc == NgayHoc && c.LopHoc.tietBatDau == TietBatDau &&( c.ngayHoc != SelectedItem.ngayHoc || c.LopHoc.tietBatDau != SelectedItem.TietBatDau) && c.maLopHoc == lh.maLopHoc);
                if(check.Count()!=0  || check == null)
                {
                    
                    return false;
                }
                 check = DataProvider.Instance.DB.TietHocBus.Where(c => c.ngayHoc == NgayHoc && c.tietBatDau == TietBatDau && (c.ngayHoc != SelectedItem.ngayHoc || c.tietBatDau != SelectedItem.TietBatDau)&& c.maLopHoc == lh.maLopHoc);
                if (check.Count() != 0 || check == null)
                {
                    return false;
                }
                return true;
            }, (p) => {
              if(SelectedItem is TietHocBu)
                {
                    
                    DataProvider.Instance.DB.SuaBuoiHocBu(SelectedItem.idTietHoc, SelectedItem.maLopHoc, TietBatDau, TenPhong, NgayHoc, IntTrangThai(), GhiChu);
                    
                }
                else
                {
                    DataProvider.Instance.DB.SuaBuoiHoc(SelectedItem.idTietHoc, TenPhong, IntTrangThai(), GhiChu);
                }
                RefreshTietHoc(lh.maLopHoc);
                LoadList();

            }
            );


        }

        public void RefreshTietHoc(int maLopHoc)
        {
            foreach (var entity in DataProvider.Instance.DB.TietHocBus.Where(p => p.maLopHoc == maLopHoc).ToList())
            {
                DataProvider.Instance.DB.Entry(entity).Reload();
            }
            foreach (var entity in DataProvider.Instance.DB.TietHocs.Where(p => p.maLopHoc == maLopHoc).ToList())
            {
                DataProvider.Instance.DB.Entry(entity).Reload();
            }
        }
        void LoadList()
        {
            ListBuoiHoc = new ObservableCollection<TietHoc>(DataProvider.Instance.DB.TietHocs.Where(p=>p.maLopHoc == lh.maLopHoc));
            foreach (var item in DataProvider.Instance.DB.TietHocBus.Where(p=>p.maLopHoc == lh.maLopHoc) )
            {
                ListBuoiHoc.Add(item);
            }
            ListBuoiHoc = new ObservableCollection<TietHoc>(ListBuoiHoc.OrderBy(x => x.Tuan).ToList()) ;    
        }
        int IntTrangThai()
        {
            switch (SelectedTrangThai)
            {
                case "Bình thường":
                    return -1;
                case "Trường cho nghỉ":
                    return 0;
                case "Giảng viên nghỉ":
                    return 1;
                default:
                    return 2; 
            }
        }
    }
}
