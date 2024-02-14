using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model.Entities
{
    [DataContract (IsReference = true)]
    public abstract class BaseEntity
    {

        [Required]
        [StringLength(20)]
        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime? ModifiedAt { get; set; }

        [DataMember]
        public DateTime? DeletedAt { get; set; }
    }
}
