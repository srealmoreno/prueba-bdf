namespace Test.Model.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_LoanStateCurrency
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string description { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string symbol { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string status { get; set; }

        public int? loanCount { get; set; }

        public decimal? totalAmount { get; set; }
    }
}
