using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Hotel1WS
{
    public class KhachSan
    {
        public string TenKhachSan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public float GiaTongQuan { get; set; }
        public string MoTa { get; set; }
        public string DKHuyDatPhong { get; set; }
        public string  AnhDaiDien { get; set; }
        public List<string> DanhSachTienNghi { get; set; }
        public List<string> DanhSachAnh { get; set; }


        public static KhachSan LayChiTietKhachSan(int maKS)
        {
            KhachSan ks = new KhachSan();
            DataTable dt = DataProvider.ExecuteQuery("usp_LayChiTietKhachSan",new SqlParameter[] {new SqlParameter("@maKS",maKS)});
            foreach(DataRow datarow in dt.Rows)
            {
                ks.TenKhachSan = datarow["tenKS"].ToString();
                ks.DiaChi = datarow["diaChi"].ToString();
                ks.SoDienThoai = datarow["sdt"].ToString();
                ks.GiaTongQuan = float.Parse(datarow["giaTongQuan"].ToString());
                ks.MoTa = datarow["moTa"].ToString();
                ks.DKHuyDatPhong = datarow["DKHuydatPhong"].ToString();
                ks.DanhSachTienNghi = datarow["TienNghiKS"].ToString().Trim().Split(',').ToList();
                ks.DanhSachAnh = datarow["HinhAnhKS"].ToString().Trim().Split(',').ToList();
                ks.AnhDaiDien = datarow["AnhDaiDien"].ToString();
            }
            return ks;
        }


    }
}