using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Entity;

namespace MISA.ApplicationCore.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required:Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength:Attribute
    {
        public int Value { get; set; }
        public MaxLength(int length)
        {
            Value = length;  
        }
    }
    public class BaseEntity
    {
        public EntityState EntityState { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifieddBu { get; set; }
    }
}
