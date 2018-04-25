using QLGV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_MVVM.DAO
{
    static class GiangVienDAO
    {
        public static ObservableCollection<GiangVien> getListGiangVien(List<LayGiangVienTheoTen_Result> kq)
        {
            ObservableCollection<GiangVien> listGv = new ObservableCollection<GiangVien>();
            foreach (var item in kq)
            {
                listGv.Add(DataProvider.Instance.DB.GiangViens.Where(p => p.maGiangVien == item.maGiangVien).SingleOrDefault());
            }
            return listGv;
        }
    }
}
