//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SVEUCILISNA_KNJIZNICA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Knjiga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Knjiga()
        {
            this.Zalihas = new HashSet<Zaliha>();
            this.Transakcijas = new HashSet<Transakcija>();
        }
    
        public int KnjigaID { get; set; }
        public string Naziv { get; set; }
        public string Autor { get; set; }
        public string Barkod { get; set; }
        public string ISBN { get; set; }

        [Display(Name = "Godina izdanja")]
        public string GodIzdanja { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zaliha> Zalihas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transakcija> Transakcijas { get; set; }
    }
}
