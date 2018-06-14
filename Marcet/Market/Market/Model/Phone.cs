namespace Market
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phone")]
    public partial class Phone
    {
        public int ID { get; set; }

        public int FirmID { get; set; }

        [Required]
        [StringLength(255)]
        public string Number { get; set; }

        public virtual Firm? Firm { get; set; }
    }
}
