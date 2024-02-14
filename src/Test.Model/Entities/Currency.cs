namespace Test.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Currency", Schema = "test")]
    [DataContract]
    [Serializable]
    public partial class Currency : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Currency()
        {
            Loan = new HashSet<Loan>();
        }

        public long CurrencyId { get; set; }

        [Required]
        [StringLength(5)]
        public string Code { get; set; }

        [Required]
        [StringLength(5)]
        public string Symbol { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loan { get; set; }
    }
}
