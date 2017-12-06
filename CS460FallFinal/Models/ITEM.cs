namespace CS460FallFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEM")]
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            BIDs = new HashSet<BID>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Item Name")]
        public string NAME { get; set; }

        [StringLength(8000)]
        [Display(Name ="Description")]
        public string DECRIPTION { get; set; }

        [Display(Name ="Seller")]
        public int SELLER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BID> BIDs { get; set; }

        public virtual SELLER SELLER1 { get; set; }
    }
}
