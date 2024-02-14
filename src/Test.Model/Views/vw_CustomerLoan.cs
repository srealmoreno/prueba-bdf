namespace Test.Model.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_CustomerLoan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long customerId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string idNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string idType { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string secondName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string firstLastName { get; set; }

        [StringLength(50)]
        public string secondLastName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string description { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long loanId { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(20)]
        public string loanType { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "date")]
        public DateTime startDate { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "date")]
        public DateTime endDate { get; set; }

        [Key]
        [Column(Order = 10)]
        public decimal requestedAmount { get; set; }

        [Key]
        [Column(Order = 11)]
        public decimal approvedAmount { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int financingTerm { get; set; }
    }
}
