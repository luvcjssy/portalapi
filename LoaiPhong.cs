using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel1WS
{
    public class LoaiPhong
    {
        public int idLoai { get; set; }
        public string tenLoai { get; set; }
        public int giaPhong { get; set; }
        public string motaPhong { get; set; }
        public List<string> hinhAnh { get; set; }
        public int PhongTrong { get; set; }
        public int SoLuongPhong { get; set; }
        public int soLuongDat { get; set; }


        public static List<LoaiPhong> getDSLoaiPhong()
        {
            List<LoaiPhong> listLP = new List<LoaiPhong>();
            DataTable dt = DataProvider.ExecuteQuery("select * from LoaiPhong");
            foreach (DataRow datarow in dt.Rows)

            {
                LoaiPhong lp = new LoaiPhong();
                lp.idLoai = int.Parse(datarow["idLoai"].ToString());
                lp.tenLoai = datarow["tenLoai"].ToString();
                lp.giaPhong = int.Parse(datarow["giaPhong"].ToString());
                lp.motaPhong = datarow["motaPhong"].ToString();
                lp.SoLuongPhong = int.Parse(datarow["soLuongPhong"].ToString());
                lp.soLuongDat = int.Parse(datarow["soLuongDat"].ToString());
                DataTable dt1 = DataProvider.ExecuteQuery("usp_DanhSachAnhCuaLoaiPhong", new SqlParameter[] { new SqlParameter("@maLoaiPhong", lp.idLoai) });
                lp.hinhAnh = new List<string>();
                foreach(DataRow dr in dt1.Rows)
                {
                    lp.hinhAnh.Add(dr["duongDan"].ToString());
                }
                dt = DataProvider.ExecuteQuery("usp_PhongTrong_LoaiPhong", new SqlParameter[] { new SqlParameter("@maLoaiPhong", lp.idLoai) });
                lp.PhongTrong = int.Parse(dt.Rows[0][0].ToString());
                listLP.Add(lp);
            }
            return listLP;
        }
        public static LoaiPhong getChiTietPhong(int index)
        {
            string sql = "select * from LoaiPhong where idLoai =" + index.ToString();
            DataTable dt = DataProvider.ExecuteQuery(sql);
            LoaiPhong lp = new LoaiPhong();
            foreach (DataRow datarow in dt.Rows)
            {
                lp.idLoai = int.Parse(datarow["idLoai"].ToString());
                lp.tenLoai = datarow["tenLoai"].ToString();
                lp.giaPhong = int.Parse(datarow["giaPhong"].ToString());
                lp.motaPhong = datarow["motaPhong"].ToString();
                DataTable dt1 = DataProvider.ExecuteQuery("usp_DanhSachAnhCuaLoaiPhong", new SqlParameter[] { new SqlParameter("@maLoaiPhong", lp.idLoai) });
                lp.hinhAnh = new List<string>();
                foreach (DataRow dr in dt1.Rows)
                {
                    lp.hinhAnh.Add(dr["duongDan"].ToString());
                }
                dt = DataProvider.ExecuteQuery("usp_PhongTrong_LoaiPhong", new SqlParameter[] { new SqlParameter("@maLoaiPhong", lp.idLoai) });
                lp.PhongTrong = int.Parse(dt.Rows[0][0].ToString());
            }
            return lp;
        }
        public static LoaiPhong getLoaiPhongFromidLoai(int id,List<LoaiPhong> dslp)
        {
            foreach(LoaiPhong lp in dslp)
            {
                if (lp.idLoai == id)
                    return lp;
            }
            return dslp[0];
        }
    }
}