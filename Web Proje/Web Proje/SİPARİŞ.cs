//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Proje
{
    using System;
    using System.Collections.Generic;
    
    public partial class SİPARİŞ
    {
        public int siparişNo { get; set; }
        public int ürünID { get; set; }
        public int müşteriNo { get; set; }
        public int faturaNo { get; set; }
        public int kargocuKodu { get; set; }
        public double toplamFiyat { get; set; }
    
        public virtual FATURA FATURA { get; set; }
        public virtual HamsterÜrün HamsterÜrün { get; set; }
        public virtual KARGO KARGO { get; set; }
        public virtual KediÜrün KediÜrün { get; set; }
        public virtual KöpekÜrün KöpekÜrün { get; set; }
        public virtual KuşÜrün KuşÜrün { get; set; }
        public virtual MÜŞTERİ MÜŞTERİ { get; set; }
    }
}
