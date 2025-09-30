using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLWebBuoi05_Bai3.Models;

namespace TLWebBuoi05_Bai3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult TrangChinh()
        {
            return View();
        }
        DuLieu csdl = new DuLieu();
        public ActionResult DanhSachLoaiSP()

        {
            List<Loai> ds = csdl.dsloai;
            return View(ds);
        }
        public ActionResult DanhSachSanPham()

        {
            ViewBag.DsLoai = csdl.dsloai;
            List<SanPham> ds = csdl.dsSanPhham;
            return View(ds);
        }
       
        public ActionResult SanPhamTheoLoai(string MaLoai)

        {
            ViewBag.DsLoai = csdl.dsloai;
            var dsSP = csdl.LaySanPhamTheoLoai(MaLoai);
            return View(dsSP);
        }
        public ActionResult TimKiemSanPhamTheoChu(string TenSP)
        {
            ViewBag.DsLoai = csdl.dsloai;
            var kq = csdl.TimKiemSanPhamTheoChuoi(TenSP);
            return View("TimKiemSanPhamTheoChu", kq);
        }
        public ActionResult TimKiemSanPhamTheoLoai(string MaLoai)

        {

            ViewBag.DsLoai = csdl.dsloai;

            if (string.IsNullOrEmpty(MaLoai))
                return View(csdl.dsSanPhham);
            
            var dsSP = csdl.LaySanPhamTheoLoai(MaLoai);
            return View(dsSP);
        }

    }

  }
