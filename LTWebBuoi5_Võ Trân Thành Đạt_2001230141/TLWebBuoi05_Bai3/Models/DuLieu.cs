using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TLWebBuoi05_Bai3.Models
{
    public class DuLieu
    {
        //ket noi voi sql sever
        static string strcon = "Data Source = DESKTOP-LGJCSE1; database=QL_DTDD1;User ID = sa;Password=123 ";
        SqlConnection con = new SqlConnection(strcon);
        public List<Loai> dsloai  = new List<Loai>();
        public List<SanPham> dsSanPhham = new List<SanPham>();
        //pt khoi tao
        public DuLieu() {
            DSLoai();
            DSSP();
            
        
        }
        public void DSLoai() {
           
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM LOAI",con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var dl = new Loai();
                dl.MaLoai = dr["MALOAI"].ToString();
                dl.TenLoai = dr["TENLOAI"].ToString();
                dsloai.Add(dl);

            }
            

            
        }
        public void DSSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM SANPHAM", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                var dl = new SanPham();
                dl.MaSP = dr["MASP"].ToString();
                dl.TenSp = dr["TENSP"].ToString();
                dl.DuongDan = dr["DUONGDAN"].ToString();
                dl.Gia = float.Parse(dr["GIA"].ToString());
                dl.Mota = dr["MOTA"].ToString();
                dl.MaLoai = dr["MALOAI"].ToString();
                dsSanPhham.Add(dl);
            }

        }
        public List<SanPham> LaySanPhamTheoLoai(string MaLoai)
        {
            // lọc ra sản phẩm đúng với mã loại mà người truyên vào
            return dsSanPhham.Where ( sp => sp.MaLoai == MaLoai ).ToList();


        }
        public List<SanPham> TimKiemSanPhamTheoChuoi(string TenSp)

        {
            //tim kiem san pham co chhua choi nhap voa(khong phan biiet chu hoa thuong)
            if (string.IsNullOrEmpty(TenSp))
                return dsSanPhham;
            return dsSanPhham.Where(sp => !string.IsNullOrEmpty(sp.TenSp) && sp.TenSp.IndexOf(TenSp, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            //where duyet qua tung phan tu sp trong danh sach thoa man dieu kien trongg ngoac()
            //indexoff tim chuoi con trong tensp 
            //StringComparison.OrdinalIgnoreCase so sanh khong ban biet 
        }

        

    }
}