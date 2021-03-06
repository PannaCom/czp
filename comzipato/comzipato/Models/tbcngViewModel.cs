﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comzipato.Models
{
    public class CatVM
    {
        public int cat_id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Tên danh mục")]
        public string cat_name { get; set; }
        public string cat_url { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Vị trí")]
        public int? cat_pos { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Danh mục cha")]
        public int? cat_parent_id { get; set; }
    }
    public class spt
    {
        public int id { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public double? lon { get; set; }
        public double? lat { get; set; }
        public double? D { get; set; }
    }
    public class LstCat
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatURL { get; set; }
        public int? CatPos { get; set; }
        public int? ParentCatId { get; set; }
        public IList<LstCat> LstCats { get; set; }
        public LstCat()
        {
            LstCats = new List<LstCat>();
        }
    }


    public class ProductVM
    {
        public long product_id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Tên sản phẩm")]
        public string product_name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Ngôn ngữ")]
        public string lang { get; set; }
        //[Required(ErrorMessage = "Vui lòng nhập {0}")]
        //[Display(Name = "Loại sản phẩm")]
        //public Nullable<int> product_type { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Loại tin")]
        public Nullable<int> product_new_type { get; set; }
        //[Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Giá sản phẩm")]
        public Nullable<int> product_price_public { get; set; }
        //[Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Hình ảnh sản phẩm")]
        public string product_photo { get; set; }
        //[Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Hình ảnh nổi bật")]
        public string product_photo2 { get; set; }
        [Display(Name = "Hướng dẫn")]
        public string product_content { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
        public Nullable<System.DateTime> deleted_date { get; set; }
        [Display(Name = "Trạng thái")]
        public bool status { get; set; }
        [Display(Name = "Danh mục sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public Nullable<int> cat_id { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        public string product_des { get; set; }
        [Display(Name = "Tính năng(feature)")]
        public string product_feature { get; set; }
        [Display(Name = "Thông số kỹ thuật")]
        public string product_technical { get; set; }
    }
    public class Partner
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Mật khẩu")]
        public string pass { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Họ tên")]
        public string full_name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]       
        [Display(Name = "Điện thoại")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]       
        [Display(Name = "Địa chỉ")]
        public string address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Địa chỉ bản đồ kinh độ")]
        public float lon { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Địa chỉ bản đồ vĩ độ")]
        public float lat { get; set; }

    }
    public class DanhMuc
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatUrl { get; set; }
        public int? ParentId { get; set; }
        public int? PositionIndex { get; set; }
        public IList<DanhMuc> DanhMucs { get; set; }
        public DanhMuc()
        {
            DanhMucs = new List<DanhMuc>();
        }
    }

}