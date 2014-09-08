using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Hotel1WS
{
    /// <summary>
    /// Summary description for Hotel1WS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Hotel1WS : System.Web.Services.WebService
    {

        [WebMethod]
        public KhachSan getThongTinKhachSan()
        {
            return KhachSan.LayChiTietKhachSan(1);
        }
        //[WebMethod]
        //public List<Phong> getDSPhong()
        //{
        //    return Phong.getDSPhong();
        //}
        [WebMethod]
        public void DatPhongChoKS(string pdp)
        {
            string[] phieudatphong = pdp.Split(',');
            PhieuDatPhong.DatPhong(phieudatphong);
        }
        [WebMethod]
        public List<LoaiPhong> getDSLoaiPhong()
        {
            return LoaiPhong.getDSLoaiPhong();
        }
        [WebMethod]
        public LoaiPhong getChiTietPhong(string index)
        {
            int lp = int.Parse(index);
            return LoaiPhong.getChiTietPhong(lp);
        }
    }
}
