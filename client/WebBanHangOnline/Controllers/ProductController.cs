﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHangOnline.Models;
using WebBanHangOnline.ViewModels;
using X.PagedList;

namespace WebBanHangOnline.Controllers
{
    
    public class ProductController : Controller
    {
        QlbanHangContext db = new QlbanHangContext();
       
        public IActionResult Index(int? page)
        {
            try
            {
                int pageSize = 9;
                int pageNumber = page == null || page < 0 ? 1 : page.Value;
                var lstSanPham = db.DanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
                PagedList<DanhMucSp> lst = new PagedList<DanhMucSp>(lstSanPham, pageNumber, pageSize);
                return View(lst);
            }
            catch 
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult SanPhamTheoLoai(string maLoai, int? page = 1)
        {

            try
            {
                int pageSize = 8;
                int pageNumber = page == null || page < 0 ? 1 : page.Value;
                var lstSanPham = db.DanhMucSps.AsNoTracking()
                    .Where(x => x.MaLoai == maLoai)
                    .OrderBy(x => x.TenSp);
                PagedList<DanhMucSp> lst = new PagedList<DanhMucSp>(lstSanPham, pageNumber, pageSize);
                ViewBag.maloai = maLoai;
                return View(lst);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult ChiTietSanpham(string maSp)
        {

            try
            {
                var sanPham = db.DanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
                var anhSP = db.AnhSps.Where(x => x.MaSp == maSp).ToList();
               
                ViewBag.anhSP = anhSP;
                return View(sanPham);

            }

            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult ProductDetail(string maSp)
        {
            var sanPham = db.DanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSP = db.AnhSps.Where(x => x.MaSp == maSp).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewModel
            {
                danhMucSP = sanPham,
                anhSps = anhSP
            };

           
            return View(homeProductDetailViewModel);
        }
    }
}
