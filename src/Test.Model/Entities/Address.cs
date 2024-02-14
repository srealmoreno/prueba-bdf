namespace Test.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Address", Schema = "test")]
    [DataContract(IsReference = true)]
    public partial class Address : BaseEntity
    {
        [Key]
        [DataMember]
        public long AddressId { get; set; }

        [Required]
        [DataMember]
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }

        [Required]
        [StringLength(500)]
        [DataMember]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        [DataMember]
        public string Country { get; set; }

        [Required]
        [StringLength(100)]
        [DataMember]
        public string State { get; set; }

        [Required]
        [StringLength(100)]
        [DataMember]
        public string City { get; set; }


        [Required]
        [StringLength(100)]
        [DataMember]
        public string Neighborhood { get; set; }

        [DataMember]
        public bool? IsPrimary { get; set; }

        [DataMember]
        public virtual Customer Customer { get; set; }
    }
}
