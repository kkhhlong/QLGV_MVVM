
using QLGV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Excel = Microsoft.Office.Interop.Excel;

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
        public ICommand IExcel { get; set; }
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
            IExcel = new RelayCommand<object>((p) => { return true; }
            , (p) => { ExportDataGridViewTo_Excel(); });


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
        private void ExportDataGridViewTo_Excel()
        {
            try
            {

                Excel.Application oExcel = null; //Excel_12 Application 

                Excel.Workbook oBook = null; // Excel_12 Workbook 

                Excel.Sheets oSheetsColl = null; // Excel_12 Worksheets collection 

                Excel.Worksheet oSheet = null; // Excel_12 Worksheet 

                Excel.Range oRange = null; // Cell or Range in worksheet 

                Object oMissing = System.Reflection.Missing.Value;


                // Create an instance of Excel_12. 

                oExcel = new Excel.Application();


                // Make Excel_12 visible to the user. 

                oExcel.Visible = true;


                // Set the UserControl property so Excel_12 won't shut down. 

                oExcel.UserControl = true;

                // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US"); 

                //object file = File_Name;

                //object missing = System.Reflection.Missing.Value;



                // Add a workbook. 

                oBook = oExcel.Workbooks.Add(oMissing);

                // Get worksheets collection 

                oSheetsColl = oExcel.Worksheets;

                // Get Worksheet "Sheet1" 

                oSheet = (Excel.Worksheet)oSheetsColl.get_Item("Sheet1");
                oSheet.Name = "BuoiHoc";



                oSheet.Range[oSheet.Cells[1, 1], oSheet.Cells[1, 8]].Merge();
                oRange = (Excel.Range)oSheet.Cells[1, 1];
                oRange.Value2 = lh.GiangVien.TenGiangVien;

                oRange.EntireRow.Font.Bold = true;
                oRange.EntireRow.Font.Size = 16;

                oSheet.Range[oSheet.Cells[2, 1], oSheet.Cells[2, 8]].Merge();
                oRange = (Excel.Range)oSheet.Cells[2, 1];
                oRange.Value2 = lh.NoiDung;

                oRange.EntireRow.Font.Size = 12;


                oSheet.Range[oSheet.Cells[3, 1], oSheet.Cells[3, 8]].Merge();
                oRange = (Excel.Range)oSheet.Cells[3, 1];
                oRange.Value2 = lh.NoiDungLop;

                oRange.EntireRow.Font.Size = 12;



                // Export titles 

                string[] title = {"Ngày","Tuần","TuầnHB","Thứ","Phòng","Số tiết","Trạng thái","Ghi chú" };
                for (int j = 0; j < title.Length; j++)
                {

                    oRange = (Excel.Range)oSheet.Cells[5, j + 1];


                    oRange.Value2 = title[j];
                    oRange.Interior.ColorIndex = 5;
                    oRange.EntireRow.Font.Bold = true;
                    oRange.EntireRow.Font.Size = 14;
                    oRange.EntireRow.Font.ColorIndex = 2;
                    oRange.Columns.ColumnWidth = 20;
                    oRange.Columns.Borders.ColorIndex = 2;
                    oRange.Columns.Borders.Weight = 2;
                    oRange.Columns.VerticalAlignment = AlignmentY.Center;

                }

                // Export data 

                for (int i = 0; i < ListBuoiHoc.Count; i++)
                {
                    TietHoc th = ((TietHoc)ListBuoiHoc[i]);

                    oRange = (Excel.Range)oSheet.Cells[i + 6, 1];

                    oRange.Value2 = th.ngayHoc.Value.ToShortDateString() + "";

                    oRange = (Excel.Range)oSheet.Cells[i + 6, 2];

                    oRange.Value2 = th.Tuan + "";
                    oRange = (Excel.Range)oSheet.Cells[i + 6, 3];

                    oRange.Value2 = th.TuanHocBu + "";
                    oRange = (Excel.Range)oSheet.Cells[i + 6, 4];

                    oRange.Value2 = th.Thu + "";
                    oRange = (Excel.Range)oSheet.Cells[i + 6, 5];

                    oRange.Value2 = th.tenPhong + "";

                    oRange = (Excel.Range)oSheet.Cells[i + 6, 6];

                    oRange.Value2 = th.SoTiet + "";

                    oRange = (Excel.Range)oSheet.Cells[i + 6, 7];

                    oRange.Value2 = th.TextTrangThai + "";
                    oRange = (Excel.Range)oSheet.Cells[i + 6, 8];

                    oRange.Value2 = th.ghiChu + "";

                }
                oBook = null;
                oExcel.Quit();
                oExcel = null;
                GC.Collect();
            }
            catch (Exception)
            {

            }
        }
    }
}
