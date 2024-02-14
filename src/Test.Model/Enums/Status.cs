using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model.Entities
{
    public enum Status
    {
        [EnumMember(Value = "Active")]
        Active,
        [EnumMember(Value = "Inactive")]
        Inactive,
        [EnumMember(Value = "Created")]
        Created,
        [EnumMember(Value = "Used")]
        Used,
        [EnumMember(Value = "Retrieved")]
        Retrieved,
        [EnumMember(Value = "Rejected")]
        Rejected,
        [EnumMember(Value = "Deleted")]
        Deleted,
        [EnumMember(Value = "Approved")]
        Approved,
        [EnumMember(Value = "Pending")]
        Pending
    }
}
