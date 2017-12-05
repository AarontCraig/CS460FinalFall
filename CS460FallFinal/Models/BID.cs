namespace CS460FallFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BID")]
    public partial class BID
    {
        public int ID { get; set; }

        public int ITEM { get; set; }

        public int BUYER { get; set; }

        public int PRICE { get; set; }

        [Column(TypeName = "date")]
        public DateTime TIME { get; set; }

        public virtual BUYER BUYER1 { get; set; }

        public virtual ITEM ITEM1 { get; set; }
    }
}
