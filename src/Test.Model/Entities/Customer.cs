namespace Test.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Customer", Schema = "test")]
    [DataContract(IsReference = true)]
    public partial class Customer : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Address = new HashSet<Address>();
            Loan = new HashSet<Loan>();
        }

        [Key]
        [DataMember]
        public long CustomerId { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]
        public string IdNumber { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]
        public string IdType { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        public string FirstName { get; set; }

        [StringLength(50)]
        [DataMember]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        public string FirstLastName { get; set; }

        [StringLength(50)]
        [DataMember]
        public string SecondLastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Address> Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Loan> Loan { get; set; }
    }
}
