using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel1WS
{
    public class PhieuDatPhong
    {
        public int idPhieu { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public string soDT { get; set; }
        public string email { get; set; }
        public float tongTien { get; set; }
        public DateTime ngayNhan { get; set; }
        public DateTime ngayTra { get; set; }
        public int tinhTrang { get; set; }
        public static void DatPhong(string[] pdp)
        {
            pdp[5] = coverStr2Date(pdp[5]);
            pdp[6] = coverStr2Date(pdp[6]);
            SqlParameter[] parameters = { new SqlParameter("@hoten", pdp[0]), new SqlParameter("@diachi", pdp[1]), new SqlParameter("@sodt", pdp[2]), new SqlParameter("@email", pdp[3]), new SqlParameter("@tongtien", pdp[4]), new SqlParameter("@ngaynhan", pdp[5]), new SqlParameter("@ngaytra", pdp[6]), new SqlParameter("@soLuong", pdp[7]), new SqlParameter("@loaiPhong", pdp[8]   ) };
            int maPhieu = DataProvider.ExecuteNonQuery("usp_TaoPhieuDatPhong", parameters);
        }
        private static string coverStr2Date(string input)
        {
            string[] newstr = input.Split('/');
            return newstr[1] + "/" + newstr[0] + "/" + newstr[2];

        }

    }
}