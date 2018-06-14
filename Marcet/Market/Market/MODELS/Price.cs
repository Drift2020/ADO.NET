namespace Market
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Price")]
    public partial class Price
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        [Column("Price", TypeName = "money")]
        public decimal Price1 { get; set; }

        public virtual Product Product { get; set; }
    }
}
