﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Lütfen yazınıza bir başlık giriniz.")]
        [DisplayName("Başlık Adı")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Bağlantı")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "Lütfen yazı giriniz.")]
        [DisplayName("İçerik")]
        public string Body { get; set; }
        [DisplayName("Oluşturan Kişi")]
        public string CreatedBy { get; set; }
        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Güncelleyen Kişi")]
        public string UpdatedBy { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        public DateTime UpdateDate { get; set; }
        public List<int> CategoryId { get; set; }
        [DisplayName("Başlık")]
        public string SeoTitle { get; set; }
        [DisplayName("Tanım")]
        public string SeoDescription { get; set; }
        [DisplayName("Anahtar Kelimeler")]
        public string SeoKeywords { get; set; }
    }
}