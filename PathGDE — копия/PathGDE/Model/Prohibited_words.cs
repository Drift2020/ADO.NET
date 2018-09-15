namespace PathGDE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prohibited_words
    {
        [Key]
        public string word { get; set; }
    }
}
