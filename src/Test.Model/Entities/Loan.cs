namespace Test.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Loan", Schema = "test")]
    [DataContract]
    public partial class Loan : BaseEntity
    {
        [Key]
        [DataMember]
        public long LoanId { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]
        public string LoanType { get; set; }

        [Required]
        [DataMember]
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }

        [Column(TypeName = "date")]
        [DataMember]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public decimal RequestedAmount { get; set; }

        [Required]
        [DataMember]
        [ForeignKey("Currency")]
        public long CurrencyId { get; set; }

        [DataMember]
        public decimal ApprovedAmount { get; set; }

        [DataMember]
        public int FinancingTerm { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
