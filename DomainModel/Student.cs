using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Student")]
    public class Student : Person
    {
        public double Average { get; set; }
        public bool IsClassDelegate { get; set; }
        //public string Email { get; set; }

        public int ClassroomId { get; set; }
        [JsonIgnore]
        public virtual Classroom Classroom { get; set; }
    }
}
