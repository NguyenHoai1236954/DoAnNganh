﻿using System;
using System.Collections.Generic;

namespace WebBanHangOnline.Models
{
    public partial class DanhMucSp
    {
        public DanhMucSp()
        {
            AnhSps = new HashSet<AnhSp>();
            ChiTietSps = new HashSet<ChiTietSp>();
        }

        public string MaSp { get; set; } = null!;
        public string? TenSp { get; set; }
        public string? MaChatLieu { get; set; }
        public string? MaHangSx { get; set; }
        public string? MaNuocSx { get; set; }
        public string? GioiThieuSp { get; set; }
        public string? MaLoai { get; set; }
        public string? AnhDaiDien { get; set; }
        public decimal? GiaNhoNhat { get; set; }
        public decimal? GiaLonNhat { get; set; }
        public decimal? ChietKhau { get; set; }

        public virtual ChatLieu? MaChatLieuNavigation { get; set; }
        public virtual HangSx? MaHangSxNavigation { get; set; }
        public virtual LoaiSp? MaLoaiNavigation { get; set; }
        public virtual ICollection<AnhSp> AnhSps { get; set; }
        public virtual ICollection<ChiTietSp> ChiTietSps { get; set; }
    }
}
