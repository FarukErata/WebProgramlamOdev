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
    
    public partial class TEDARİKÇİ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEDARİKÇİ()
        {
            this.HamsterÜrün = new HashSet<HamsterÜrün>();
            this.KediÜrün = new HashSet<KediÜrün>();
            this.KöpekÜrün = new HashSet<KöpekÜrün>();
            this.KuşÜrün = new HashSet<KuşÜrün>();
        }
    
        public int tedarikçiNo { get; set; }
        public string tedarikçiAdı { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HamsterÜrün> HamsterÜrün { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KediÜrün> KediÜrün { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KöpekÜrün> KöpekÜrün { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KuşÜrün> KuşÜrün { get; set; }
    }
}
