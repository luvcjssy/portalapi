using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel1WS
{
    public class Phong
    {
        public int idPhong { get; set; }   
        public string tenPhong { get; set; }
        public LoaiPhong loaiPhong { get; set; }
        //public int tinhTrang { get; set; }
        public List<string> dsAnh { get; set; }


        public static List<Phong> getDSPhong()
        {
            List<Phong> list = new List<Phong>();
            List<LoaiPhong> listLoaiPhong = LoaiPhong.getDSLoaiPhong();
            DataTable dt = DataProvider.ExecuteQuery("usp_LayDanhSachPhong", null);
            foreach (DataRow datarow in dt.Rows)
            {
                Phong p = new Phong();
                p.idPhong = int.Parse(datarow["idPhong"].ToString());
                p.tenPhong = datarow["TenPhong"].ToString();
                p.loaiPhong = LoaiPhong.getLoaiPhongFromidLoai(int.Parse(datarow["loaiPhong"].ToString()), listLoaiPhong);
                list.Add(p);
            }
            return list;
        }

    }
    
}